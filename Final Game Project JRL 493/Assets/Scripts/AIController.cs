using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    FirstPersonMovement firstPersonMovement;
    EnemyHealth enemyHealth;
    NavMeshAgent enemyNavMesh;
    GameObject playerReference;
    Animator anim;
    public CapsuleCollider fist;

    public float speedRun;

    public float defaultSpeed;
    public float slowSpeed = 2;

    public float attackRange = 1.5f;
    public float playerDamage;

    public float distance;

    public float waitTime;

    Vector3 playerPosition;
    Vector3 enemyPosition;

    
    bool ischasingPlayer;
    bool isCaught;
    bool hasAttacked;
    bool isDead;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyNavMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerReference = GameObject.FindGameObjectWithTag("Player");
        firstPersonMovement = playerReference.GetComponent<FirstPersonMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = firstPersonMovement.speed;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        enemyPosition = transform.position;
        ischasingPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerPosition, enemyPosition);
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        enemyPosition = transform.position;
        ChasingPlayer();
        Attack();
        slowDownPlayer();
        EnemyDies();
    }

    public void ChasingPlayer() {
        if (ischasingPlayer && !isDead)
        {
            anim.Play("Zombie Running");
            enemyNavMesh.speed = speedRun;
            enemyNavMesh.SetDestination(playerPosition);
        }
        

        
    }

    public void Attack()
    {
        if (distance <= attackRange && !hasAttacked && !isDead)
        {
            transform.LookAt(playerPosition);
            hasAttacked = true;
            ischasingPlayer = false;
            enemyNavMesh.speed = 0;
            StartCoroutine(ResetAttack());
        }
    }

    public void slowDownPlayer()
    {
        if (distance <= attackRange && isCaught)
        {
            firstPersonMovement.speed = slowSpeed;
        }
        else
        {
            firstPersonMovement.speed = defaultSpeed;
        }
    }

    public void enableHit()
    {
        fist.enabled = true;
    }

    public void disableHit()
    {
        fist.enabled = false;
    }

    public void EnemyDies()
    {
        StartCoroutine(Death());
    }

   
    
    IEnumerator ResetAttack()
    {
        if (hasAttacked && !isDead)
        {
            anim.Play("Zombie Attack");
            transform.LookAt(playerPosition);
            yield return new WaitForSeconds(waitTime);
            hasAttacked = false;
            anim.Play("Zombie Running");
            ischasingPlayer = true;
            enemyNavMesh.speed = speedRun;
        }
       
    }

    IEnumerator Death()
    {
        if (enemyHealth.enemyCurrentHealth <= 0)
        {
            firstPersonMovement.speed = defaultSpeed;
            isDead = true;
            anim.SetTrigger("Death");
            yield return new WaitForSeconds(3.5f);
            Destroy(gameObject);
        }
        
    }
        
        
}
