using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int score, ballCounter=10, specialBallCount=3, lastLevelScore=0, level;

    public Text BallCounter,ScoreText;
    public GameObject NextLevel, Info, GameEnd;

    // Start is called before the first frame update
    void Start()
    {
        level = LevelEnd.level;
        lastLevelScore = PlayerPrefs.GetInt("level" + (LevelEnd.level - 1f) + "Score");


        ballCounter = 10 + lastLevelScore/3;

        BallCounter.text = "Top sayisi:" + ballCounter.ToString();
        ScoreText.text = "Skor:" + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        BallCounter.text = "Top sayisi:" + ballCounter.ToString();
        ScoreText.text = "Skor:" + score.ToString();

        if (ballCounter == 0 && Ball.isDisabled && level <10)
        {
            Info.SetActive(false);
            Time.timeScale = 0f;
            NextLevel.SetActive(true);
            PlayerPrefs.SetInt("level" + LevelEnd.level+"Score", score);
        }
        if( ballCounter==0 && Ball.isDisabled && level== 10)
        {
            PlayerPrefs.SetInt("level" + LevelEnd.level + "Score", score);
            Info.SetActive(false);
            Time.timeScale = 0f;
            GameEnd.SetActive(true);
        }

    }

}
