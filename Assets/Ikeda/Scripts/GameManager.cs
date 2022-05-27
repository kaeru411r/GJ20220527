using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{

    static public GameManager Instance;

    static private List<Enemy> _enemys;
    static public List<Enemy> Enemys
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
            return _enemys;
        }
    }


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

    public void GameOvar()
    {

    }

    public void GameStart()
    {

    }

    public void GameClear()
    {

    }

    static private void EnemyCollecting()
    {
        _enemys = GameObject.FindObjectsOfType<Enemy>().ToList();
    }

    static public void AddEnemy(Enemy e)
    {
        if (!_enemys.Contains(e))
        {
            _enemys.Add(e);
        }
    }

    static public void RemoveEnemy(Enemy e)
    {
        if (_enemys.Contains(e))
        {
            _enemys.Remove(e);
        }
    }
}
