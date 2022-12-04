using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponCreateBullet : MonoBehaviour
{
    public Bullet CreateBullet(Bullet bulletPrefab, Transform shooter)
    {
        Bullet newBullet = Instantiate(bulletPrefab, shooter.position, shooter.rotation);
        newBullet.AddComponent<Rigidbody2D>().gravityScale = 0f;
        return newBullet;
    }
}
