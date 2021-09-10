using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable

{
    private float _currentHealth;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set 
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public float _maxHealth;

    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    public void Die()
    {
        TargetComputer.Instance.RemoveTarget(this.gameObject);
        TargetComputer.Instance.CurrentTarget = null;
        Destroy(this.gameObject);
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
    }
}
