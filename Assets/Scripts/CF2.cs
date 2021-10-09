using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF2 : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 tempVec3 = new Vector3();
    static float max = 0;

    void LateUpdate()
    {
        
        
            max = targetTransform.position.x;

            tempVec3.x = targetTransform.position.x;
            tempVec3.y = targetTransform.position.y;
            tempVec3.z = this.transform.position.z;
            this.transform.position = tempVec3;
        

    }
}
