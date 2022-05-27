using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBarrett;
    //ˆê•b‚²‚Æ‚É’e‚ğİ’u‚·‚é‚½‚ß‚Ì‚à‚Ì
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    // Update is called once per frame
    void Update()
    {
        //ˆê•bŒo‚Â‚²‚Æ‚É’e‚ğ”­Ë‚·‚é
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            _currentTime = 0;
            SummonEnemyBarrette();
        }

         void SummonEnemyBarrette()
        {
            //“G‚ÌÀ•W‚ğ•Ï”position‚É•Û‘¶
            var position = this.gameObject.transform.position;
            //’e‚ÌƒvƒŒƒnƒu‚ğì¬
            var t = Instantiate(EnemyBarrett) as GameObject;
            //’e‚ÌƒvƒŒƒnƒu‚ÌˆÊ’u‚ğ“G‚ÌˆÊ’u‚É‚·‚é
            t.transform.position = position;
        }
    }
}