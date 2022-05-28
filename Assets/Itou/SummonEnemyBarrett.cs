using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemyBarrett : MonoBehaviour
{
    public GameObject EnemyBarrett;
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    [SerializeField] private BaseBurret _barret = default;

    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            _currentTime = 0;
            SummonEnemyBarrette();
        }
    }
    void SummonEnemyBarrette()
    {
        var position = this.gameObject.transform.position;
        var t = Instantiate(_barret.gameObject) as GameObject;
        t.transform.position = position;
    }
}