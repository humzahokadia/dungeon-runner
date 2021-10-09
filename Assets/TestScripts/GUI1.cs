using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GUI1 : MonoBehaviour
{

    public TextMeshProUGUI hp;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI level;
    public TextMeshProUGUI powerUp;
    public TextMeshProUGUI eDestroyed;

    public GameObject player;

    public GameObject pause;
    public static bool paused = false;

    public int highestC = 0;
    public int highestE = 0;


    public void MainMenuP(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        if(!paused){
            Time.timeScale = 0;
            pause.SetActive(true);
            paused = true;
        } else {
            pause.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //set player data saved values
        GameObject.Find("Player").GetComponent<playerdata>().enemiedeath = PlayerPrefs.GetInt("Enemies", GameObject.Find("Player").GetComponent<playerdata>().enemiedeath);
        GameObject.Find("Player").GetComponent<playerdata>().coins = PlayerPrefs.GetInt("Coins", int.Parse(player.GetComponent<playerdata>().coins.ToString()));

        //set text values
        hp.GetComponent<TextMeshProUGUI>().text = player.GetComponent<playerdata>().health.ToString();
        lives.GetComponent<TextMeshProUGUI>().text = player.GetComponent<playerdata>().life.ToString();
        coins.GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("Coins", int.Parse(player.GetComponent<playerdata>().coins.ToString()));
        
    }

    void Update()
    {
        hp.GetComponent<TextMeshProUGUI>().text = player.GetComponent<playerdata>().health.ToString();
        lives.GetComponent<TextMeshProUGUI>().text = player.GetComponent<playerdata>().life.ToString();
        
        coins.GetComponent<TextMeshProUGUI>().text = player.GetComponent<playerdata>().coins.ToString();
        PlayerPrefs.SetInt("Coins", int.Parse(player.GetComponent<playerdata>().coins.ToString()));

        if (highestC < int.Parse(player.GetComponent<playerdata>().coins.ToString()))
        {
            highestC = int.Parse(player.GetComponent<playerdata>().coins.ToString());
            PlayerPrefs.SetInt("HCoins", int.Parse(player.GetComponent<playerdata>().coins.ToString()));
        }

        eDestroyed.GetComponent<TextMeshProUGUI>().text = "" + GameObject.Find("Player").GetComponent<playerdata>().enemiedeath;
        PlayerPrefs.SetInt("Enemies", GameObject.Find("Player").GetComponent<playerdata>().enemiedeath);
        if (highestE < int.Parse(player.GetComponent<playerdata>().enemiedeath.ToString()))
        {
            highestE = int.Parse(player.GetComponent<playerdata>().enemiedeath.ToString());
            PlayerPrefs.SetInt("HEnemies", GameObject.Find("Player").GetComponent<playerdata>().enemiedeath);
        }

        if(player.GetComponent<playerdata>().teleportflag == true){
            powerUp.GetComponent<TextMeshProUGUI>().text = "Teleport";

        } else if(player.GetComponent<playerdata>().lazerflag == true){
            powerUp.GetComponent<TextMeshProUGUI>().text = "Lazer";
        } else if(player.GetComponent<playerdata>().speedflag == true){
            powerUp.GetComponent<TextMeshProUGUI>().text = "Speed";
        } else if(player.GetComponent<playerdata>().invincibilityflag == true){
            powerUp.GetComponent<TextMeshProUGUI>().text = "Invincibility";
        } else if(player.GetComponent<playerdata>().healthflag == true){
            powerUp.GetComponent<TextMeshProUGUI>().text = "Health";
        }  else {
            powerUp.GetComponent<TextMeshProUGUI>().text = "NONE";
        }


        if(int.Parse(lives.GetComponent<TextMeshProUGUI>().text) == 0){
            SceneManager.LoadScene("GameOver");
        }
    }



}
