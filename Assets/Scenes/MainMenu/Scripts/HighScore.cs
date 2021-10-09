using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI coins;
    public TextMeshProUGUI eDestroyed;
    public TextMeshProUGUI Hcoins;
    public TextMeshProUGUI HeDestroyed;


    // Start is called before the first frame update
    void Update()
    {
        coins.GetComponent<TextMeshProUGUI>().text          = "" + PlayerPrefs.GetInt("Coins", 0);
        eDestroyed.GetComponent<TextMeshProUGUI>().text     = "" + PlayerPrefs.GetInt("Enemies", 0);
        Hcoins.GetComponent<TextMeshProUGUI>().text         = "" + PlayerPrefs.GetInt("HEnemies", 0);
        HeDestroyed.GetComponent<TextMeshProUGUI>().text    = "" + PlayerPrefs.GetInt("HCoins", 0);
    }

    public void MainMenuP(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Reset(){
        PlayerPrefs.SetInt("Enemies", 0);
        PlayerPrefs.SetInt("Coins", 0);
    }

}
