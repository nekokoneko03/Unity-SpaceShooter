using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[RequireComponent(typeof(BulletMover))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private IOnHit _onHitEffect;
    [SerializeField] private BulletMoveSO _move;

    [SerializeField] private BulletMover _mover;

    private BulletStats _stats;
    private GameObject _target;

    private int _hitCount;

    private float _stopTimer;
    private float _resumeMoveTimer;

    public void InitializeBullet(GameObject target, BulletStats stats)
    {
        // _target = target;
        _stats = stats;
        _mover.SetBulletStats(stats);
        _mover.SetMove(stats.bulletMove);
        _mover.SetTarget(target);
    }

    public void SetBulletMove(BulletMoveSO bulletMove)
    {
        _move = bulletMove;
    }

    private void Awake()
    {
        _mover = GetComponent<BulletMover>();
    }

    private void Update()
    {
        _mover.DoMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            collision.GetComponent<IDamageable>().TakeDamage(_stats.bulletDamage);
            _hitCount++;

            if (_hitCount > _stats.bulletPenetration)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
