using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth = 100;
    public float enemyCurrentHealth;
    public float damageDealt;
    public ParticleSystem blood1;
    public ParticleSystem blood2;
    public AudioSource zombieMoan;

    public AudioSource aSource;

   
    // Start is called before the first frame update
    void Start()
    {
        enemyMaxHealth = 100;
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyTakeDamage(float damage)
    {
        enemyCurrentHealth -= damageDealt;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pan")
        {
            blood1.Play();
            blood2.Play();
            Debug.Log("Hit By Pan");
            aSource.Play();
            damageDealt = Random.Range(10, 25);
            EnemyTakeDamage(damageDealt);
        }
    }

    IEnumerator ZombieSound()
    {
        yield return new WaitForSeconds(3);
        zombieMoan.Play();
    }
}
