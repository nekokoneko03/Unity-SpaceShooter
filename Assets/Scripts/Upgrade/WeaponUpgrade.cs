using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponUpgrade : Upgrade_Base
{
    public WeaponStats weaponStats;

    public override void Upgrade(GameObject target)
    {
        target.GetComponent<IWeaponUpgradeable>()?.Upgrade(weaponStats);
    }
}
