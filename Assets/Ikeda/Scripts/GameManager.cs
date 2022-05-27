using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/// <summary>
/// ゲームシーン全体の管理をする
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>現在のシーンのGameManager</summary>
    static public GameManager Instance;

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
                    return null;
                }
            }
            EnemyNullCheck();
            return _enemys.ToArray();
        }
    }

    /// <summary>現在マップ上に存在するEnemy</summary>
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
    /// ゲームオーバー時に呼ぶ
    /// </summary>
    public void GameOvar()
    {

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
