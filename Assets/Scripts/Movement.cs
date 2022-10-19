using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int coins;
    private float _SPEED = 7.0f;
    //private float _DIRECTION_X = 0f;
    //private float _DIRECTION_Y = 0f;
    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private float attackCounter;
    private bool isAttacking;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + movement * _SPEED * Time.deltaTime);
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat(("LastHmove"), Input.GetAxisRaw("Horizontal"));
            animator.SetFloat(("LastVmove"), Input.GetAxisRaw("Vertical"));
        }

    }

    void FixedUpdate()
    {
      playerRigidBody.MovePosition(playerRigidBody.position + movement * _SPEED * Time.deltaTime);
    }


    public void setSpeed(float s)
    {
        _SPEED = s;
     }

    public void addCoins(int amount)
    {
        coins += amount;
        //Debug.Log("added: " + amount + ", total: " + coins);
    }
}
