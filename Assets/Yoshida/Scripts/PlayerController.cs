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
    [Tooltip("Shiftキー(ガードボタン)が押されたとき"), SerializeField] private GameObject _guardObject = default;
    [Tooltip("反射する弾のオブジェクト"), SerializeField] private ReflectBulletController _reflectBullet = default;
    [Tooltip("弾が発射される位置"), SerializeField] private Transform _muzzle = default;
    [Tooltip("ガードの耐久値"), SerializeField] private int _guardHp = 5;
    [Tooltip("リフレクトの受付時間"), SerializeField] private int _reflectTime = 1;
    [Tooltip("現在のガードの耐久値"), SerializeField] private int _currentGuardHp = 0;
    [Tooltip("リフレクト用フラグ")] private bool _isReflect = false;
    [Tooltip("ガード用フラグ")] private bool _isGuard = false;
    [Tooltip("計測用")] private float _timer = 0f;

    [Tooltip("接地フラグ")] private bool _isGround = false;
    [Tooltip("左右どっちをを向いているかどうかのフラグ")] bool isRight = false;
    private float _h = 0f;
    private Rigidbody2D _rb;
    Vector2 _scale;

    Animator _anim = default;
    bool _isMove = false;
    bool _isJump = false;
    bool _isDead = false;
    public int PlayerHp { get => _playerHp; }

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _scale.x = this.transform.localScale.x; // ここで scale (向き)を保持しておく。
    }

    private void Update()
    {
        _guardObject.SetActive(false);

        //ジャンプ
        if (Input.GetButtonDown("Jump") && _isGround == true)
        {
            Jump();
        }

        //ガード
        if (Input.GetButtonDown("Guard"))
        {
            _timer = 0f;
            _currentGuardHp = _guardHp;
        }
        if (Input.GetButton("Guard"))
        {
            Guard();
        }
        if (Input.GetButtonUp("Guard"))
        {
            _currentGuardHp = _guardHp;
        }
    }
    private void FixedUpdate()
    {
        // Animator関連
        if (_anim)
        {
            _anim.SetBool("PlayerMove", _isMove);
            _anim.SetBool("PlayerJump", _isJump);
            _anim.SetBool("PlayerDead", _isDead);
        }

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
        var scale = gameObject.transform.localScale;
        
        if(_h != 0f)
        {
            _isMove = true;
        }
        else
        {
            _isMove= false;
        }
        
        // 右に入力した時
        if (_h > 0f)
        {
            _rb.velocity = new Vector2(_moveSpeed, _rb.velocity.y);
            scale.x = _scale.x;
            isRight = true;
        }
        // 左に入力した時
        else if (_h < 0f)
        {
            _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);
            scale.x = _scale.x * -1;
            isRight = false;
        }
        gameObject.transform.localScale = scale;
    }

    /// <summary>
    /// ジャンプ処理、Space キーが押されたら呼ばれる関数。
    /// </summary>
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        _isJump = true;
    }

    /// <summary>
    /// 敵の弾が当たった時に呼ばれる関数
    /// </summary>
    public void Hit(int damage)
    {
        if (_isReflect == true)
        {
            Reflect();
        }
        else if (_isGuard == true)
        {
            if (_currentGuardHp > 0)
            {
                _currentGuardHp -= damage;
                Debug.Log($"ガードの耐久値が{damage}減った");
            }
        }
        else
        {
            _playerHp -= damage;
            _isDead = true;
            if(PlayerHp <= 0)
            {
                GameManager.Instance.GameOvar();
            }
            Debug.Log($"プレイヤーが{damage}ダメージ受けた");
        }
    }

    /// <summary>
    /// 敵が直接プレイヤーに当たった時に呼ばれる関数。
    /// </summary>
    /// <param name="damage"></param>
    public void HitEnemy(int damage)
    {
        _playerHp -= damage;
    }

    /// <summary>
    /// 反射の処理
    /// </summary>
    private void Reflect()
    {
        var go = Instantiate(_reflectBullet, _muzzle.position, Quaternion.identity);
        go.GetComponent<ReflectBulletController>();
        go.Bullet(isRight);
    }

    /// <summary>
    /// ガード時の処理
    /// </summary>
    private void Guard()
    {
        _guardObject.SetActive(true);

        _timer += Time.deltaTime;
        if (_timer < _reflectTime)
        {
            _isReflect = true;
            Debug.Log("反射中");
        }
        else if(_currentGuardHp > 0)
        {
            _isReflect = false;
            _isGuard = true;
            Debug.Log($"ガード中、現在のガード耐久値は{_currentGuardHp}");
        }
        if (_currentGuardHp <= 0)
        {
            _isGuard = false;
            Debug.Log("ガードの効果が切れた");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
            _isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
    }
}
