using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void AboutP(){
        SceneManager.LoadScene("About");
    }

    public void MainMenuP(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Level1P(){
        SceneManager.LoadScene("L1");
    }
    public void Level2P(){
        SceneManager.LoadScene("L2");
    }
    public void Level3P(){
        SceneManager.LoadScene("L3");
    }

    public void Level1Pre(){
        SceneManager.LoadScene("L1_prebuilt");
    }
    public void Level2Pre(){
        SceneManager.LoadScene("L2_prebuilt");
    }
    public void Level3Pre(){
        SceneManager.LoadScene("L3_prebuilt");
    }

    public void Highscores(){
        SceneManager.LoadScene("Highscores");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
