using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
  int lifeTime = 5;
 void Start()
 {
     StartCoroutine(WaitThenDie());
 }
 IEnumerator WaitThenDie()
 {
     yield return new WaitForSeconds(lifeTime);
     Destroy(gameObject);
 }
}
