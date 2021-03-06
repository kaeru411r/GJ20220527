using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 反射された弾のコンポーネント
/// </summary>
public class ReflectBulletController : MonoBehaviour
{
    [Tooltip("弾の速さ"), SerializeField] private int _moveSpeed = 10;
    [Tooltip("弾の攻撃力"), SerializeField] private int _power = 1;
    [Tooltip("弾の生存時間"), SerializeField] private int _bulletLifeTime = 3;

    Enemy _enemy = default;
    Rigidbody2D _rb;

    private void Start()
    {
        Destroy(gameObject, _bulletLifeTime);
    }

    /// <summary>
    /// 弾の発射を処理する関数
    /// </summary>
    public void Bullet(bool isRight)
    {
        int n = -1;
        if (isRight)
        {
            n = 1;
        }
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _moveSpeed * n;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var e = collision.GetComponent<Enemy>();
            e.Damage(_power);
            Destroy(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
