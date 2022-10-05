using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSelect : MonoBehaviour
{

    private float _SPEED = 7.0f;
    //private float _DIRECTION_X = 0f;
    //private float _DIRECTION_Y = 0f;
    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Vertical", -1);
        animator.SetFloat("Speed", 1);
    }

}
