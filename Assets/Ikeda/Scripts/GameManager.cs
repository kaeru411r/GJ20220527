using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{

    static public GameManager Instance;

    static Enemy[] _enemys;
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
    void Update()
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

    static void EnemyCollecting()
    {
        List<Enemy> list = new List<Enemy>();
        _enemys = GameObject.FindObjectsOfType<Enemy>();
    }
}
