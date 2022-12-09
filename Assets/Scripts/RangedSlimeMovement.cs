using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlimeMovement : MonoBehaviour
{
    public SlimeController slime;
    public Movement playerScript;
    private GameObject player;
    private Transform target;
    private bool inRange = false;
    private float _SPEED = .050f;
    private float attackTimer = 1.0f;
    public Animator animator;
    public GameObject slimeball;
    public Transform slimeballPoint;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Movement>(); //Gets the player script component to get take damage
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        attackTimer = attackTimer - Time.deltaTime;

        Vector3 localPos = transform.InverseTransformPoint(target.transform.position);  //to see if player is to the
        slimeballPoint.LookAt(target);
        slimeballPoint.rotation *= Quaternion.Euler(0,-90,0);  

        if (localPos.x < 0.0f)                                                          //left of slime
            gameObject.GetComponent<SpriteRenderer>().flipX = false;                     //face sprite left 
        else if (localPos.x > 0.0f)                                                     //right of slime 
            gameObject.GetComponent<SpriteRenderer>().flipX = true;                    //face sprite right
        
        if(slime.getHealth() <= 0)
        {
            zeroSpeed();
        }
        
    }

    void FixedUpdate()
    {
        if (inRange == false)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _SPEED);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            {
                if (animator.GetBool("Moving") == true)
                {
                    zeroSpeed();
                    animator.SetBool("Moving", false);
                    var ball = Instantiate(slimeball, transform.position, slimeballPoint.rotation);
                }
                else if (animator.GetBool("Moving") == false)
                {
                    _SPEED = .050f;
                    animator.SetBool("Moving", true);
                }
            }
        }
        else if (inRange == true)
        {
            if (attackTimer <= 0f) //enemy attack cooldown
            {
                playerScript.takeDamage(1);
                attackTimer = 1.0f;
            }

        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

     void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            inRange = false;
        }
    }

    public void zeroSpeed()
    {
        _SPEED = 0;
    }
}
