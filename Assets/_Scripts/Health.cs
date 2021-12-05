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

    public void TakeDamage(float dmg, Collider co)
    {
        Debug.Log("take damage");
        //todo we dont need the col here
        CurrentHealth -= dmg;
    }

    private void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "Weapon")
        {
            TakeDamage(1, co);
            Destroy(co.gameObject);
        }
    }
    //private void OnCollisionEnter(Collider co)
    //{
    //    if (co.gameObject.tag == "Weapon")
    //    {
    //        TakeDamage(1, co);
    //    }
    //}
}
