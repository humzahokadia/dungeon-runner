using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float thisY;
    public int mov = 1;
    public bool set = false;
    // Start is called before the first frame update
    void Start()
    {
        if (UnityEngine.Random.value > 0.5)
        {
            set = true;
            thisY = transform.position.y;
        } 
        else
            thisY = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (set)
        {
            transform.position = new Vector3(transform.position.x, (float)(transform.position.y + 0.005 * mov), transform.position.z);
            if (transform.position.y >= thisY + 2 || transform.position.y <= thisY - 2)
                mov = -mov;
        }
        else
        {
            transform.position = new Vector3((float)(transform.position.x + 0.02 * mov), transform.position.y, transform.position.z);
            if (transform.position.x >= thisY + 4 || transform.position.x <= thisY - 4)
                mov = -mov;
        }
    }
}
