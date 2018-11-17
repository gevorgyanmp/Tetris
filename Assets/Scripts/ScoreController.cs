using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public int CurScore ;
    public int HiScore ;

    public void IncreaseScore()
    {
        CurScore += 10;
        GameController.Instance.UiController.curScore.text = "Score: " + CurScore.ToString();
    }

    public void CheckHiScore()
    {
        if(CurScore > HiScore || HiScore == 0)
        {
            PlayerPrefs.SetInt("HiScore", CurScore);
            HiScore = CurScore;
        }
    }



    public void Initialisation()
    {
        CurScore = 0;
        HiScore = PlayerPrefs.GetInt("HiScore");
    }


}
