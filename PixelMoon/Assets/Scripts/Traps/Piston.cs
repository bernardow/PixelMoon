using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    [SerializeField] private float timerFall = 2f;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float limitY = 0f;
    [SerializeField] private GameObject realDeal = null;

    private Vector3 originalPos;
    private bool initiateTimer = false;
    private float timeSinceLastDrop = 0f;
    private bool fall = false;
    private bool hitBottom = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = realDeal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (initiateTimer)
        {
            timeSinceLastDrop += Time.deltaTime;
            
        }

        if(timeSinceLastDrop >= timerFall)
        {
            fall = true;
        }

        Smash();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            initiateTimer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            initiateTimer = false;
            timeSinceLastDrop = 0f;
        }
    }

    private void Smash()
    {
        if (fall)
        {
            initiateTimer = false;
            timeSinceLastDrop = 0f;
            realDeal.transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }

        if(realDeal.transform.position.y <= limitY)
        {
            initiateTimer = false;
            timeSinceLastDrop = 0f;
            fall = false;
            hitBottom = true;
        }

        if (hitBottom)
        {
            realDeal.transform.position += Vector3.up * speed / 2 * Time.deltaTime;
        }

        if(realDeal.transform.position.y >= originalPos.y)
        {
            hitBottom = false;
            initiateTimer = true;
        }
    }
}
