using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maxHealth;
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
        this.gameObject.SetActive(false);
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
        //TODO setup shield recharging. 
    }

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag == "Weapon")
        {
            TakeDamage(1);
        }
    }
}