using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _range = 15.0f;
    [SerializeField] private float _rotationSpeed = 30.0f;
    [SerializeField] private GameObject _top;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _reloadTimeout = 1.0f;
    private float _currentTime = 0;

    private float _distance;

    private void Update()
    {
        if (_player)
        {
            _distance = Vector3.Distance(transform.position, _player.transform.position);
            if (_distance < _range)
            {
                _top.transform.LookAt(_player.transform);
                
                if (_currentTime <= 0)
                {
                    _currentTime = _reloadTimeout;
                    Instantiate(_bullet, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
                }
                else
                {
                    _currentTime -= Time.deltaTime;
                }
            }
            else
            {
                _top.transform.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed);
            }
        }
    }
}
