using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
  public GameObject lasers;
    public GameObject player;

    public float bulletSpeed = 2500f;
    // Start is called before the first frame update
    void Awake()
    {
     player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyUp(KeyCode.G))
      {
         GameObject instlaser = Instantiate(lasers,new Vector3(transform.position.x +1,transform.position.y + 1,transform.position.z),Quaternion.identity) as GameObject;
          Rigidbody instlaserBody = instlaser.GetComponent<Rigidbody>();
          instlaserBody.AddForce(Vector3.right * bulletSpeed);
      }
    }
}
