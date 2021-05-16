using System.Collections;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _minePrefab;
    [SerializeField] private Transform _mineSpawnPlace;
    [SerializeField] private Animator _animator;

    private Inventory _inventory;

    private bool _isReloaded;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _isReloaded = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_inventory.isEnoughAmmoMines() && _isReloaded)
            {
                _inventory.removeAmmoMines();
                Instantiate(_minePrefab, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
                _animator.SetTrigger("Shoot");
                _isReloaded = false;
                StartCoroutine(StartReloaded());
            }
        }
    }

    private IEnumerator StartReloaded()
    {
        yield return new WaitForSeconds(.8f);
        _isReloaded = true;
    }
}
