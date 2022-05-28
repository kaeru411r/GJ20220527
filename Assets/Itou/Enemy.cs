using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _enemyDamage;
    [SerializeField] int _enemyHp;
    public void Damage(int damage)
    {
       _enemyHp -= damage;
        if(_enemyHp <= 0 )
        {
            Death();
        }

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            GameManager.Player.HitEnemy(_enemyDamage);
        }
    }
    private void Death()
    {
        GameManager.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
