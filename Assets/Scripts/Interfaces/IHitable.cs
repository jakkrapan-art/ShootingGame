using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
  public void TakeDamage(int damageAmount);
  public void Dead();
}
