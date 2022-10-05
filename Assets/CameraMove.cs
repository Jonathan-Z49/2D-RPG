using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(5f * Time.deltaTime, 0, 0);
        if (transform.position.x >= 37.95)
        {
            transform.position = new Vector3(0,0,-10.0f);
        }
    }
}
