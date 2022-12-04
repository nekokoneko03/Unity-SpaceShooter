using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Weapon_Base _currentWeapon;

    private void Start()
    {
        _currentWeapon = Instantiate(_currentWeapon, this.transform);
    }

    public void DoShot()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.DoShot(this.transform);
        }
    }
}
