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
    public Slider slider;
    public double i;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        Hiscore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = 7 - Holes.holes.j;
        Hs.text = "HighScore : " + Hiscore.ToString();

        if (Hiscore < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            Hiscore = PlayerPrefs.GetInt("Highscore");
        }
    }
    public void Scoring()
    {
        i = score;
        StartCoroutine(Scoreview());
        
        score += 10; ;
    }
    public void ResetScore()
    {
        score = 0;
    }
    IEnumerator Scoreview()
    {
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
        yield return new WaitForSeconds(0.1f);
        text.text = "Score : " + i.ToString();
        i = i + 1;
    }

}
