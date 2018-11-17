using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsController : MonoBehaviour {

    public GameObject[] Tetrises;



    public void Initialisation()
    {
        Tetrises = new GameObject[5];
        Tetrises = Resources.LoadAll<GameObject>("Prefabs/TetrisObj");
    }
}
