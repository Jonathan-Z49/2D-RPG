using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "MainCamera")
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10.0f);
        } else {
            transform.position = new Vector3(player.position.x, player.position.y, -30.0f);
        }

    }
}
