using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var es = GameManager.Enemys;
        foreach(var e in es)
        {
            Debug.Log(e);
        }
        Debug.Log("");
        var go = Instantiate(new GameObject());
        var enemy = go.AddComponent<Enemy>();
        GameManager.AddEnemy(enemy);
        foreach (var e in es)
        {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
