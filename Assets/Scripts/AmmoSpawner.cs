using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _ammoPrefab;

    private GameObject _ammo;
    private bool _scheduleSpawnAmmo;

    private void Start()
    {
        CreateAmmo();
    }

    private void Update()
    {
        if (_ammo == null)
        {
            if (!_scheduleSpawnAmmo)
            {
                StartCoroutine(SpawnAmmoWithTimeout());
            }
        }
    }

    private void CreateAmmo()
    {
        _ammo = Instantiate(_ammoPrefab, _spawnPoint, true);
        _scheduleSpawnAmmo = false;
    }

    private IEnumerator SpawnAmmoWithTimeout()
    {
        _scheduleSpawnAmmo = true;
        yield return new WaitForSeconds(20);
        CreateAmmo();
    }
}
