using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _countAmmo = 10;
    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.addAmmoMines(_countAmmo);
            Destroy(gameObject);
        }
    }
}
