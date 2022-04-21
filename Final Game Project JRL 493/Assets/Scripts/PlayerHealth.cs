using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int dmg;
    public HealthBar healthBar;
    public AudioSource source;
    
    public AudioClip[] hurt;
    
    

    public GameObject deathScreen;

    public bool isDead;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        deathScreen.SetActive(false);
        isDead = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

    public void TakeDamage( int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fist")
        {
            TakeDamage(dmg);
            source.clip = hurt[Random.Range(0, hurt.Length)];
            source.Play();
        }
    }

    

   public void RestartGame()
    {
        if(currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        
    }

    
  
}
