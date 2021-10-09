using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainBuilder2 : MonoBehaviour
{
    public Transform prefab;
    public Transform enemySpawn;
    public Transform[] enemies = new Transform[4];
    public Transform platform;
    public Transform[] powerUp = new Transform[5];
    public Transform coin;
    public float nextPosX = 0;
    public float nextPosY = 0F;
    public int cubes = 0;
    public int enemyRange = 10;
    public int nextLevel = 20;
    public int gap = 5;
    private bool set = true;
    void Start()
    {
        SpawnStart();
    }
    void SpawnStart()
    {
        //Quaternion currentRotation = new Quaternion();
        //currentRotation.eulerAngles = new Vector3(0, 0, 45);
        Quaternion currentRotation = new Quaternion();
        currentRotation.eulerAngles = new Vector3(90, 0, 0);
        Transform newo;
        newo = Instantiate(prefab, new Vector3(nextPosX, nextPosY, 0), currentRotation);
        //Instantiate(prefab, new Vector3(nextPosX, -0.5F, 0), currentRotation);
    }
    void SpawnNext()
    {

        Quaternion currentRotation = new Quaternion();
        currentRotation.eulerAngles = new Vector3(90, 0, 0);
        nextPosX = nextPosX + 1F;
        nextPosY = nextPosY -0.05F;
        Transform newo;
        newo = Instantiate(prefab, new Vector3(nextPosX, nextPosY, 0), currentRotation);
        newo.gameObject.AddComponent<Destroy>();
        if (cubes % 2 == 0)
        {
            newo = Instantiate(coin, new Vector3(nextPosX, nextPosY + 4, -5.2f), currentRotation);
            newo.gameObject.AddComponent<Destroy>();
        }
        cubes++;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == 0 && set)
        {
            //enemyRange = 10;
            // nextLevel = 20;
            gap = 5;
            nextPosX = 0;
            nextPosY = 0;
            cubes = 0;
            set = false;
        }
        if (transform.position.x > 0.1)
            set = true;
        if (cubes > enemyRange)
        {
            enemyRange += 20;
            SpawnEnemy();
            nextPosX += 10;
            
        }
        else if (cubes > nextLevel)
        {
            nextPosY += 3;
            nextPosX -= 1;
            nextLevel += 20;
            SpawnStart();
        }
        else if (cubes > 40)
        {
            SpawnEnd();
            if (transform.position.x > nextPosX + 10)
                SceneManager.LoadScene("LevelComplete2");
        }
        else if (transform.position.x > nextPosX - 10)
            SpawnNext();

        if (cubes > gap)
        {
            nextPosX += 5;
            gap += 10;
        }
    }
    public void SpawnEnemy()
    {
        Quaternion currentRotation = new Quaternion();
        currentRotation.eulerAngles = new Vector3(0, 0, 0);
        Transform newo;
        newo = Instantiate(enemySpawn, new Vector3(nextPosX + 5F, nextPosY, 0), currentRotation);
        newo.gameObject.AddComponent<Destroy>();
        newo = Instantiate(platform, new Vector3(nextPosX + 5F, nextPosY + 5, 0), Quaternion.identity);
        newo.gameObject.AddComponent<Destroy>();
        int b = (int)(UnityEngine.Random.value * enemies.Length);

        for (int a = 0; a < enemies.Length; a++)
        {
            if (a == b)
            {
                currentRotation = new Quaternion();
                if (a == 4)
                    currentRotation.eulerAngles = new Vector3(180, 90, 0);
                else if (a == 0)
                    currentRotation.eulerAngles = new Vector3(0, 180, 00);
                else
                    currentRotation.eulerAngles = new Vector3(0, 90, 0);
                newo = Instantiate(enemies[a].transform, new Vector3(nextPosX + 5F, nextPosY + 3F, 0), currentRotation);
                newo.gameObject.AddComponent<Destroy>();
            }
        }
        b = (int)(UnityEngine.Random.value * powerUp.Length);
        for (int a = 0; a < powerUp.Length; a++)
        {
            if (a == b)
            {
                currentRotation = new Quaternion();
               
                newo = Instantiate(powerUp[a].transform, new Vector3(nextPosX - 1F, nextPosY + 3F, -1), currentRotation);
                newo.gameObject.AddComponent<Destroy>();
            }
        }

        newo.gameObject.AddComponent<Destroy>();
    }
    public void SpawnEnd()
    {
        Transform newo;
        newo = Instantiate(enemySpawn, new Vector3(nextPosX + 5F, nextPosY, 0), Quaternion.identity);
        newo.gameObject.AddComponent<Destroy>();

    }
}
