using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class EnemyAi : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;
    public float turnSpeed;
    public bool shouldRotate;

    private float timer = 0f;
    public float delayAmount;

    public AudioClip impact;
    AudioSource audioSource;

    public Transform firePoint;
    public float bulletForce = 20f;
    public GameObject enemyBulletPrefab;
    public float ShootingPeriod = 0.0f;
    public float interpolationPeriod = 0.1f;

    public LayerMask whatIsPlayer; 

    private Transform target;
    private Rigidbody2D rb;
    //private Animator anim;
    private Vector2 movement;  
    public Vector3 dir;
 
    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update(){
        //anim.SetBool("isRunning", isInChaseRange);
                        //CREATE CIRCLE         /ON THIS POSITION  //HOW BIG RADIUS  //TRIGGER
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, turnSpeed * Time.deltaTime);

        var offset = 0f; 

        if(isInChaseRange) { 
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }

        if(shouldRotate){
            //anim.SetFloat("X", dir.x);
            //anim.SetFloat("Y", dir.y);
        }



    }

    private void FixedUpdate() {
        if(isInChaseRange && !isInAttackRange) {
            MoveCharacter(movement);
        }

        if(isInAttackRange) {
            rb.velocity = Vector2.zero;
           
        }

        timer += Time.deltaTime;
        ShootingPeriod += Time.deltaTime;

        if(isInAttackRange && ShootingPeriod >= interpolationPeriod) {
            ShootingPeriod = ShootingPeriod - interpolationPeriod;
            if (timer >= delayAmount){
               Shooting(); 
                timer = 0f;
            }  

        }
        
        ShootingPeriod += UnityEngine.Time.deltaTime;

    } 

    private void MoveCharacter(Vector2 dir) {
        rb.MovePosition( (Vector2)transform.position + (dir * speed * Time.deltaTime) );
    }

    public void Shooting(){
        //Debug.Log("boom");
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        //Debug.Log(bullet);
        audioSource.PlayOneShot(impact, 0.7F);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5); // Destroy bullet instance after 5 seconds
    }

}
