using UnityEngine;

public class Alive : MonoBehaviour
{
    [SerializeField] private Bar _hpBar;
    [SerializeField] private float _healthTotal;
    private float _health;

    private void Start()
    {
        _health = _healthTotal;
    }

    public void Hurt(float damage)
    {
        _health -= damage;

        if (_hpBar)
        {
            float percent = _health / _healthTotal;
            _hpBar.UpdateValue(percent);
        }
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
