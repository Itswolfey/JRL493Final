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

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        
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
        }
    }

    public void RestartGame()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex );
        }
    }

  
}
