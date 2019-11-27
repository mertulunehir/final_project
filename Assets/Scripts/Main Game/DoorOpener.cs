using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    private int intTimer;
    private float timer;

    public GameObject door;

    private Animator animDoor;
	// Use this for initialization
	void Start () {
        timer = 5f;

        animDoor = door.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        intTimer = (int)timer;
        

        if(intTimer <= 0)
        {
            animDoor.SetBool("isOpen", true);
        }
	}

    public void OnTriggerStay(Collider other)
    {
      if(other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                timer -= Time.deltaTime;
                
            }
        }
    }


}
