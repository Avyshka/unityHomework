using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private double _range = 10;
    [SerializeField] private GameObject _player;

    private NavMeshAgent _agent;

    private double _distance;

    private readonly float _minRange = -10.0f;
    private readonly float _maxRange = 10.0f;

    private Vector3 _randomPosition = new Vector3();

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_agent && _player)
        {
            _distance = Vector3.Distance(transform.position, _player.transform.position);
            if (_distance < _range)
            {
                _agent.speed = 3.5f;
                _agent.SetDestination(_player.transform.position);
            }
            else
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    _agent.speed = 1.5f;
                    _randomPosition.Set(
                        _agent.destination.x + Random.Range(_minRange, _maxRange),
                        _agent.destination.y + Random.Range(_minRange, _maxRange),
                        _agent.destination.z + Random.Range(_minRange, _maxRange)
                    );
                    _agent.SetDestination(_randomPosition);
                }
            }
        }
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }
}
