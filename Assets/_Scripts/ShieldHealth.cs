using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour, IDamageable
{

    SpawnShieldImpact shield;
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
        shield = GetComponent<SpawnShieldImpact>();
        CurrentHealth = MaxHealth;
    }
    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void TakeDamage(float dmg, Collision co, Vector3 hit)
    {
        shield.OnImpact(co);
        CurrentHealth -= dmg;
        //TODO setup shield recharging. 
    }

 
    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag == "Weapon")
        {
            
            //Debug.Log("SHIELDHEALTH");
            TakeDamage(1, co, co.contacts[0].point);
        }
    }
}