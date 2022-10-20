using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myRigidBody;
    private Vector2 dir;
    private float angle;
    private float maxVelocity = 10.0f;
    private bool collided = false;
    private float despawnTime = 10.0f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime <= 0.0f)
        {
            Destroy(gameObject);
        }
        if (!collided)
        {
            myRigidBody.velocity = Vector2.ClampMagnitude(myRigidBody.velocity, maxVelocity);
            dir = myRigidBody.velocity;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
           Destroy(gameObject);
        } else {
            collided = true;
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.isKinematic = true;
        }
    }
}
