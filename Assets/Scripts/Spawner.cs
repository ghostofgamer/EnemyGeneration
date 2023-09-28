using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Transform[] _positionSpawn;

    private Coroutine _coroutine;
    private int _countDirection = 4;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(2f);
    private readonly int _needEnemyCount = 13;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(SpawnEnemy());

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _needEnemyCount; i++)
        {
            int randomNumber = Random.Range(0, _positionSpawn.Length);
            var enemy = Instantiate(_prefabEnemy, _positionSpawn[randomNumber]);
            enemy.GetComponent<EnemyMover>().InitDirection(ChangeDirection());
            yield return _waitForSeconds;
        }
    }

    private Vector3 ChangeDirection()
    {
        switch (Random.Range(0, _countDirection))
        {
            case (int)Direction.Right:
                return Vector3.right;
            case (int)Direction.Left:
                return Vector3.left;
            case (int)Direction.Up:
                return Vector3.up;
            case (int)Direction.Down:
                return Vector3.down;
            default:
                return Vector3.zero;
        }
    }

    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
}