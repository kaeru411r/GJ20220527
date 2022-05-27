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
    [Tooltip("���˂���e�̃I�u�W�F�N�g"), SerializeField] private GameObject _reflectBullet = default;
    [Tooltip("�e�����˂����ʒu"), SerializeField] private Transform _muzzle = default;
    [Tooltip("�K�[�h�̑ϋv�l"), SerializeField] private int _guardHp = 5;
    [Tooltip("���t���N�g�̎�t����"), SerializeField] private int _reflectTime = 1;
    [Tooltip("���݂̃K�[�h�̑ϋv�l"), SerializeField] private int _currentGuardHp = 0;
    [Tooltip("���t���N�g�p�t���O")] private bool _isReflect = false;
    [Tooltip("�K�[�h�p�t���O")] private bool _isGuard = false;
    [Tooltip("�v���p")] private float _timer = 0f;

    [Tooltip("�ڒn�t���O")] private bool _isGround = false;
    private float _h = 0f;
    private Rigidbody2D _rb;

    public int PlayerHp { get => _playerHp; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        }
        if (Input.GetButton("Guard"))
        {
            Guard();
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
            else if (_currentGuardHp < 0)
            {
                _isGround = false;
                Debug.Log("�K�[�h�̌��ʂ��؂ꂽ");
            }
        }
        else
        {
            _playerHp -= damage;
            Debug.Log($"�v���C���[��{damage}�_���[�W�󂯂�");
        }
    }

    /// <summary>
    /// ���˂̏���
    /// </summary>
    private void Reflect()
    {
        Instantiate(_reflectBullet, _muzzle.position, Quaternion.identity);
    }

    /// <summary>
    /// �K�[�h���̏���
    /// </summary>
    private void Guard()
    {
        if (_currentGuardHp <= 0)
        {
            _currentGuardHp = _guardHp;
        }
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
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
    }
}
