using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int _enemyHp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBarrett")) ;
        {
            _enemyHp -= 1;
            Destroy(other.gameObject);
            if (_enemyHp == 0)
            {
                Destroy(transform.root.gameObject);
            }
        }
    }
}
