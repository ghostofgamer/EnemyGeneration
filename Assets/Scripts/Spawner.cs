using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Transform[] _positionSpawn;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(2f);

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _positionSpawn.Length; i++)
        {
            var enemy = Instantiate(_prefabEnemy, _positionSpawn[i]);
            var position = _positionSpawn[i].GetComponentInChildren<NeedPosition>().gameObject.transform;
            enemy.GetComponent<EnemyMover>().Init(position);
            yield return _waitForSeconds;
        }
    }
}
