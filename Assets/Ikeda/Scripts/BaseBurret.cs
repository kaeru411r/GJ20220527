using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBurret : MonoBehaviour
{
    [Tooltip("�e�̐�������")]
    [SerializeField] float _deleteTime;
    [Tooltip("�e�̍U����")]
    [SerializeField] int _damage;

    /// <summary>
    /// �������̏���
    /// </summary>
    void SetUp()
    {
        Destroy(gameObject, _deleteTime);
    }

    /// <summary>�e�̃q�b�g����</summary>
    void Hit()
    {
    }
}
