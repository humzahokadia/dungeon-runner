using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Transform targetTransform;
    public GameObject[] units;
    public int level = 1;
    public int cUnit = 0;

    // Start is called before the first frame update
    void Start()
    {
        units = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            int j = Random.Range(1, (4 + level*2));
            units[i] = (GameObject) Instantiate((GameObject) Resources.Load("Unit (" + j + ")", typeof(GameObject)));
            //GameObject.Find("Unit (" + j + ")");
            
        }
        units[0].SetActive(true);
        units[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if((targetTransform.position.x) > (24 + cUnit * 50))
        {
            cUnit++;
            if (cUnit > 1)
            {
                units[cUnit-2].SetActive(false);
            } else if (cUnit < 10) 
            {
                units[cUnit + 1].SetActive(true);
                units[cUnit + 1].transform.position = new Vector3((cUnit + 1)*51, 0, 0);
                
            }
        }
    }
}
