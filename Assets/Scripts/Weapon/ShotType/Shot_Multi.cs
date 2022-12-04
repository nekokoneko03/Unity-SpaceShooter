using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot_Multi : Shot_Base
{
    public override void Shot(Transform shotPoint, GameObject target, BulletStats bulletStats, WeaponStats weaponStats)
    {
        float median = Mathf.Lerp(1, weaponStats.bulletCount, 0.5f);

        for (int i = 0; i < weaponStats.bulletCount; i++)
        {
            Bullet newBullet = BulletCreate.instance.CreateBullet(bulletStats.bulletPrefab, shotPoint);
            newBullet.AddComponent<Rigidbody2D>().gravityScale = 0f;

            float angle = weaponStats.bulletAngle * (median - (weaponStats.bulletCount - i));
            Vector3 angleVector = new Vector3(0, 0, angle);

            newBullet.transform.rotation = newBullet.transform.rotation * Quaternion.Euler(angleVector);
            newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.up * bulletStats.bulletSpeed;

            newBullet.SetBulletMove(bulletStats.bulletMove);
            newBullet.InitializeBullet(target, bulletStats);
        }
    }
}
