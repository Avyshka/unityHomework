using System.Collections;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _minePrefab;
    [SerializeField] private Transform _mineSpawnPlace;
    [SerializeField] private Animator _animator;

    private GameSettings _gameSettings = GameSettings.getInstance();
    private Inventory _inventory;
    private AudioSource _audioSource;
    private bool _isReloaded;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _audioSource = GetComponent<AudioSource>();
        _isReloaded = true;
    }

    private void Update()
    {
        if (_gameSettings.paused)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (_inventory.IsEnoughAmmoMines && _isReloaded)
            {
                _inventory.removeAmmoMines();
                Instantiate(_minePrefab, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
                _animator.SetTrigger("Shoot");
                _audioSource.Play();
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
