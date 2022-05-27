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
    [Tooltip("�ړ����x"), SerializeField] float _moveSpeed = 5f;
    [Tooltip("�W�����v��"), SerializeField] int _jumpPower = 5;

    [Header("�K�[�h�֘A")]
    [Tooltip("�K�[�h�̑ϋv�l"), SerializeField] int _shieldHp = 5;
    [Tooltip("���t���N�g�̎�t����"), SerializeField] float _reflectTime = 1;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        
    }
}
