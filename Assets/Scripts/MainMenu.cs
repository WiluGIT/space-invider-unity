using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject loadMenu;

    public void PlayGame()
    {
        Player.level = 0;
        Player.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();
        Player.level = data.level;
        Player.score = data.score;
        GameObject menu = GameObject.Find("Canvas1/MainMenu");
        menu.SetActive(false);

        loadMenu.SetActive(true);

        GameObject level1 = GameObject.Find("Canvas1/LoadGameMenu/Level1Button");
        GameObject level2 = GameObject.Find("Canvas1/LoadGameMenu/Level2Button");
        GameObject level3 = GameObject.Find("Canvas1/LoadGameMenu/Level3Button");

        print("Aktulany player level: " + Player.level);
        if (Player.level == 0)
        {
            level1.SetActive(true);
            level2.SetActive(false);
            level3.SetActive(false);
        }
        if (Player.level == 1)
        {
            level1.SetActive(true);
            level2.SetActive(true);
            level3.SetActive(false);
        }
        if (Player.level == 2)
        {
            level1.SetActive(true);
            level2.SetActive(true);
            level3.SetActive(true);
        }

    }
    public void LoadCertainLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Debug.Log("Level: " + Player.level);
        Debug.Log("score: " + Player.score);
        SaveSystem.SavePlayer();
        Application.Quit();
    }

}