using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    public static BulletCreate instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public Bullet CreateBullet(Bullet bulletPrefab)
    {
        return Instantiate(bulletPrefab);
    }

    public Bullet CreateBullet(Bullet bulletPrefab, Transform shooter)
    {
        return Instantiate(bulletPrefab, shooter.position, shooter.rotation);
    }

    public void Display()
    {
        Debug.Log("TEST");
    }
}
