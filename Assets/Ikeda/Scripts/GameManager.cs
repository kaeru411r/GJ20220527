using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/// <summary>
/// ゲームシーン全体の管理をする
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] float _waitTime;
    [SerializeField] float _waitTime2;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _gameClearText;
    static private GameManager _instance;
    /// <summary>現在のシーンのGameManager</summary>
    static public GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if( _instance == null)
                {
                    Debug.LogError($"{nameof(Instance)}が見つかりません");
                    return null;
                }
            }
            return _instance;
        }
    }

    /// <summary>現在マップ上に存在するEnemy</summary>
    static public Enemy[] Enemys
    {
        get
        {
            if(_enemys == null)
            {
                EnemyCollecting();
                if(_enemys == null)
                {
                    Debug.LogError($"{nameof(Enemys)}が見つかりません");
                    return null;
                }
            }
            EnemyNullCheck();
            return _enemys.ToArray();
        }
    }

    /// <summary>現在シーンに存在するPlayer</summary>
    static public PlayerController Player
    {
        get
        {
            if(_player == null)
            {
                _player = GameObject.FindObjectOfType<PlayerController>();
                if (Player == null)
                {
                    Debug.LogError($"{nameof(Player)}が見つかりません");
                    return null;
                }
            }
            return _player;
        }
    }


    /// <summary>現在マップ上に存在するEnemy</summary>
    static private List<Enemy> _enemys;
    /// <summary>現在シーンに存在するPlayer</summary>
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
    /// ゲームオーバー時に呼ぶ
    /// </summary>
    public void GameOvar()
    {
        _gameOverText.SetActive (true);
        StartCoroutine(GameOvar(_waitTime));
    }

    /// <summary>
    /// ゲーム開始時に呼ぶ
    /// </summary>
    public void GameStart()
    {

    }

    /// <summary>
    /// ゲームクリア時に呼ぶ
    /// </summary>
    public void GameClear()
    {
        _gameClearText.SetActive(true);
        StartCoroutine(GameClear(_waitTime2));
    }


    /// <summary>
    /// シーン上のEnemyを_enemysに代入
    /// </summary>
    static private void EnemyCollecting()
    {
        _enemys = GameObject.FindObjectsOfType<Enemy>().ToList();
    }

    /// <summary>
    /// Enemyを追加
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
    /// Enemyを削除
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
    /// _enemysにnullが無いか確かめ、あったら消す
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

