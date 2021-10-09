using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdata : MonoBehaviour
{
    // Start is called before the first frame update
    public int life = 5;
  	public int health = 100;
  	public bool teleportflag = false;
  	public bool lazerflag = false;
  	public bool speedflag = false;
  	public bool healthflag = false;
  	public bool invincibilityflag = false;
    public int coins = 0;
    GameObject player;

      void Start()
      {
          player = GameObject.Find("Player");
      }
    void OnControllerColliderHit(ControllerColliderHit collision)
    {
      if(invincibilityflag == false){
        if(collision.transform.tag == "Enemy")
        {
          health -= 25;
          if (health <= 0){
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            transform.position = new Vector3(0,0,0);
            cc.enabled = true;
            life = life -1;
            health = 100;
          }
          invincibilityflag = true;
          StartCoroutine(WaitThenDie());

        }
      }
    }
    // Update is called once per frame
    void Update()
    {
      if (health <= 0){
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            transform.position = new Vector3(0,0,0);
            cc.enabled = true;
            life = life -1;
            health = 100;
          }
    }
   IEnumerator WaitThenDie()
   {
       yield return new WaitForSeconds(1);
       invincibilityflag = false;
   }
}

