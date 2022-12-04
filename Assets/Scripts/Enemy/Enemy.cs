using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(EnemyAttack), typeof(EnemyStatus))]
public class Enemy : MonoBehaviour, IDamageable
{
    private EnemyStatus _stats;
    private EnemyMovement _move;
    private EnemyAttack _attack;

    [SerializeField] private GameObject _target;

    public void TakeDamage(int damage)
    {
        _stats.TakeDamage(damage);
    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _move = GetComponent<EnemyMovement>();
        _attack = GetComponent<EnemyAttack>();
        _stats = GetComponent<EnemyStatus>();
    }

    private void Update()
    {
        _move.DoMove(_stats.GetStatus().speed);
        _move.LookPlayer(_target);
        _attack.DoShot();
    }
}
