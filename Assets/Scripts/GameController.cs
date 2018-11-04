using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public AssetsController assetsController;
    public GridController gridController;
    public SpawnController spawnController;
    public UIController UIController;




    public static GameController instance;

    void Awake()
    {

        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Initialisation();
    }


    public void Initialisation()
    {
        assetsController.Initialisation();
        gridController.Initialisation();
        spawnController.Initialisation();
        UIController.Initialisation();
    }
}
