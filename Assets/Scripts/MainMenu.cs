using System;
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
    public GameObject Credit;
    
    public static bool playerDied;
    public static bool playerWon;


    private void Start()
    {
        if (playerDied)
        {
            GameLost();
        }

        if (playerWon)
        {
            GameWon();
        }
    }

    public void PlayGame()
    {
        playerDied = false;
        playerWon = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        playerDied = false;
        playerWon = false;
        Application.Quit();
    }

    public void GameLost() // if player died
    {
        Main_Menu.SetActive(false);
        GameOver.SetActive(true);
    }
    
    public void GameWon() // if player kills the big zombie cube boss
    {
        Main_Menu.SetActive(false);
        Victory.SetActive(true);
    }

    public void HowToPlayButton()
    {
        GameOver.SetActive(false);
        Victory.SetActive(false);
        AllMainMenu.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }

    public void CreditButton()
    {
        GameOver.SetActive(false);
        Victory.SetActive(false);
        AllMainMenu.SetActive(false);
        Credit.SetActive(true);
    }

    public void GoBack()
    {
        // Main_Menu.SetActive(true);
        if (playerDied)
        {
            GameOver.SetActive(true);
        }

        if (playerWon)
        {
            Victory.SetActive(true);
        }
        
        AllMainMenu.SetActive(true);
        HowToPlayMenu.SetActive(false);
        Credit.SetActive(false);
    }
}
