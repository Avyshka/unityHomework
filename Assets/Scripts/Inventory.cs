using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _ammoMines = 0;
    [SerializeField] private TMP_Text _labelAmmoMines;

    public bool IsEnoughAmmoMines => _ammoMines > 0;

    private void Start()
    {
        UpdateAmmoInfo();
    }

    public void removeAmmoMines()
    {
        if (_ammoMines > 0)
        {
            _ammoMines--;
            UpdateAmmoInfo();
        }
    }

    public void addAmmoMines(int count)
    {
        _ammoMines += count;
        UpdateAmmoInfo();
    }

    private void UpdateAmmoInfo()
    {
        _labelAmmoMines.text = "Mines: " + _ammoMines;
    }
}
