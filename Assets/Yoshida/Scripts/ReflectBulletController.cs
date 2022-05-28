using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ”½Ë‚³‚ê‚½’e‚ÌƒRƒ“ƒ|[ƒlƒ“ƒg
/// </summary>
public class ReflectBulletController : MonoBehaviour
{
    [Tooltip("’e‚Ì‘¬‚³"), SerializeField] private int _moveSpeed = 10;
    [Tooltip("’e‚ÌUŒ‚—Í"), SerializeField] private int _power = 1;
    [Tooltip("’e‚Ì¶‘¶ŠÔ"), SerializeField] private int _bulletLifeTime = 3;

    Enemy _enemy = default;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _moveSpeed;
        Destroy(gameObject, _bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            _enemy.Damage(_power);
            Destroy(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
