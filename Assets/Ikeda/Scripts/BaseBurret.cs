using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBurret : MonoBehaviour
{
    [Tooltip("弾の生存時間")]
    [SerializeField] float _deleteTime;
    [Tooltip("弾の攻撃力")]
    [SerializeField] int _damage;

    /// <summary>
    /// 生成時の処理
    /// </summary>
    protected void SetUp()
    {
        Destroy(gameObject, _deleteTime);
    }

    /// <summary>弾のヒット時の処理</summary>
    protected void Hit()
    {
        GameManager.Player.Hit(_damage);
    }
}
