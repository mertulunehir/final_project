using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour {

    public Camera tpsCam;
    public float damage=10f;
    public float range=100f;
    public GameObject hitZombie;

    public GameObject muzzle;

    public Text ammoText;
    public int ammoInGun;
    public static int ammoHave;
    public bool ammoController;


	// Use this for initialization
	void Start () {
        Cursor.visible = false;

        ammoController = true;
        ammoInGun = 20;
        ammoHave = 100;

        ammoText.text = ammoInGun.ToString() + "/" + ammoHave.ToString() ;
        
	}
	
	// Update is called once per frame
	void Update () {



        ammoText.text = ammoInGun.ToString() + "/" + ammoHave.ToString();


        if (Input.GetMouseButtonDown(0) && ammoController == true)
        {
            Instantiate(muzzle, transform.position, Quaternion.identity);
            Shoot();

            if(ammoInGun > 0)
            {
                ammoInGun--;
            }
            if (ammoInGun == 0)
            {
                if(ammoHave > 0)
                {
                    
                    ammoHave -= 20;
                    ammoInGun = 20;
                }
                if(ammoHave == 0 && ammoInGun == 0)
                {
                    ammoController = false;
                }
                
            }

        }
        if(ammoHave > 0)
        {
            if(ammoHave>100)
            {
                ammoHave = 100;
            }
            ammoController = true;
        }



	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
        {
            if(hit.transform.name =="Zombie" || hit.transform.name == "Zombie(Clone)")
            {
                ZombieController zombie = hit.transform.GetComponent < ZombieController>();
                zombie.health -= 10f;
               
                
            }
        }
    }
}
