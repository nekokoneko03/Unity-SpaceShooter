using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot_Single : Shot_Base
{
    public override void Shot(Transform shotPoint, GameObject target, BulletStats bulletStats, WeaponStats weaponStats)
    {
        Bullet newBullet = BulletCreate.instance.CreateBullet(bulletStats.bulletPrefab, shotPoint);
        newBullet.AddComponent<Rigidbody2D>().gravityScale = 0f;
        newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.up * bulletStats.bulletSpeed;

        newBullet.SetBulletMove(bulletStats.bulletMove);
        newBullet.InitializeBullet(target, bulletStats);
    }
}
