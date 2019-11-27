using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    
    public float moveSpeed = 2f;
    public float otherMove = 6f;

    public float health = 100;
    public Text healthText;

    public bool isMaskTaken = false;


    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        healthText.text = "Health: " + health.ToString();
    }

    void Update()
    {
        healthText.text = "Health: " + health.ToString();
        Debug.Log(health);
        transform.Rotate(0,Input.GetAxis("Mouse X")*2, 0);
        
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime*otherMove);
            anim.SetInteger("CControl", 1);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
           
            anim.SetInteger("CControl", 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * otherMove);
            anim.SetInteger("CControl", 3);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
           
            anim.SetInteger("CControl", 3);
        }

        

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
           
            anim.SetInteger("CControl", 3);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * otherMove);
            anim.SetInteger("CControl", 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.left * Time.deltaTime * otherMove);
            anim.SetInteger("CControl", 4);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
           
            anim.SetInteger("CControl", 1);
        }
        if(Input.anyKey == false)
        {
            
            anim.SetInteger("CControl", 0);
        }

     

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Mask"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isMaskTaken = true;
                Debug.Log("mask taken");
            }
        }

        if(other.CompareTag("PoisonFog"))
        {
            if(isMaskTaken==false)
            {
                health -= 1;
            }
        }
    }
}
