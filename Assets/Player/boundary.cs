using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
  public Transform targetTransform;
  Vector3 tempVec3 = new Vector3();
  static float max = 0;

  void LateUpdate()
  {
    if(targetTransform.position.x == 0)
    {
      max = targetTransform.position.x;

      tempVec3.x = targetTransform.position.x - 20f;
      tempVec3.y = this.transform.position.y;
      tempVec3.z = this.transform.position.z;
      this.transform.position = tempVec3;
    }
    if(targetTransform.position.x < max)
    {

    }
    else
    {
      max = targetTransform.position.x;

      tempVec3.x = targetTransform.position.x - 20f;
      tempVec3.y = this.transform.position.y;
      tempVec3.z = this.transform.position.z;
      this.transform.position = tempVec3;
    }

  }
}
