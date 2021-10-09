using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seethrough : MonoBehaviour
{
    // Start is called before the first frame update
    Material m;
    void Start()
    {
    GameObject thePlayer = GameObject.Find("Erika_Archer_Clothes_Mesh");
   	m = thePlayer.GetComponent<SkinnedMeshRenderer>().material;
    thePlayer.GetComponent<SkinnedMeshRenderer>().material.color = new Color(255,0,0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
