using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public static int level = 1;
    public static bool isStarted;

    public GameObject OpenMenu, nextLevel, Info, GameRulesButton, gameRules, gameFinished;
    public Text currentlevel;

    // Start is called before the first frame update
    void Start()
    {
        if (isStarted == false)
        {
            Info.SetActive(false);
            Time.timeScale = 0f;
            GameRulesButton.SetActive(true);
            OpenMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            Info.SetActive(true);
        }

        if (PlayerPrefs.HasKey("currentLevel"))
        {
            level = PlayerPrefs.GetInt("currentLevel");
        }
        else
        {
            Save();
        }
        currentlevel.text = level.ToString()+". seviye";
    }

    public void NextLevel()
    {
        if (level < 10)
        {
            level +=1;
            Save();

            nextLevel.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
            
        }
    }

    public void Starter()
    {
        OpenMenu.SetActive(false);
        GameRulesButton.SetActive(false);
        level = PlayerPrefs.GetInt("currentLevel");
        Info.SetActive(true);
        isStarted = true;
        Time.timeScale = 1f;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("currentLevel", level);
    }
    public void GameRules()
    {
        gameRules.SetActive(true);
        OpenMenu.SetActive(false);
    }

    public void GameRulesExit()
    {
        gameRules.SetActive(false);
        OpenMenu.SetActive(true);
        GameRulesButton.SetActive(true);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        Info.SetActive(false);
        gameFinished.SetActive(false);
        Time.timeScale = 0f;
        GameRulesButton.SetActive(true);
        OpenMenu.SetActive(true);
    }
}