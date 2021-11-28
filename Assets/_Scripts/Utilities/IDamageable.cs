using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public void TakeDamage(float dmg, Collision co);

    void Die();
}
