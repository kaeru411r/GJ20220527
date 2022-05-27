using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemyBarrett : MonoBehaviour
{
    public GameObject EnemyBarrett;
    //一秒ごとに弾を設置するためのもの
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    [SerializeField] private BaseBurret _barret = default;

    // Update is called once per frame
    void Update()
    {
        //一秒経つごとに弾を発射する
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            _currentTime = 0;
            SummonEnemyBarrette();
        }

         void SummonEnemyBarrette()
        {
            //敵の座標を変数positionに保存
            var position = this.gameObject.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(_barret.gameObject) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = position;
        }
    }
}