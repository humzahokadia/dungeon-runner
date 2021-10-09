using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TerrainBuilder3 : MonoBehaviour
{
    public Transform prefab;
    public Transform enemySpawn;
    public Transform[] enemies = new Transform[4];
    public Transform platform;
    public Transform[] powerUp = new Transform[5];
    public Transform coin;
    public float nextPosX = 0;
    public float nextPosY = 0F;
    public float cX = 0.5F;
    public float cY = 0.5F;
    public float x;
    public float y;
    private float size = 3;
    public int cubes = 0;
    public int enemyRange = 10;
    public int nextLevel = 20;
    public float gap = 5;
    private Boolean set = true;
    void Start()
    {
        SpawnStart();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == 0 && set)
        {
            enemyRange = 10;
            nextLevel = 20;
            gap = 5F;
            cX = 0.5F;
            cY = 0.5F;
            nextPosX = 0;
            nextPosY = 0;
            cubes = 0;
            set = false;
        }
        if (transform.position.x > 0.1)
            set = true;
        if (cubes > enemyRange)
        {
            
            SpawnEnemy();
            nextPosX += 13;
            enemyRange += 20;
        }
        else if (cubes > nextLevel)
        {
            nextPosY -= 7;
            nextPosX -= 1;
            nextLevel += 20;
            SpawnStart();
        }
        else if (cubes > 200)
        {
            SpawnEnd();
            if (transform.position.x > nextPosX + 10)
                SceneManager.LoadScene("LevelsFinished");
        }
        else if (transform.position.x > nextPosX - 10)
        {
            if (nextPosY < -2)
                SpawnNext(UnityEngine.Random.value * 30);
            else if (nextPosY < 15)
                SpawnNext(UnityEngine.Random.value * -30);
            else
                SpawnNext(UnityEngine.Random.value * 60 - 30);
        }

        if (cubes > gap)
        {
            nextPosX += 5;
            gap += 10F;
        }

    }

    void SpawnStart()
    {
        //Quaternion currentRotation = new Quaternion();
        //currentRotation.eulerAngles = new Vector3(0, 0, 45);

        Transform newo;
        newo = Instantiate(prefab, new Vector3(nextPosX, nextPosY, 0), Quaternion.identity);
        //Instantiate(prefab, new Vector3(nextPosX, -0.5F, 0), currentRotation);
    }

    void SpawnNext(float angle)
    {

        Quaternion currentRotation = new Quaternion();
        currentRotation.eulerAngles = new Vector3(0, 0, angle);
        angle = -angle;
        //Instantiate(prefab, new Vector3(nextPos, (float) Math.Sin(angle) - 1, 0), currentRotation); 


        x = (float)(0.707 * Math.Sin(convert(angle + 45) - (Math.PI / 2)));
        y = (float)(0.707 * Math.Cos(convert(angle + 45) - (Math.PI / 2)));

        Debug.Log(x + " " + y + " " + cX + " " + cY + " " + nextPosX + " " + nextPosY);
        nextPosX = nextPosX - size * (x - cX);
        nextPosY = nextPosY - size * (y - cY);
        Transform newo;
        newo = Instantiate(prefab, new Vector3(nextPosX, nextPosY, 0), currentRotation);
        newo.gameObject.AddComponent<Destroy>();
        if (cubes % 2 == 0)
        {
            newo = Instantiate(coin, new Vector3(nextPosX, nextPosY - 1, 0), currentRotation);
            newo.gameObject.AddComponent<Destroy>();
        }
        cX = (float)(0.707 * Math.Sin(convert(angle + 45)));
        cY = (float)(0.707 * Math.Cos(convert(angle + 45)));

        cubes++;
    }
    public double convert(double a)
    {
        return (a * Math.PI) / 180;
    }
    public void SpawnEnemy()
    {
        Transform newo;
        newo = Instantiate(enemySpawn, new Vector3(nextPosX + 9F, nextPosY, 0), Quaternion.identity);
        newo.gameObject.AddComponent<Destroy>();
        newo = Instantiate(platform, new Vector3(nextPosX + 8F, nextPosY + 5, 0), Quaternion.identity);
        newo.gameObject.AddComponent<Destroy>();
        int b = (int)(UnityEngine.Random.value * enemies.Length);

        for (int a = 0; a < enemies.Length; a++)
        {
            if (a == b)
            {
                Quaternion currentRotation = new Quaternion();
                if (a == 4)
                    currentRotation.eulerAngles = new Vector3(180, 90, 0);
                else if (a == 0)
                    currentRotation.eulerAngles = new Vector3(0, 180, 00);
                else
                    currentRotation.eulerAngles = new Vector3(0, 90, 0);
                newo = Instantiate(enemies[a].transform, new Vector3(nextPosX + 8F, nextPosY + 0.5F, 0), currentRotation);
                newo.gameObject.AddComponent<Destroy>();
            }
        }
        b = (int)(UnityEngine.Random.value * powerUp.Length);
        for (int a = 0; a < powerUp.Length; a++)
        {
            if (a == b)
            {
                Quaternion currentRotation = new Quaternion();
                currentRotation.eulerAngles = new Vector3(0, 90, 0);
                newo = Instantiate(powerUp[a].transform, new Vector3(nextPosX + 10, nextPosY + 0.5F, -2.4), currentRotation);
                newo.gameObject.AddComponent<Destroy>();
            }
        }
    }
    public void SpawnEnd()
    {
        Transform newo;
        newo = Instantiate(enemySpawn, new Vector3(nextPosX + 5F, nextPosY, 0), Quaternion.identity);
        newo.gameObject.AddComponent<Destroy>();

    }
}