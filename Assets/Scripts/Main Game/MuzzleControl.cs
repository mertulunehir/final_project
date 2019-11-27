using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyMuzz", 0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyMuzz()
    {
        Destroy(gameObject);
    }
}
