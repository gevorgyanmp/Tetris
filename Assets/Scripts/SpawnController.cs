using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Transform spawner;

    public void spawn()
    {
        int randNum = Random.Range( 0, GameController.instance.assetsController.tetrises.Length);
        Instantiate(GameController.instance.assetsController.tetrises[randNum],spawner.position, Quaternion.identity);

    }




    public void Initialisation()
    {
        spawn();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
