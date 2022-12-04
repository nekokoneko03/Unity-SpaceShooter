using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IWeaponUpgradeable
{
    [SerializeField] private Weapon_Base _initialWeapon;
    private Weapon_Base _currentWeapon;

    private void Start()
    {
        _currentWeapon = Instantiate(_initialWeapon, this.transform);
    }

    public void Attack(bool isAttack)
    {
        if (!isAttack) return;

        _currentWeapon?.DoShot(this.transform);
    }

    public void Upgrade(WeaponStats newStats)
    {
        _currentWeapon.GetComponent<IUpgradeableWeapon>()?.SetWeaponStats(newStats);
    }
}
