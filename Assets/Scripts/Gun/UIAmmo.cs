using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
  [SerializeField]
  private Image _image = default;

  public void Fill()
  {
    SetImageAlpha(1);
  }

  public void Empty()
  {
    SetImageAlpha(0.2f);
  }

  private void SetImageAlpha(float alpha)
  {
    if (_image)
    {
      var color = _image.color;
      _image.color = new Color(color.r, color.g, color.b, alpha);
    }
  }
}
