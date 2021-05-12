using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private MoveTo _enemyPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _countEnemyTotal = 10;
    [SerializeField] private float _spawnTimeout = 5;

    private float _time = 0;

    private void Update()
    {
        if (_time <= 0)
        {
            var enemyInstance = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            enemyInstance.SetPlayer(_player);

            _time = _spawnTimeout;
            _countEnemyTotal--;
            if (_countEnemyTotal <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            _time -= Time.deltaTime;
        }
    }
}
