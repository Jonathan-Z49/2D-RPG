using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeball : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _SPEED = 4f;
    public Animator animator;
    private float despawnTimer = 5f;
    private float timer = .30f;
    private bool t = false;
    public Movement player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        despawnTimer -= Time.deltaTime;
        animator.SetBool("isflying", true);
        rb.velocity = transform.right * _SPEED;
        if (t == true)
        {
          timer -= Time.deltaTime;
        }
        if (despawnTimer <= 0 || timer <= 0)
        {
          Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
          animator.SetBool("impact", true);
          _SPEED = 0f;
          player.takeDamage(1);
          t = true; 
        }
        if (collision.gameObject.tag == "Terrain") 
        {
          animator.SetBool("impact", true);
          _SPEED = 0f;
          t = true; 
        }
    }
}

