using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���˂��ꂽ�e�̃R���|�[�l���g
/// </summary>
public class ReflectBulletController : MonoBehaviour
{
    [Tooltip("�e�̑���"), SerializeField] private int _moveSpeed = 10;
    [Tooltip("�e�̍U����"), SerializeField] private int _power = 1;
    [Tooltip("�e�̐�������"), SerializeField] private int _bulletLifeTime = 3;
    [Tooltip("�v���p")] private float _timer = 0;

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