using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] private Enemy[] _enemyTemplates;
  [SerializeField] private float _delay = 0.78f;
  private float _lastSpawnTime = 0f;

  private List<Enemy> _spawnedEnemies = new List<Enemy>();
  private int _maxEnemyCount = 10;

  [SerializeField] private Vector2 _area = new Vector2(12, 3);

  private void Update()
  {
    if (_spawnedEnemies.Count == _maxEnemyCount || Time.time < _lastSpawnTime + _delay) return;

    var enemy = Instantiate(_enemyTemplates[0], new Vector3(Random.Range(-_area.x / 2, _area.x / 2) + 1, Random.Range(-_area.y / 2, _area.y / 2) + 1), Quaternion.identity);
    enemy.Setup(1, () => { _spawnedEnemies.Remove(enemy); });
    _spawnedEnemies.Add(enemy);

    _lastSpawnTime = Time.time;
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawWireCube(transform.position, new Vector3(_area.x, _area.y));
  }
}
