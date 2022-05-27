using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player の動きを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("ステータス(今んとこHPだけ)")]
    [Tooltip("PlayerのHP"), SerializeField] int _playerHp = 10;

    [Header("移動関連")]
    [Tooltip("移動速度"), SerializeField] private float _moveSpeed = 5f;
    [Tooltip("ジャンプ力"), SerializeField] private int _jumpPower = 5;

    [Header("ガード関連")]
    [Tooltip("ガードの耐久値"), SerializeField] private int _shieldHp = 5;
    [Tooltip("リフレクトの受付時間"), SerializeField] private int _reflectTime = 1;

    [Tooltip("接地フラグ")] private bool _isGround = false;

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
    /// 移動処理。左右に入力を受けた時に呼ばれる関数。
    /// </summary>
    private void Move()
    {
        // 移動
        // 入力を受け付ける
        float _h = Input.GetAxisRaw("Horizontal");
        // 右に入力した時
        if (_h > 0f)
        {
            _rb.velocity = new Vector2(_moveSpeed, _rb.velocity.y);
        }
        // 左に入力した時
        else if (_h < 0f)
        {
            _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);
        }
    }

    /// <summary>
    /// ジャンプ処理、Space キーが押されたら呼ばれる関数。
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
