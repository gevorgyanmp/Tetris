using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject panel;
    public Text curScore, endScore, hiScore;

    public void GameOver()
    {
        GameController.Instance.ScoreController.CheckHiScore();
        endScore.text = "Your Score: " + GameController.Instance.ScoreController.CurScore.ToString();
        hiScore.text = "Hi Score: " + GameController.Instance.ScoreController.HiScore.ToString();
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartOrRestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }

    public void GoToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }


    public void Initialisation()
    {
        panel.SetActive(false);
        curScore.text = "Score: " + GameController.Instance.ScoreController.CurScore.ToString();
        
    }
}
