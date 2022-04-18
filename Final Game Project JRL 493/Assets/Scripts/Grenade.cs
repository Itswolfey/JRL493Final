using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 20f;
    public float explosionForce = 700f;
    public GameObject explosionEffect;
    AudioSource explodeSound;
    

    float countdown;

    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        explodeSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            explodeSound.Play();
            hasExploded = true;
        }

        if (hasExploded)
        {
            StartCoroutine(Remove());
        }
    }

    void Explode()
    {
        //Show Effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //Get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach(Collider nearbyObject in colliders)
        {
            //add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            
            if(rb != null)
            {
                //rb.constraints = RigidbodyConstraints.None;
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }

            //damage
            EnemyHealth killEnemy = nearbyObject.GetComponent<EnemyHealth>();
            if(killEnemy != null)
            {
                
                killEnemy.EnemyTakeDamage(100);
                Debug.Log("hitenemy");
            }
        }
        

        
       
        
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(3);
        GameObject[] removeExplosion = GameObject.FindGameObjectsWithTag("Explosion");

        for(int i = 0; i < removeExplosion.Length; i++)
        {
            Destroy(removeExplosion[i].gameObject);
        }

        Destroy(gameObject);
       
    }

    
}
