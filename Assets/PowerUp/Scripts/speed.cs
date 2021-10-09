using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    GameObject player;
    float speeds;
      void Start()
      {
          player = GameObject.Find("Player");
      }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<playerdata>().speedflag == true){
        	speeds = player.GetComponent<PlayerController>().speed;
        	player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().speed *2;
        }
    }
    IEnumerator WaitThenDie()
     {
         yield return new WaitForSeconds(5);
         player.GetComponent<PlayerController>().speed = speeds;  
         player.GetComponent<playerdata>().speedflag = false;      
     }
}
