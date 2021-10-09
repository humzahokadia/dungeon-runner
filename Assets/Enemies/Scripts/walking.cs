using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
  public float max;
  public float min;
  public bool flag = true;


  void Start()
  {
    min = transform.position.x - 15;
    max = transform.position.x + 15;
  }
  void Update()
  {
    if(flag==true)
    {
      if (transform.position.x < max)
        transform.Translate(Vector3.forward * Time.deltaTime * 4);
      if (transform.position.x >= max)
      {
        transform.Rotate(0,180, 0);
        flag = false;
      }

    }
    if(flag==false)
    {

      if (transform.position.x > min)
        transform.Translate(Vector3.forward * Time.deltaTime * 4);
      if (transform.position.x <= min)
      {
        transform.Rotate(0,180, 0);
        flag = true;
      }

    }
  }
}
