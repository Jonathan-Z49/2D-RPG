using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float _SPEED = 7.0f;
    //private float _DIRECTION_X = 0f;
    //private float _DIRECTION_Y = 0f;
    private Rigidbody2D playerRigidBody;
    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 
        /*_DIRECTION_X = Input.GetAxisRaw("Horizontal");
        _DIRECTION_Y = Input.GetAxisRaw("Vertical");
        playerRigidBody.velocity = new Vector2(_DIRECTION_X * _SPEED, _DIRECTION_Y * _SPEED);*/
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + movement * _SPEED * Time.deltaTime);
    }
}
