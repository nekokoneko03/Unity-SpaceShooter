using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private EnemyStats _stats;
    private Health _currentHp;

    private void Start()
    {
        _currentHp = new Health(_stats.maxHp);
    }

    public EnemyStats GetStatus()
    {
        return _stats;
    }

    public void TakeDamage(int damage)
    {
        _currentHp = _currentHp.DecreaseHealth(damage);

        if (_currentHp.GetHealth() <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        foreach (var onDeathEffect in _stats.onDeathEffects)
        {
            onDeathEffect.Execute(this.gameObject);
        }

        EnemySpawnManager.instance.RemoveSpawnedEnemy(this.gameObject);
        Destroy(this.gameObject);
    }
}
