using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine
{
  public int CurrentAmmo { get; private set; }
  public int MaxAmmo { get; private set; }

  public Magazine(int initialAmmo, int maxAmmo)
  {
    CurrentAmmo = initialAmmo;
    MaxAmmo = maxAmmo;
  }

  public void DecreaseAmmo()
  {
    CurrentAmmo--;
  }

  public void Reload()
  {
    CurrentAmmo = MaxAmmo;
  }
}
