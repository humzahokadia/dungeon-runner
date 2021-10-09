using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserdestroy : MonoBehaviour
{
    // Start is called before the first frame update
	 int lifeTime = 2;
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
