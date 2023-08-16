using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
  [SerializeField]
  private LayerMask _hitableLayer = default;

  private int _damage = 1;

  private void Start()
  {
    Vector2 position = Camera.main.ScreenToWorldPoint(transform.position);
    RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, _hitableLayer);

    if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out IHitable hitable)) hitable.TakeDamage(_damage);
  }

  public void Setup(int damage)
  {
    _damage = damage;
  }

  public void Destroy()
  {
    Destroy(gameObject);
  }
}
