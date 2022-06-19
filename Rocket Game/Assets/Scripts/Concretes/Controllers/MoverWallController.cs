using System.Collections;
using System.Collections.Generic;
using RocketGame.Abstracts.Controllers;
using UnityEngine;

public class MoverWallController : WallController
{

    [SerializeField] Vector3 _direction;
    [Range(0f, 1f)]
    [SerializeField] float _factor;
    [SerializeField] float _speed = 1f;

    Vector3 _startPosition;
    const float FULL_CIRCLE = Mathf.PI * 2f;  //2piR

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Start()
    {
        transform.position = _startPosition;
    }

    private void Update()
    {
        float cycle = Time.time / _speed;
        float simWave = Mathf.Sin(cycle * FULL_CIRCLE);

        _factor = Mathf.Abs(simWave);
        Vector3 offset = _direction * _factor;
        transform.position = offset + _startPosition;
    }
}
