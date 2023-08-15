using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneNameRemove : MonoBehaviour
{
  void Start()
  {
    gameObject.name = gameObject.name.Replace("(Clone)", "");
  }
}
