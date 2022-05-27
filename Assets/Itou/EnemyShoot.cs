using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    //�v���C���[�I�u�W�F�N�g
    public GameObject Player;
    //�e�̃v���n�u�I�u�W�F�N�g
    public GameObject EnemyBarrett;

    //��b���Ƃɒe�𔭎˂��邽�߂̂���
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    [SerializeField] private float _enemyBarrettspeed = default;
    // Update is called once per frame
    void Update()
    {
        //��b�o���Ƃɒe�𔭎˂���
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            _currentTime = 0;
            //�G�̍��W��ϐ�pos�ɕۑ�
            var position = this.gameObject.transform.position;
            //�e�̃v���n�u���쐬
            var t = Instantiate(EnemyBarrett) as GameObject;
            //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
            t.transform.position = position;
            //�G����v���C���[�Ɍ������x�N�g��������
            //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
            Vector2 vector = Player.transform.position - position;
            //�e��RigidBody2D�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
            t.GetComponent<Rigidbody2D>().velocity = vector * _enemyBarrettspeed;
        }
    }
}