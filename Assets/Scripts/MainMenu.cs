using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Victory;
    public GameObject HowToPlayMenu;
    public GameObject Main_Menu;
    public GameObject AllMainMenu;
    
    // public GameObject BackButton;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("game quit!");
    }

    public void GameLost()
    {
        Main_Menu.SetActive(false);
        GameOver.SetActive(true);
    }
    
    public void GameWon()
    {
        Main_Menu.SetActive(false);
        Victory.SetActive(true);
    }

    public void HowToPlayButton()
    {
        AllMainMenu.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }

    public void GoBack()
    {
        AllMainMenu.SetActive(true);
        HowToPlayMenu.SetActive(false);
    }
}
