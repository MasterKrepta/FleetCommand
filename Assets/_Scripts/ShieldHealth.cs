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

    public void TakeDamage(float dmg, Collider co)
    {

        shield.OnImpact2(co);
        CurrentHealth -= dmg;
        //TODO setup shield recharging. 
    }

    public void TakeDamage2(float dmg, Collider co)
    {
        shield.OnImpact2(co);
        CurrentHealth -= dmg;
        //TODO setup shield recharging. 
    }


    private void OnTriggerEnter(Collider other)
    {
        //! This is essential
        if (other.gameObject.tag == "Weapon")
        {

            //Debug.Log("SHIELDHEALTH");
            TakeDamage2(1, other);
        }
    }
    //private void OnCollisionEnter(Collider co)
    //{
    //    //! This is essential
    //    if (co.gameObject.tag == "Weapon")
    //    {

    //        //Debug.Log("SHIELDHEALTH");
    //        TakeDamage(1, co);
    //    }
    //}
}