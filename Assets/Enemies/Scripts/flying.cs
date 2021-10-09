using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flying : MonoBehaviour
{
  public float nextActionTime = 0.0f;
  public float period = 5f;
  public bool flags = false;
  public GameObject player;
  public Transform bomb;

  public Material mat1;
  public Material mat2;


  public GameObject i1;
  public GameObject i2;
  public GameObject i3;
  public GameObject i4;
  public GameObject i5;
  public GameObject i6;
  public GameObject i7;
  public GameObject i8;
  public GameObject i9;
  public GameObject i10;
  public GameObject i12;
  public GameObject i13;
  public GameObject i14;
  public GameObject i15;
  public GameObject i16;
  public GameObject i17;
  public GameObject i18;
  public GameObject i19;
  public GameObject i20;
  public GameObject i21;
  public GameObject i22;
  public GameObject i23;
  public GameObject i24;
  public GameObject i26;

  void Awake()
  {
    player = GameObject.Find("Player");
  }
  void immune()
  {
    i1.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i2.GetComponent<MeshRenderer>().material = mat1;
    i3.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i4.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i5.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i6.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i7.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i8.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i9.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i10.GetComponent<MeshRenderer>().material = mat1;
    i12.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i13.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i14.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i15.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i16.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i17.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i18.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i19.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i20.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i21.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i22.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i23.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i24.GetComponent<SkinnedMeshRenderer>().material = mat1;
    i26.GetComponent<SkinnedMeshRenderer>().material = mat1;
  }
  void immuneOff()
  {
    i1.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i2.GetComponent<MeshRenderer>().material = mat2;
    i3.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i4.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i5.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i6.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i7.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i8.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i9.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i10.GetComponent<MeshRenderer>().material = mat2;
    i12.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i13.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i14.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i15.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i16.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i17.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i18.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i19.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i20.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i21.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i22.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i23.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i24.GetComponent<SkinnedMeshRenderer>().material = mat2;
    i26.GetComponent<SkinnedMeshRenderer>().material = mat2;
  }
  void Start()
  {
    bomb.GetComponent<ParticleSystem>().Stop();
    immuneOff();
  }

    // Update is called once per frame
    void Update()
    {
      //bomb.GetComponent<ParticleSystem>().enableEmission = false;
      if(Mathf.Abs(player.transform.position.x - transform.position.x) <= 25)
      {
        if(Time.time > nextActionTime)
        {
          nextActionTime += period;

          transform.position = new Vector3(player.transform.position.x,player.transform.position.y+3,0);

          flags = true;
          StartCoroutine(WaitThenDie());
          //bomb.GetComponent<ParticleSystem>().Play();
        }
      }


    }

     IEnumerator WaitThenDie()
     {
        immune();
        yield return new WaitForSeconds(1);
        immuneOff();
        bomb.GetComponent<ParticleSystem>().Play();
        if(GameObject.Find("Player").GetComponent<playerdata>().invincibilityflag == false)
        {
          if(Mathf.Abs(player.transform.position.x - transform.position.x) <= 1)
          {
            player.GetComponent<playerdata>().health -= 30;
          }
          else if(Mathf.Abs(player.transform.position.x - transform.position.x) <= 2.5f)
          {
            player.GetComponent<playerdata>().health -= 20;
          }
          else if(Mathf.Abs(player.transform.position.x - transform.position.x) <= 4)
          {
            player.GetComponent<playerdata>().health -= 10;
          }
        }

        //immuneOff();


        //bomb.GetComponent<ParticleSystem>().enableEmission = true;
        flags = false;
     }
}
