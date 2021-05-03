using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private double _range = 10;
    [SerializeField] public GameObject _player;

    private NavMeshAgent agent;

    private double _distance;

    private float minRange = -10.0f;
    private float maxRange = 10.0f;

    private Vector3 randomPosition = new Vector3();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent && _player)
        {
            _distance = Vector3.Distance(transform.position, _player.transform.position);
            if (_distance < _range)
            {
                agent.speed = 3.5f;
                agent.SetDestination(_player.transform.position);
            }
            else
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    agent.speed = 1.5f;
                    randomPosition.Set(
                        agent.destination.x + Random.Range(minRange, maxRange),
                        agent.destination.y + Random.Range(minRange, maxRange),
                        agent.destination.z + Random.Range(minRange, maxRange)
                    );
                    agent.SetDestination(randomPosition);
                }
            }
        }
    }

    public void setPlayer(GameObject player)
    {
        _player = player;
    }
}
