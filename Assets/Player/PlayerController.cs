using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed = 4;
  public float gravity = 8;
  public float jumpHeight = 10;

  Vector3 moveDir = new Vector3(0,0,0);

  CharacterController controller;
  Animator anim;

  bool flag=true;
  bool flag2=false;
  bool jumpFlag = false;
  bool moveFlag = false;
  public int jumpcounter = 0;

  void Start()
  {
    controller = GetComponent<CharacterController>();
    anim = GetComponent<Animator>();
  }
  void OnControllerColliderHit(ControllerColliderHit collision)
  {
      transform.position = new Vector3(controller.transform.position.x,controller.transform.position.y,0);

      if(collision.transform.tag == "Head")
      {
        collision.transform.SendMessage("getKilled");
      }
  }
  void Update()
  {



    if(jumpFlag == true)
    {
      anim.SetInteger ("condition_dance",0);
      if(controller.isGrounded)
      {
        anim.SetInteger("condition_jump",0);
        jumpFlag = false;
      }
    }

      if (Input.GetKey(KeyCode.Space) && jumpcounter <= 2)
      {
          //jumpcounter++;
          anim.SetInteger("condition_jump",1);
          jumpFlag = true;

          if(moveFlag == false)
            moveDir = new Vector3 (0, jumpHeight + 3, 0);
          if(jumpcounter == 1)
            moveDir = new Vector3 (0, jumpHeight + 6, 0);
      }

      if(Input.GetKeyUp(KeyCode.Space))
        jumpcounter++;

      if(controller.isGrounded)
        jumpcounter = 0;
      // if (Input.GetKeyUp(KeyCode.Space))
      // {
      //     //anim.SetInteger("condition_jump",0);
      //     //moveDir = new Vector3 (0, jumpHeight, 0);
      // }
      if(Input.GetKey(KeyCode.A))
      {
        moveFlag = true;
        if(flag == true)
        {
            transform.Rotate(0,180, 0);
            flag=false;
            flag2=true;
        }

        anim.SetInteger ("condition_left",1);

        if(jumpFlag == true)
        {
          anim.SetInteger ("condition_left",0);
          moveDir = new Vector3 (-1 * speed *0.75f, jumpHeight, 0);
          //moveDir *= speed;
        }
        else
        {
          moveDir = new Vector3 (-1, 0, 0);
          moveDir *= speed;
        }


      }
      if(Input.GetKeyUp(KeyCode.A))
      {
        moveFlag = false;
        anim.SetInteger ("condition_left",0);
        moveDir = new Vector3 (0, 0, 0);
      }
      if(Input.GetKey(KeyCode.D))
      {
        moveFlag = true;
        if(flag2 == true)
        {
          transform.Rotate(0,-180, 0);
          flag2=false;
          flag=true;
        }
        anim.SetInteger ("condition_right",1);

        if(jumpFlag == true)
        {
          anim.SetInteger ("condition_right",0);
          moveDir = new Vector3 (1*speed*0.75f, jumpHeight, 0);

        }
        else
        {
          moveDir = new Vector3 (1, 0, 0);
          moveDir *= speed;
        }
      }
      if(Input.GetKeyUp(KeyCode.D))
      {
        moveFlag = false;
        anim.SetInteger ("condition_right",0);
        moveDir = new Vector3 (0, 0, 0);

      }
      if(Input.GetKey(KeyCode.S))
      {
        anim.SetInteger ("condition_crouch",1);
      }
      if(Input.GetKeyUp(KeyCode.S))
      {
        anim.SetInteger ("condition_crouch",0);
      }


        if(moveFlag == false)
        {
          if(jumpFlag == true)
            anim.SetInteger ("condition_dance",0);
          if(Input.GetKey(KeyCode.P))
          {
            anim.SetInteger ("condition_dance",1);
          }
          if(Input.GetKeyUp(KeyCode.P))
          {
            anim.SetInteger ("condition_dance",0);
          }

      }


      moveDir.y -= gravity * Time.deltaTime;
      controller.Move(moveDir * Time.deltaTime);
    //}
  }
}
