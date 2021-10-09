using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
  GameObject player;
    bool set = true;
  void Start()
  {
      player = GameObject.Find("Player");
  }
  void OnControllerColliderHit(ControllerColliderHit collision)
  {
    if (collision.gameObject.name == "Death")
    {
      CharacterController cc = player.GetComponent<CharacterController>();
      cc.enabled = false;
      transform.position = new Vector3(0, 2,0);
      cc.enabled = true;
      player.GetComponent<playerdata>().health = 100;
      player.GetComponent<playerdata>().life = player.GetComponent<playerdata>().life - 1;
      GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = player.GetComponent<colliding>().m;
      player.GetComponent<playerdata>().teleportflag = false;
      player.GetComponent<playerdata>().lazerflag = false;
      player.GetComponent<playerdata>().speedflag = false;
      player.GetComponent<playerdata>().invincibilityflag = false;
      player.GetComponent<playerdata>().healthflag = false;
    }
  }
}
