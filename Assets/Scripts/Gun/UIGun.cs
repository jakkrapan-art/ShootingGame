using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGun : MonoBehaviour
{
  private int _maxAmmo = 0;
  private float _reloadTime = 0;

  private Action _clearFillAmmo = null;

  [SerializeField]
  private UIAmmo _ammoUITemplate = default;
  [SerializeField]
  private Transform _ammoParent = default;

  private List<UIAmmo> _ammoList = new List<UIAmmo>();

  public void Setup(SetupParam param)
  {
    _maxAmmo = param.MaxAmmo;
    _reloadTime = param.ReloadTime;

    if (!_ammoParent) return;
    var filled = 0;
    for (int i = 0; i < _maxAmmo; i++)
    {
      var ammo = Instantiate(_ammoUITemplate, _ammoParent);
      if(++filled <= param.CurrentAmmo) 
      {
        ammo.Fill();
      }
      else
      {
        ammo.Empty();
      }

      _clearFillAmmo += () => ammo.Empty();
      _ammoList.Add(ammo);
    }
  }

  public void ReloadAmmo()
  {
    foreach (var ammo in _ammoList)
    {
      ammo.Fill();
    }
  }

  public void SetAmmoEmpty(int index)
  {
    var ammo = _ammoList[Mathf.Clamp(index, 0, _maxAmmo)];
    ammo.Empty();
  }

  public struct SetupParam
  {
    public int MaxAmmo { get; }
    public int CurrentAmmo { get; }
    public float ReloadTime { get; }

    public SetupParam(int maxAmmo, int currentAmmo, float reloadTime)
    {
      MaxAmmo = maxAmmo;
      ReloadTime = reloadTime;
      CurrentAmmo = currentAmmo;
    }
  }
}
