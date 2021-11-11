using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool inRange = false;
    private bool goUp = false;
    private bool goDown = false;
    [SerializeField] private float maxY = 0f;
    [SerializeField] private float minY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (transform.position.y >= maxY)
            {
                goDown = true;
                goUp = false;
            }
            if (transform.position.y <= minY)
            {
                goUp = true;
                goDown = false;
            }
        }

        if(goUp)
            transform.position += Vector3.up * Time.deltaTime;
        if(goDown)
            transform.position += Vector3.down * Time.deltaTime;

        if(transform.position.y >= maxY)
        {
            goUp = false;
        }else if(transform.position.y <= minY)
        {
            goDown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
