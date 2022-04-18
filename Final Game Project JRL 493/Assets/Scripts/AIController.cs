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
    Rigidbody rb;
    public CapsuleCollider col;
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
        
        rb = GetComponent<Rigidbody>();
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

    public void animFix()
    {
        enemyNavMesh.enabled = false;
        //col.enabled = false;
        fist.enabled = false;
        
        
    }

   
    
    IEnumerator ResetAttack()
    {
        if (hasAttacked && !isDead)
        {
            anim.SetBool("Attack", true);
            transform.LookAt(playerPosition);
            yield return new WaitForSeconds(waitTime);
            hasAttacked = false;
            anim.SetBool("Attack", false);
            anim.SetBool("Chase", true);
            ischasingPlayer = true;
            enemyNavMesh.speed = speedRun;
        }
       
    }

    IEnumerator Death()
    {
        if (enemyHealth.enemyCurrentHealth <= 0)
        {
            col.direction = 2;
            
            firstPersonMovement.speed = defaultSpeed;
            isDead = true;
            anim.SetBool("Attack", false);
            anim.SetBool("Chase", false);
            anim.SetTrigger("Death");
            yield return new WaitForSeconds(4f);
            Destroy(gameObject);
        }
        
    }
        
        
}
