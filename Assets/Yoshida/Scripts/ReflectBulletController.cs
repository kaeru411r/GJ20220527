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
    [Tooltip("Œv‘ª—p")] private float _timer = 0;

    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _moveSpeed;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _bulletLifeTime)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
