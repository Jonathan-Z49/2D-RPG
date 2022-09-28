using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
 
    private GameObject player;
    private Transform target;
    private bool inRange = false;
    public int health = 3;
    private Rigidbody2D rb;
    private float _SPEED = .005f;


    public void takeDamage(int i)
    {
        health -= i;
        Debug.Log("took damage");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange == false)
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _SPEED);

        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("died");
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

}
