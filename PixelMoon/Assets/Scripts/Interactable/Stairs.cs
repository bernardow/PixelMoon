using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    private Player pl;
    public bool onStair = false;
    public bool canGoUp = false;


    private void Start()
    {
        pl = FindObjectOfType<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canGoUp = true;
            if (onStair)
            {
                pl.GetComponent<Rigidbody2D>().gravityScale = 0f;
            }
            else pl.GetComponent<Rigidbody2D>().gravityScale = 4f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canGoUp = false;
            onStair = false;
            pl.GetComponent<Rigidbody2D>().gravityScale = 4f;

        }
    }
}
