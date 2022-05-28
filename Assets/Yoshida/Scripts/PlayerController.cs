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
    [Tooltip("Shift�L�[(�K�[�h�{�^��)�������ꂽ�Ƃ�"), SerializeField] private GameObject _guardObject = default;
    [Tooltip("���˂���e�̃I�u�W�F�N�g"), SerializeField] private ReflectBulletController _reflectBullet = default;
    [Tooltip("�e�����˂����ʒu"), SerializeField] private Transform _muzzle = default;
    [Tooltip("�K�[�h�̑ϋv�l"), SerializeField] private int _guardHp = 5;
    [Tooltip("���t���N�g�̎�t����"), SerializeField] private int _reflectTime = 1;
    [Tooltip("���݂̃K�[�h�̑ϋv�l"), SerializeField] private int _currentGuardHp = 0;
    [Tooltip("���t���N�g�p�t���O")] private bool _isReflect = false;
    [Tooltip("�K�[�h�p�t���O")] private bool _isGuard = false;
    [Tooltip("�v���p")] private float _timer = 0f;

    [Tooltip("�ڒn�t���O")] private bool _isGround = false;
    [Tooltip("���E�ǂ������������Ă��邩�ǂ����̃t���O")] bool isRight = false;
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
        _scale.x = this.transform.localScale.x; // ������ scale (����)��ێ����Ă����B
    }

    private void Update()
    {
        _guardObject.SetActive(false);

        //�W�����v
        if (Input.GetButtonDown("Jump") && _isGround == true)
        {
            Jump();
        }

        //�K�[�h
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
        // Animator�֘A
        if (_anim)
        {
            _anim.SetBool("PlayerMove", _isMove);
            _anim.SetBool("PlayerJump", _isJump);
            _anim.SetBool("PlayerDead", _isDead);
        }

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
        var scale = gameObject.transform.localScale;
        
        if(_h != 0f)
        {
            _isMove = true;
        }
        else
        {
            _isMove= false;
        }
        
        // �E�ɓ��͂�����
        if (_h > 0f)
        {
            _rb.velocity = new Vector2(_moveSpeed, _rb.velocity.y);
            scale.x = _scale.x;
            isRight = true;
        }
        // ���ɓ��͂�����
        else if (_h < 0f)
        {
            _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);
            scale.x = _scale.x * -1;
            isRight = false;
        }
        gameObject.transform.localScale = scale;
    }

    /// <summary>
    /// �W�����v�����ASpace �L�[�������ꂽ��Ă΂��֐��B
    /// </summary>
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        _isJump = true;
    }

    /// <summary>
    /// �G�̒e�������������ɌĂ΂��֐�
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
                Debug.Log($"�K�[�h�̑ϋv�l��{damage}������");
            }
            else if (_currentGuardHp <= 0)
            {
                _isGuard = false;
                Debug.Log("�K�[�h�̌��ʂ��؂ꂽ");
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
            Debug.Log($"�v���C���[��{damage}�_���[�W�󂯂�");
        }
    }

    /// <summary>
    /// �G�����ڃv���C���[�ɓ����������ɌĂ΂��֐��B
    /// </summary>
    /// <param name="damage"></param>
    public void HitEnemy(int damage)
    {
        _playerHp -= damage;
    }

    /// <summary>
    /// ���˂̏���
    /// </summary>
    private void Reflect()
    {
        var go = Instantiate(_reflectBullet, _muzzle.position, Quaternion.identity);
        go.GetComponent<ReflectBulletController>();
        go.Bullet(isRight);
    }

    /// <summary>
    /// �K�[�h���̏���
    /// </summary>
    private void Guard()
    {
        _guardObject.SetActive(true);

        _timer += Time.deltaTime;
        if (_timer < _reflectTime)
        {
            _isReflect = true;
            Debug.Log("���˒�");
        }
        else if(_currentGuardHp > 0)
        {
            _isReflect = false;
            _isGuard = true;
            Debug.Log($"�K�[�h���A���݂̃K�[�h�ϋv�l��{_currentGuardHp}");
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
