using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _minePrefab;
    [SerializeField] private Transform _mineSpawnPlace;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_minePrefab, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
            _animator.SetTrigger("Shoot");
        }
    }
}
