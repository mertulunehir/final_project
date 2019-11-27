using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    public int damage;
    public bool trapController;

    public Light Plight;
    private Animator anim; 
	// Use this for initialization
	void Start () {
        damage = 100;
        trapController = false;

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && trapController == true)
        {
            
            if(Input.GetKey(KeyCode.E))
            {
                trapController = false;
                Debug.Log("asda");
                anim.SetBool("TrapController", false);
                Plight.enabled = true;
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie") && trapController == false)
        {
            trapController = true;
            anim.SetBool("TrapController", true);
            other.gameObject.GetComponent<ZombieController>().health -= damage;
            other.gameObject.GetComponent<ZombieController>().agent.speed -= 1f;

            Plight.enabled = false;


        }
    }
}
