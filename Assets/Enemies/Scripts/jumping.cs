using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    public float max;
    public float min;
    public bool flag = true;

    // Update is called once per frame
    void Start()
    {
      min = transform.position.y;
      max = transform.position.y +10;
    }
    void Update()
    {
        if(flag==true)
        {
          if (transform.position.y < max)
            transform.Translate(Vector3.up * Time.deltaTime * 4);
          if (transform.position.y >= max)
          {
            //transform.Rotate(0,0, 180);
            flag = false;
          }

        }
        if(flag==false)
        {

          if (transform.position.y > min)
            transform.Translate(Vector3.down * Time.deltaTime * 4);
          if (transform.position.y <= min)
          {
            //transform.Rotate(0,0, 180);
            flag = true;
          }
        }

    }
}
