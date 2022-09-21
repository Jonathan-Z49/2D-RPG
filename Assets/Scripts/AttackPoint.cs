using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{

    public int damage = 1;
    private bool ableAttack = false;
    public GameObject Enemy;

    private Rigidbody2D rb;
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);
    Vector3 up = new Vector3(0, 1, 0);
    Vector3 down = new Vector3(0, -1, 0);

    // Start is called before the first frame update

    void Attack()
    {
        if(ableAttack)
        {
            Debug.Log("Attacked");
            Enemy.GetComponent<EnemyController>().takeDamage(damage);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.position = transform.parent.position + up;
        }
        if (Input.GetKeyDown("a"))
        {
            transform.position = transform.parent.position + left;
        }
        if (Input.GetKeyDown("s"))
        {
            transform.position = transform.parent.position + down;
        }
        if (Input.GetKeyDown("d"))
        {
            transform.position = transform.parent.position + right;
        }
        if(Input.GetKeyDown("f"))
        {
            Attack();
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        
        if(Other.tag == "Enemy")
        {
            ableAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.tag == "Enemy")
        {
            ableAttack = false;
        }
    }


}
