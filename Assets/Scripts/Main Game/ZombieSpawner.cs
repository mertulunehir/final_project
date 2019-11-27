using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject zombiePrefab;
    public float spawnTime = 3f;
    private int timerInt;
    private bool spawnController = true;
    private float timer;

	// Use this for initialization
	void Start () {
	    
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timerInt = (int)timer;


        if(timerInt%spawnTime==0 && spawnController == true)
        {
            spawnController = false;
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        }
        if(timerInt%spawnTime!=0)
        {
            spawnController = true;
        }
	}


}
