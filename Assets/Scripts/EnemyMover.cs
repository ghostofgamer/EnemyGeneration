using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Vector3 _direction;

    private readonly float _speed = 3f;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void InitDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
