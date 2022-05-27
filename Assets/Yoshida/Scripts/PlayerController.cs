using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player �̓����𐧌䂷��R���|�[�l���g
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("�X�e�[�^�X(����Ƃ�HP����)")]
    [Tooltip("Player��HP"), SerializeField] int _playerHp = 10;

    [Header("�ړ��֘A")]
    [Tooltip("�ړ����x"), SerializeField] private float _moveSpeed = 5f;
    [Tooltip("�W�����v��"), SerializeField] private int _jumpPower = 5;

    [Header("�K�[�h�֘A")]
    [Tooltip("�K�[�h�̑ϋv�l"), SerializeField] private int _shieldHp = 5;
    [Tooltip("���t���N�g�̎�t����"), SerializeField] private int _reflectTime = 1;

    [Tooltip("�ڒn�t���O")] private bool _isGround = false;

    private float _h = 0f;
    private Rigidbody2D _rb;

    public int PlayerHp { get => _playerHp; set => _playerHp = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _isGround == true)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// �ړ������B���E�ɓ��͂��󂯂����ɌĂ΂��֐��B
    /// </summary>
    private void Move()
    {
        // �ړ�
        // ���͂��󂯕t����
        float _h = Input.GetAxisRaw("Horizontal");
        // �E�ɓ��͂�����
        if (_h > 0f)
        {
            _rb.velocity = new Vector2(_moveSpeed, _rb.velocity.y);
        }
        // ���ɓ��͂�����
        else if (_h < 0f)
        {
            _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);
        }
    }

    /// <summary>
    /// �W�����v�����ASpace �L�[�������ꂽ��Ă΂��֐��B
    /// </summary>
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        _isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }
}
