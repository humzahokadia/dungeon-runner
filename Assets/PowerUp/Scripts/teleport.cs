using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    // Start is called before the first frame update
    
     CharacterController controller;
     GameObject thePlayer;
    void Start()
    {
        thePlayer = GameObject.Find("Player");
    }
    void move(){
        if(thePlayer.GetComponent<playerdata>().teleportflag == true){
            GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,255);
        	if(thePlayer.GetComponent<colliding>().telenum > 0){
                GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,255);
        		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast (ray, out hit)) {
                	Vector3 mousepos = hit.point;
    		    	CharacterController cc = thePlayer.GetComponent<CharacterController>();
    		    	 Debug.Log(thePlayer.transform.position);
    		    	 cc.enabled = false;
    		    	 thePlayer.transform.localPosition = new Vector3(mousepos.x,mousepos.y,0);
    		    	 cc.enabled = true;
    		    	 thePlayer.GetComponent<colliding>().telenum--;
    		    }
        	}
            else{
                thePlayer.GetComponent<playerdata>().teleportflag = false;
                GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = thePlayer.GetComponent<colliding>().m;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(thePlayer.GetComponent<playerdata>().teleportflag == true){
            GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,255);
        }
    	if(Input.GetMouseButtonDown(0))
        {
	            move();
        }
        if(thePlayer.GetComponent<colliding>().telenum == 0){
            GameObject.Find("Erika_Archer_Clothes_Mesh").GetComponent<SkinnedMeshRenderer>().material.color = thePlayer.GetComponent<colliding>().m;
            thePlayer.GetComponent<playerdata>().teleportflag = false;
        }


    }
}
