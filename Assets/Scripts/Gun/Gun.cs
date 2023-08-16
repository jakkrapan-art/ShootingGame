using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
  [SerializeField]
  private GunFire _gunFireTemplate;
  [SerializeField]
  private Canvas _gunFireHUD;
  [SerializeField]
  private UIGun _ui;

  private Magazine _magazine;
  private float _reloadTime = 1.2f;
  private bool _reloading = false;

  private void Start()
  {
    _magazine = new Magazine(5, 10);
    _ui.Setup(new UIGun.SetupParam(_magazine.MaxAmmo, _magazine.CurrentAmmo, _reloadTime));

    _magazine.SubscribeOnAmmoDecreased((usedIndex) => { _ui.SetAmmoEmpty(usedIndex); });
  }

  private void Update()
  {
    HeadingToMouse();

    if(Input.GetMouseButtonDown(0))
    {
      Fire();
    }
  }

  public void HeadingToMouse()
  {
    var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 directionToMouse = mousePosition - transform.position;
    float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
  }

  public void Fire()
  {
    if (_magazine.CurrentAmmo <= 0)
    {
      if(!_reloading) Reload();
      return;
    }

    var mousePosition = Input.mousePosition;
    if (_gunFireTemplate)
    {
      Instantiate(_gunFireTemplate, mousePosition, Quaternion.identity, _gunFireHUD.transform).Setup(1);
    }
    _magazine.DecreaseAmmo();
  }

  public void Reload()
  {
    StartCoroutine(DoReload());
  }

  private IEnumerator DoReload()
  {
    _reloading = true;
    Debug.Log("Reloading");
    yield return new WaitForSeconds(_reloadTime);

    _magazine.Reload();
    _ui.ReloadAmmo();
    _reloading = false;
    Debug.Log("Reload successfully.");
  }
}
