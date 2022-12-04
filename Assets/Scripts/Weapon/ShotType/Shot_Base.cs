using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shot_Base : IShot
{
    public abstract void Shot(Transform shotPoint, GameObject target, BulletStats bulletStats, WeaponStats weaponStats);
}
