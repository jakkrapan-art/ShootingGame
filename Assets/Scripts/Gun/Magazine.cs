using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine
{
  public int CurrentAmmo { get; private set; }
  public int MaxAmmo { get; private set; }

  private Action<int> OnAmmoDecreased = null;

  public Magazine(int initialAmmo, int maxAmmo)
  {
    CurrentAmmo = initialAmmo;
    MaxAmmo = maxAmmo;
  }

  public void DecreaseAmmo()
  {
    OnAmmoDecreased?.Invoke(--CurrentAmmo);
  }

  public void Reload()
  {
    CurrentAmmo = MaxAmmo;
  }

  public void SubscribeOnAmmoDecreased(Action<int> action)
  {
    OnAmmoDecreased += action;
  }

  public void UnSubscribeOnAmmoDecreased(Action<int> action)
  {
    OnAmmoDecreased -= action;
  }
}
