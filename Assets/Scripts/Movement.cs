using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float _SPEED = 7.0f;
    //private float _DIRECTION_X = 0f;
    //private float _DIRECTION_Y = 0f;
    private Rigidbody2D playerRigidBody;
    private Animator animator;
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
}
