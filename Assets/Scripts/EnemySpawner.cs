using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _countEnemyTotal = 10;
    [SerializeField] private float _spawnTimeout = 5;

    private float _time = 0;

    private void Update()
    {
        if (_time <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, transform.rotation)
                .GetComponent<MoveTo>().setPlayer(_player);

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
