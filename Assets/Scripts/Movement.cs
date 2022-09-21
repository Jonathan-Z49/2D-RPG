using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float _SPEED = 7.0f;
    private float _DIRECTION_X = 0f;
    private float _DIRECTION_Y = 0f;
    private Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _DIRECTION_X = Input.GetAxis("Horizontal");
        _DIRECTION_Y = Input.GetAxis("Vertical");
        playerRigidBody.velocity = new Vector2(_DIRECTION_X * _SPEED, _DIRECTION_Y * _SPEED);
    }
}
