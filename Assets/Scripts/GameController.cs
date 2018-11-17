using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public AssetsController AssetsController;
    public GridController GridController;
    public SpawnController SpawnController;
    public UIController UiController;
    public ScoreController ScoreController;




    public static GameController Instance;

    private void Awake()
    {

        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        Initialisation();
    }


    public void Initialisation()
    {
        AssetsController.Initialisation();
        GridController.Initialisation();
        SpawnController.Initialisation();
        UiController.Initialisation();
        ScoreController.Initialisation();
    }
}
