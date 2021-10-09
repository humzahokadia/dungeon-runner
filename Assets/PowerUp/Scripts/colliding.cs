using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliding : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject thePlayer;
    public int telenum;
    bool lt = false;
    bool it = false;
    bool st = false;
    bool pt = false;
    float speeds;
    public Color m;
    GameObject Player;
    void Start()
    {
        thePlayer = GameObject.Find("Player");
        Player = GameObject.Find("Erika_Archer_Clothes_Mesh");
        m = Player.GetComponent<SkinnedMeshRenderer>().material.color;
        speeds = thePlayer.GetComponent<PlayerController>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(thePlayer.GetComponent<playerdata>().speedflag == false)
        thePlayer.GetComponent<PlayerController>().speed = speeds;  
    }
    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "redpower")
        {
            StopCoroutine(WaitThenDie());
            Player.GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,0);
            Debug.Log("redpower");
            thePlayer.GetComponent<playerdata>().lazerflag = true;
            thePlayer.GetComponent<playerdata>().speedflag = false;
            thePlayer.GetComponent<playerdata>().healthflag = false;
            thePlayer.GetComponent<playerdata>().invincibilityflag = false;
            thePlayer.GetComponent<playerdata>().teleportflag = false;
            Destroy(collision.gameObject);   
            lt = true;
            StartCoroutine(WaitThenDie());
            lt = false;
        }
        if (collision.gameObject.tag == "bluepower")
        {
            StopCoroutine(WaitThenDie());
            Player.GetComponent<SkinnedMeshRenderer>().material.color = new Color(0,0,255);
            Debug.Log("bluepower");
            thePlayer.GetComponent<playerdata>().lazerflag = false;
            thePlayer.GetComponent<playerdata>().speedflag = true;
            thePlayer.GetComponent<playerdata>().healthflag = false;
            thePlayer.GetComponent<playerdata>().invincibilityflag = false;
            thePlayer.GetComponent<playerdata>().teleportflag = false;
            Destroy(collision.gameObject);
            st = true;
            thePlayer.GetComponent<PlayerController>().speed = thePlayer.GetComponent<PlayerController>().speed *2;
            StartCoroutine(WaitThenDie());
            st = false;
        }
        if (collision.gameObject.tag == "greenpower")
        {
            StopCoroutine(WaitThenDie());
            Player.GetComponent<SkinnedMeshRenderer>().material.color = new Color(0,255,0);
            Debug.Log("greenpower");
            thePlayer.GetComponent<playerdata>().lazerflag = false;
            thePlayer.GetComponent<playerdata>().speedflag = false;
            thePlayer.GetComponent<playerdata>().invincibilityflag = false;
            thePlayer.GetComponent<playerdata>().teleportflag = false;
            thePlayer.GetComponent<playerdata>().healthflag = true;
            Destroy(collision.gameObject);
            thePlayer.GetComponent<playerdata>().health += 100;
            pt = true;
            StartCoroutine(WaitThenDie());
            pt = false;
        }
        if (collision.gameObject.tag == "yellowpower")
        {
            StopCoroutine(WaitThenDie());
            Player.GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,255,0);
            Debug.Log("yellowpower");
            thePlayer.GetComponent<playerdata>().lazerflag = false;
            thePlayer.GetComponent<playerdata>().speedflag = false;
            thePlayer.GetComponent<playerdata>().teleportflag = false;
            thePlayer.GetComponent<playerdata>().healthflag = false;
            thePlayer.GetComponent<playerdata>().invincibilityflag = true;
            it = true;
            Destroy(collision.gameObject);
            StartCoroutine(WaitThenDie());
            it = false;
        }
        if (collision.gameObject.tag == "purplepower")
        {
            StopCoroutine(WaitThenDie());
            Player.GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,255);
            Debug.Log("purplepower");
            telenum = 5;
            thePlayer.GetComponent<playerdata>().teleportflag = true;
            thePlayer.GetComponent<playerdata>().lazerflag = false;
            thePlayer.GetComponent<playerdata>().speedflag = false;
            thePlayer.GetComponent<playerdata>().invincibilityflag = false;
            thePlayer.GetComponent<playerdata>().healthflag = false;
            Destroy(collision.gameObject);
        }
       if (collision.gameObject.tag == "coins")
        {
            Debug.Log("coins");
            Destroy(collision.gameObject);
            thePlayer.GetComponent<playerdata>().coins++;
            transform.position = new Vector3(transform.position.x, transform.position.y - 1F, transform.position.z);
        }
        
        
    }
     IEnumerator WaitThenDie()
     {
        if(lt){
         yield return new WaitForSeconds(30);
         thePlayer.GetComponent<playerdata>().lazerflag = false;
         Player.GetComponent<SkinnedMeshRenderer>().material.color = m;
        }
        if(it){
            yield return new WaitForSeconds(10);
            thePlayer.GetComponent<playerdata>().invincibilityflag = false;
            Player.GetComponent<SkinnedMeshRenderer>().material.color = m;
        }
        if(st){
             yield return new WaitForSeconds(5);
             thePlayer.GetComponent<PlayerController>().speed = speeds;  
             thePlayer.GetComponent<playerdata>().speedflag = false; 
             Player.GetComponent<SkinnedMeshRenderer>().material.color = m;
        }
        if(pt){
            yield return new WaitForSeconds(3);
            Player.GetComponent<SkinnedMeshRenderer>().material.color = m;
        }
     }
}
