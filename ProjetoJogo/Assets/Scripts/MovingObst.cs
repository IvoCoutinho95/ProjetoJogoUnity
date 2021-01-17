using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObst : MonoBehaviour
{
    private Vector3 startPosition;
    public float obstSpeed;

    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        if (gameObject.tag == "MovingPlatform")
        {
            if (transform.position.z <= startPosition.z)
            {
                obstSpeed = 5f;
            }
            if (transform.position.z >= startPosition.z + 10)
            {
                obstSpeed = -5f;
            }
            transform.position += new Vector3(0, 0, obstSpeed * Time.deltaTime);
        }
        if (gameObject.tag == "UpPlatform")
        {
            if (transform.position.y <= startPosition.y)
            {
                obstSpeed = 5f;
            }
            if (transform.position.y >= startPosition.y + 25)
            {
                obstSpeed = -5f;
            }
            transform.position += new Vector3(0, obstSpeed * Time.deltaTime, 0);
        }
        if (gameObject.tag == "ObstEsfera")
        {
            if (transform.position.x <= startPosition.x)
            {
                obstSpeed = 15f;
            }
            if (transform.position.x >= startPosition.x + 10)
            {
                obstSpeed = -15f;
            }
            transform.position += new Vector3(obstSpeed * Time.deltaTime, 0, 0);
        }
    }

}


