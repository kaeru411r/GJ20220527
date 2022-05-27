    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _enemyHp;
    public void Damage(int damage)
    {
       _enemyHp -= damage;
        if(_enemyHp <= 0 )
        {
            Death();
        }
    }
    private void Death()
    {
        GameManager.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
