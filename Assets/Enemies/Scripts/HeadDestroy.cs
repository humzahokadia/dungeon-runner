using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDestroy : MonoBehaviour
{


  void getKilled()
  {
    //if (c.gameObject.name == "Player")
      Destroy(transform.parent.gameObject);
      GameObject.Find("Player").GetComponent<playerdata>().enemiedeath++;
  }
    // void OnControllerColliderHit(ControllerColliderHit c)
    // {
    //     Debug.Log("test");
    //     Destroy(gameObject);
    //
    // }
}
