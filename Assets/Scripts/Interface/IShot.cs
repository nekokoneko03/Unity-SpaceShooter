using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShot
{
    public void Shot(Transform shotPoint, GameObject target, BulletStats bulletStats, WeaponStats weaponStats);
}
