using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsController : MonoBehaviour {

    public GameObject[] tetrises;



    public void Initialisation()
    {
        tetrises = new GameObject[5];
        tetrises = Resources.LoadAll<GameObject>("Prefabs/TetrisObj");
    }
}
