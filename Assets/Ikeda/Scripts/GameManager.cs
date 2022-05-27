using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/// <summary>
/// �Q�[���V�[���S�̂̊Ǘ�������
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>���݂̃V�[����GameManager</summary>
    static public GameManager Instance;

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
                    return null;
                }
            }
            EnemyNullCheck();
            return _enemys.ToArray();
        }
    }

    /// <summary>���݃}�b�v��ɑ��݂���Enemy</summary>
    static private List<Enemy> _enemys;


    private void Awake()
    {
        Instance = this;
        EnemyCollecting();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /// <summary>
    /// �Q�[���I�[�o�[���ɌĂ�
    /// </summary>
    public void GameOvar()
    {

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
}
