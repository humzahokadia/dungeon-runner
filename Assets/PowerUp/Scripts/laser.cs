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
    void Laser(){
      float distanceToPlayer = Vector3.Distance(Camera.main.transform.position, player.transform.position);
      Vector3 cameraPoint = Input.mousePosition;
      cameraPoint.z = distanceToPlayer;
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(cameraPoint);
      Debug.Log(mousePos.x);
      if(player.GetComponent<playerdata>().lazerflag == true){
          if(mousePos.x < player.transform.position.x){
               GameObject instlaser = Instantiate(lasers,new Vector3(transform.position.x -1,transform.position.y + 1,transform.position.z),Quaternion.identity) as GameObject;
               Rigidbody instlaserBody = instlaser.GetComponent<Rigidbody>();
               instlaserBody.AddForce(Vector3.left * bulletSpeed);
              }
          else{
              GameObject instlaser = Instantiate(lasers,new Vector3(transform.position.x +1,transform.position.y + 1,transform.position.z),Quaternion.identity) as GameObject;
              Rigidbody instlaserBody = instlaser.GetComponent<Rigidbody>();
              instlaserBody.AddForce(Vector3.right * bulletSpeed);
              }
        }
    }
    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
      {
        Laser();
      }
    }
}
