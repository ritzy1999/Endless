using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public static PanelManager PM;
    public GameObject Game_panel, Gameover_panel;
    // Start is called before the first frame update
    void Start()
    {
        PM = this;
        Game_panel.SetActive(true);
        Gameover_panel.SetActive(false);
    }
    
    public void GameOver()
    {
        Game_panel.SetActive(false);
        Gameover_panel.SetActive(true);
    }
    public void Retry()
    {
        Holes.holes.game = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Game_panel.SetActive(true);
        Gameover_panel.SetActive(false);
    }
}
