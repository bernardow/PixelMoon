using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private bool inRange = false;
    private float zAxis = 0f;
    private bool goingLeft = false;
    private bool goingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        zAxis = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z > 0.4f)
        {
            
            goingRight = false;
            goingLeft = true;
        }
        if (transform.rotation.z < -0.4f)
        {
            goingLeft = false;
            goingRight = true;
        }
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            inRange = false;
    }

    private void Move()
    {
        
        if (inRange)
        {
            transform.Rotate(new Vector3(0, 0, zAxis) * (speed * Time.deltaTime));
            if (goingRight)
                zAxis = 1;
            else if (goingLeft)
                zAxis = -1;
        }
    }
}
