using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public int curScore ;
    public int hiScore ;

    public void IncreaseScore()
    {
        curScore += 10;
        GameController.instance.UIController.curScore.text = "Score: " + curScore.ToString();
    }

    public void CheckHiScore()
    {
        if(curScore > hiScore || hiScore == 0)
        {
            PlayerPrefs.SetInt("HiScore", curScore);
            hiScore = curScore;
        }
    }



    public void Initialisation()
    {
        curScore = 0;
        hiScore = PlayerPrefs.GetInt("HiScore");
    }


}
