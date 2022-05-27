using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    //プレイヤーオブジェクト
    public GameObject Player;
    //弾のプレハブオブジェクト
    public GameObject EnemyBarrett;

    //一秒ごとに弾を発射するためのもの
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    [SerializeField] private float _enemyBarrettspeed = default;
    // Update is called once per frame
    void Update()
    {
        //一秒経つごとに弾を発射する
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            _currentTime = 0;
            //敵の座標を変数posに保存
            var position = this.gameObject.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(EnemyBarrett) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = position;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector2 vector = Player.transform.position - position;
            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody2D>().velocity = vector * _enemyBarrettspeed;
        }
    }
}