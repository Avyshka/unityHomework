using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _ammoMines = 0;

    public bool isEnoughAmmoMines()
    {
        return _ammoMines > 0;
    }

    public void removeAmmoMines()
    {
        if (_ammoMines > 0)
        {
            _ammoMines--;
            Debug.Log("Ammo mines: " + _ammoMines);
        }
    }

    public void addAmmoMines(int count)
    {
        _ammoMines += count;
        Debug.Log("Ammo mines: " + _ammoMines);
    }
}
