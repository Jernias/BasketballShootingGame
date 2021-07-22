using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public GameObject gameFinished;

    private int finalScore;
    public Text finalscore;

    // Start is called before the first frame update

    private void OnEnable()
    {

        for (int i = 1; i <= 10; i++)
        {
            finalScore += PlayerPrefs.GetInt("level" + i + "Score");
        }
        finalscore.text = "Toplam Skor: " + finalScore.ToString();
    }
}
