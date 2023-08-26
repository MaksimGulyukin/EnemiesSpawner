using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _enemyPrefab;

    private Transform[] _points;
    private List<GameObject> _enemies = new List<GameObject>();

    private int _maxEnemiesCount = 6;
    private float _spawnInterval = 2f;
    private float _nextSpawnTime;

    private void Awake()
    {
        _points = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points[i] = _spawnPoint.GetChild(i);
        }

        _nextSpawnTime = Time.time + _spawnInterval * 2;
    }

    private void Update()
    {
        if(Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime += _spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, _points.Length);
        Transform randomSpawnPoint = _points[randomIndex];

        GameObject enemy = Instantiate(_enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        _enemies.Add(enemy);

        Vector2 spawnDirection = randomSpawnPoint.position - _spawnPoint.position;
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        enemyMove.SetMovementDirection(spawnDirection);
    }
}
