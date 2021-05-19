using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 10;
    [SerializeField] private ParticleSystem _explosionPrefab;
    private Rigidbody _rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Alive>();
        if (enemy != null)
        {
            enemy.Hurt(_damage);
            Destroy(gameObject);
            var explosion =  Instantiate(_explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            explosion.Play();
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y > 0) {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else if (_rigidbody.useGravity)
        {
            _rigidbody.Sleep();
            Destroy(gameObject, 4.0f);
        }
    }
}
