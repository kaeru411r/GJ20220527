using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/// <summary>
/// �Q�[���V�[���S�̂̊Ǘ�������
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] float _waitTime;
    [SerializeField] float _waitTime2;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _gameClearText;
    static private GameManager _instance;
    /// <summary>���݂̃V�[����GameManager</summary>
    static public GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if( _instance == null)
                {
                    Debug.LogError($"{nameof(Instance)}��������܂���");
                    return null;
                }
            }
            return _instance;
        }
    }

    /// <summary>���݃}�b�v��ɑ��݂���Enemy</summary>
    static public Enemy[] Enemys
    {
        get
        {
            if(_enemys == null)
            {
                EnemyCollecting();
                if(_enemys == null)
                {
                    Debug.LogError($"{nameof(Enemys)}��������܂���");
                    return null;
                }
            }
            EnemyNullCheck();
            return _enemys.ToArray();
        }
    }

    /// <summary>���݃V�[���ɑ��݂���Player</summary>
    static public PlayerController Player
    {
        get
        {
            if(_player == null)
            {
                _player = GameObject.FindObjectOfType<PlayerController>();
                if (Player == null)
                {
                    Debug.LogError($"{nameof(Player)}��������܂���");
                    return null;
                }
            }
            return _player;
        }
    }


    /// <summary>���݃}�b�v��ɑ��݂���Enemy</summary>
    static private List<Enemy> _enemys;
    /// <summary>���݃V�[���ɑ��݂���Player</summary>
    static private PlayerController _player;


    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        EnemyCollecting();
        _player = FindObjectOfType<PlayerController>();
    }

    /// <summary>
    /// �Q�[���I�[�o�[���ɌĂ�
    /// </summary>
    public void GameOvar()
    {
        _gameOverText.SetActive (true);
        StartCoroutine(GameOvar(_waitTime));
    }

    /// <summary>
    /// �Q�[���J�n���ɌĂ�
    /// </summary>
    public void GameStart()
    {

    }

    /// <summary>
    /// �Q�[���N���A���ɌĂ�
    /// </summary>
    public void GameClear()
    {
        _gameClearText.SetActive(true);
        StartCoroutine(GameClear(_waitTime2));
    }


    /// <summary>
    /// �V�[�����Enemy��_enemys�ɑ��
    /// </summary>
    static private void EnemyCollecting()
    {
        _enemys = GameObject.FindObjectsOfType<Enemy>().ToList();
    }

    /// <summary>
    /// Enemy��ǉ�
    /// </summary>
    /// <param name="e"></param>
    static public void AddEnemy(Enemy e)
    {
        if (!_enemys.Contains(e))
        {
            _enemys.Add(e);
        }
    }

    /// <summary>
    /// Enemy���폜
    /// </summary>
    /// <param name="e"></param>
    static public void RemoveEnemy(Enemy e)
    {
        if (_enemys.Contains(e))
        {
            _enemys.Remove(e);
        }
    }

    /// <summary>
    /// _enemys��null���������m���߁A�����������
    /// </summary>
    private static void EnemyNullCheck()
    {
        for(int i = 0; i < _enemys.Count; i++)
        {
            if(_enemys[i] == null)
            {
                _enemys.RemoveAt(i);
                i--;
            }
        }
    }

    IEnumerator GameOvar(float tim)
    {
        yield return new WaitForSeconds(tim);
        SceneManager.Instance.Playback();
    }

    IEnumerator GameClear(float tim)
    {
        yield return new WaitForSeconds(tim);
        SceneManager.Instance.Playback();
    }




}

