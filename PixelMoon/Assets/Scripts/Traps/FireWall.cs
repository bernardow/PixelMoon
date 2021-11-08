using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    private Player pl = null;
    private bool playerIn = false;
    private bool initiateTimer = false;
    private float timer = 2f;
    private float timeSinceLastBite = 0f;

    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initiateTimer)
            timeSinceLastBite += Time.deltaTime;
        if (playerIn && timeSinceLastBite >= timer)
        {
            pl.vida--;
            timeSinceLastBite = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIn = true;
            if (playerIn)
            {
                initiateTimer = true;
                pl.vida--;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIn = false;
            timeSinceLastBite = 0f;
            initiateTimer = false;
        }
    }
}
