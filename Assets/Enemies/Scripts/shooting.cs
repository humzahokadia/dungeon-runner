using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject player;

    public float nextActionTime = 0.0f;
    public float period = 2f;

    public float bulletSpeed = 500f;

    void Awake()
    {
      player = GameObject.Find("Player");
    }
    void Update()
    {
      if(Time.time > nextActionTime)
      {
        nextActionTime += period;

        if(player.transform.position.x < transform.position.x)
        {
          GameObject instBullet = Instantiate(Bullet,transform.position,Quaternion.identity) as GameObject;
          Rigidbody instBulletBody = instBullet.GetComponent<Rigidbody>();
          instBulletBody.AddForce(Vector3.left * bulletSpeed);
        }
        if(player.transform.position.x > transform.position.x)
        {
          GameObject instBullet = Instantiate(Bullet,transform.position,Quaternion.identity) as GameObject;
          Rigidbody instBulletBody = instBullet.GetComponent<Rigidbody>();
          instBulletBody.AddForce(Vector3.right * bulletSpeed);
        }
      }

    }
}
