using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public Movement playerScript;
    private GameObject player;
    private Transform target;
    private bool inRange = false;
    public int health = 3;
    private Rigidbody2D rb;
    private float _SPEED = .015f;
    private float timer = 1.2f;     //timer for death animation, need to find better way of doing this
    private float attackTimer = 1.0f;
    public GameObject CoinPrefab; 

    public Animator animator;


    public void takeDamage(int i)
    {
        animator.SetTrigger("Damaged");
        health -= i;
        //Debug.Log("took damage");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Movement>(); //Gets the player script component to get take damage
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer = attackTimer - Time.deltaTime;

        Vector3 localPos = transform.InverseTransformPoint(target.transform.position);  //to see if player is to the
        if (localPos.x < 0.0f)                                                          //left of slime
            gameObject.GetComponent<SpriteRenderer>().flipX = false;                     //face sprite left 
        else if (localPos.x > 0.0f)                                                     //right of slime 
            gameObject.GetComponent<SpriteRenderer>().flipX = true;                    //face sprite right
        
        if(inRange == false)
        {
            animator.SetBool("Moving", true);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _SPEED);
        }
        else if(inRange == true)
        {
            if(attackTimer <= 0f) //enemy attack cooldown
            {
                playerScript.takeDamage(1);
                attackTimer = 1.0f;
            }
            
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if(health <= 0)
        {   
            _SPEED = 0f;
            animator.SetBool("Dead", true);
            timer = timer - Time.deltaTime;
            if(timer <= 0){
                Destroy(gameObject);
                for(int i = 3; i > 0; i--){
                    Instantiate(CoinPrefab, transform.position, Quaternion.identity);
                }
            }
            //Debug.Log("died");
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            inRange = true;
        }
        if (Other.tag == "Arrow")
        {
            takeDamage(1);
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            inRange = false;
        }
    }

    

}
