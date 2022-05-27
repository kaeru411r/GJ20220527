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
    [Tooltip("移動速度"), SerializeField] float _moveSpeed = 5f;
    [Tooltip("ジャンプ力"), SerializeField] int _jumpPower = 5;

    [Header("ガード関連")]
    [Tooltip("ガードの耐久値"), SerializeField] int _shieldHp = 5;
    [Tooltip("リフレクトの受付時間"), SerializeField] float _reflectTime = 1;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        
    }
}
