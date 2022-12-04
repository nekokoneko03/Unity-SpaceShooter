using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponUpgradeable
{
    public void Upgrade(WeaponStats newStats);
}
