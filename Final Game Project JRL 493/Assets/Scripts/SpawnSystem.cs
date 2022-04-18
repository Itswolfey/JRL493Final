using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SpawnSystem : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public NavMeshAgent enemy;

    public GameObject[] numOfEnemies;
    
    public Text waveCounterText;

    public int waveCounter;
    public int difficultyMultiplier;
    public int enemiestoSpawn;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        waveCounter = 0;
        difficultyMultiplier = 1;
        enemiestoSpawn = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        waveCounterText.text = "Wave: " + waveCounter.ToString();
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        StartNewWave();

    }

    public void StartNewWave()
    {
        if(numOfEnemies.Length <= 0)
        {
            waveCounter += 1;

            enemiestoSpawn *= difficultyMultiplier;
            StartCoroutine(StartWave());
        }
    }

    IEnumerator StartWave()
    {
        enemyCount = 0;
        

        for(int i = 0; i < enemiestoSpawn; i++)
        {
            int randomEnemy = Random.Range(0, 3);
            int randomLocation = Random.Range(0, 5);
            Vector3 warpPosition = (spawnPoints[randomLocation].position);
            GameObject newEnemy = Instantiate(enemyPrefabs[randomEnemy], spawnPoints[6]);
            newEnemy.SetActive(false);
            newEnemy.GetComponent<NavMeshAgent>().Warp(warpPosition);
            newEnemy.SetActive(true);
            
            yield return new WaitForSeconds(3);
            
        }

        difficultyMultiplier += 1;
        yield return new WaitForSeconds(5);

        

    }
}
