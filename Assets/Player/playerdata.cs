using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdata : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemiedeath = 0;
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
            GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = player.GetComponent<colliding>().m;
            teleportflag = false;
            lazerflag = false;
            speedflag = false;
            healthflag = false;
            invincibilityflag = false;
          }
          invincibilityflag = true;
          StartCoroutine(WaitThenDie());

        }
      }
    }
    // Update is called once per frame
    void Update()
    {
      if(!invincibilityflag){
        GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = player.GetComponent<colliding>().m;
            
      }
      if (health <= 0){
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            transform.position = new Vector3(0,0,0);
            cc.enabled = true;
            life = life -1;
            health = 100;
            GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = player.GetComponent<colliding>().m;
            teleportflag = false;
            lazerflag = false;
            speedflag = false;
            healthflag = false;
            invincibilityflag = false;
          }
        if(teleportflag){
          GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,255);
        
        }
       if(lazerflag){
        GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,0);
            
       }
       if(speedflag){
        GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(0,0,255);
            
       }
       if(healthflag){
        GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(0,255,0);
        StartCoroutine(WaitThenDie());   
       }
       if(invincibilityflag){
        GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,255,0);
       }
    }
   IEnumerator WaitThenDie()
   {
       yield return new WaitForSeconds(1);
       healthflag = false;
       invincibilityflag = false;
   }


}

