using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    private Health _currentHealth;

    private void Start()
    {
        _currentHealth = new Health(_health);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = _currentHealth.DecreaseHealth(damage);

        if (_currentHealth.GetHealth() <= 0)
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        _currentHealth = _currentHealth.IncreaseHealth(amount);
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
