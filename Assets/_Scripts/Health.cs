using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable


{

    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth;

    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

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

    public void TakeDamage(float dmg, Collision co, Vector3 hit)
    {
        //todo we dont need the col here
        CurrentHealth -= dmg;
    }

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag == "Weapon")
        {
            TakeDamage(1, co, co.contacts[0].point);
        }
    }
}
