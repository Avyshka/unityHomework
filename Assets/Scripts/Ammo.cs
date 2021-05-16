using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            //inventory.Hurt(_damage);
            Destroy(gameObject);
        }
    }
}
