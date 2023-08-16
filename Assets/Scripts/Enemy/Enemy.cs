using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitable
{
  [field: SerializeField] public int MaxHealth { get; private set; } = 1;
  [field: SerializeField] public int CurrentHealth { get; private set; } = 0;

  private Action _onDead = null;

  private void Start()
  {
    CurrentHealth = MaxHealth;
  }

  public void Setup(int maxHealth,Action onDead)
  {
    MaxHealth = maxHealth;
    _onDead = onDead;
  }

  public void TakeDamage(int damageAmount)
  {
    CurrentHealth -= damageAmount;
    if (CurrentHealth <= 0) Dead();
  }

  public void Dead()
  {
    _onDead?.Invoke();
    Destroy(gameObject);
  }
}
