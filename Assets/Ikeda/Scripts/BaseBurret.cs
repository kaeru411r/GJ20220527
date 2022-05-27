using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBurret : MonoBehaviour
{
    [Tooltip("’e‚Ì¶‘¶ŠÔ")]
    [SerializeField] float _deleteTime;
    [Tooltip("’e‚ÌUŒ‚—Í")]
    [SerializeField] int _damage;

    /// <summary>
    /// ¶¬‚Ìˆ—
    /// </summary>
    void SetUp()
    {
        Destroy(gameObject, _deleteTime);
    }

    /// <summary>’e‚Ìƒqƒbƒg‚Ì</summary>
    void Hit()
    {
    }
}
