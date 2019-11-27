using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {

    public GameObject target;
    public GameObject ammoHolder;

    public NavMeshAgent agent;


    public float health=30f;
    public bool healthControl = false;

    
    public float timeBtwAnim=2;
    public bool AnimController=false;

    private Animator anim;

    public bool attackController = true;

	void Start () {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update () {
        agent.SetDestination(target.transform.position);
        
        if(health <= 0f && healthControl == false)
        {
            healthControl = true;
            Die();
            anim.SetBool("isDeath",true);
            anim.SetBool("isDeath", true);
        }
    }

    void Die()
    {
        Invoke("DestroyZombie", 7f);
        agent.isStopped = true;
        

        int random = Random.Range(0, 10);
        {
            if (random < 4)
            {
                Instantiate(ammoHolder, new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z), Quaternion.identity);
            }
        }
    }
    
    void DestroyZombie()
    {
        Destroy(gameObject);
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            anim.SetBool("isAttack", true);
            if(attackController==true)
            {
                other.GetComponent<CharacterController>().health -= 30;
            }
            attackController = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackController = true;
            anim.SetBool("isAttack", false);
        }
    }




}
