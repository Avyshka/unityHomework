using UnityEngine;

public class Alive : MonoBehaviour
{
    [SerializeField] private int _health;

    public void Hurt(int damage)
    {
        _health -= damage;

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
