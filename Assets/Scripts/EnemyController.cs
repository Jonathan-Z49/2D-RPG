using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
 
    public int health = 3;
    private Rigidbody2D rb;

    public void takeDamage(int i)
    {
        health -= i;
        Debug.Log("took damage");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("died");
        }
    }
}
