using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public static Score Instance;
    public Text text;
    public Text Hs;
    public int Hiscore;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        Hiscore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {

        Hs.text = "HighScore : " + Hiscore.ToString();

        if (Hiscore < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            Hiscore = PlayerPrefs.GetInt("Highscore");
        }
    }
    public void Scoring()
    {
        for(double i=score; i<score+10.1; i+=0.0001)
        {
            text.text = "Score : " + i.ToString();
        }
        score += 10; ;
        text.text = "Score : " + score.ToString();
    }
    public void ResetScore()
    {
        score = 0;
    }

}
