using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float dist;
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > 30 || player.transform.position.y < -10)
            Destroy(gameObject);
    }
}
