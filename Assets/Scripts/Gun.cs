using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
  [SerializeField]
  private GameObject _gunFire;

  private Magazine _magazine;
  private float _reloadTime = 1.2f;
  private bool _reloading = false;

  private void Start()
  {
    _magazine = new Magazine(5, 10);
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
    var mousePosition = Input.mousePosition;
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
    var parent = transform.parent;
    if (_gunFire && parent && parent.TryGetComponent(out Canvas canvas)) Instantiate(_gunFire, mousePosition, Quaternion.identity, canvas.transform);
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
    _reloading = false;
    Debug.Log("Reload successfully.");
  }
}
