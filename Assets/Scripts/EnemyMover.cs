using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private readonly float _speed = 1f;

    private Transform _needPosition;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _needPosition.position, _speed * Time.deltaTime);
    }

    public void Init(Transform position)
    {
        _needPosition = position;
    }
}
