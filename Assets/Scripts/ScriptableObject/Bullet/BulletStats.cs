using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BulletStats : ScriptableObject
{
    public Bullet bulletPrefab;
    public BulletMoveSO bulletMove;
    public int bulletDamage;
    public float bulletSpeed;
    public int bulletPenetration;
    public float bulletExsitsTime;
    public float bulletStopDelay;
    public float bulletResumeMoveDelay;
    public IOnHit onHitEffect;
}
