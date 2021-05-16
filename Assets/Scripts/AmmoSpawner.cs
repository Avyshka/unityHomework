using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _ammoPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_ammoPrefab, _spawnPoint, true);
        }
    }
}
