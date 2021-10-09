using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
      {
          Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
      }
    }
    void OnTriggerEnter(Collider collision)
    {

        Destroy(collision.gameObject);
        GameObject.Find("Player").GetComponent<playerdata>().enemiedeath++;
    }
}
