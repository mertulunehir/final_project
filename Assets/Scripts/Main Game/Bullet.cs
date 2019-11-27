using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float force = 1000f ;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Invoke("DestroyBullet", 3f);
	}
	
	// Update is called once per frame
	void Update () {

        rb.AddForce(Vector3.forward * force * Time.deltaTime);

	}

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Zombie"))
        {
            Destroy(gameObject);
            Debug.Log("asd");
        }
    }
}
