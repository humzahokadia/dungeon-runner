using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightdestroy : MonoBehaviour
{
	GameObject Knight;
	void Start()
    {
        Knight = GameObject.Find("Knight");
    }
    void getKilled()
  {
  	if(!Knight.GetComponent<flying>().flags){
    //if (c.gameObject.name == "Player")
      Destroy(transform.parent.gameObject);
  	}
  }
    // void OnControllerColliderHit(ControllerColliderHit c)
    // {
    //     Debug.Log("test");
    //     Destroy(gameObject);
    //
    // }
}
