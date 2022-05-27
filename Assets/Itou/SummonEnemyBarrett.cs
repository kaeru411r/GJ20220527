using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBarrett;
    //��b���Ƃɒe��ݒu���邽�߂̂���
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    // Update is called once per frame
    void Update()
    {
        //��b�o���Ƃɒe�𔭎˂���
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            _currentTime = 0;
            SummonEnemyBarrette();
        }

         void SummonEnemyBarrette()
        {
            //�G�̍��W��ϐ�position�ɕۑ�
            var position = this.gameObject.transform.position;
            //�e�̃v���n�u���쐬
            var t = Instantiate(EnemyBarrett) as GameObject;
            //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
            t.transform.position = position;
        }
    }
}