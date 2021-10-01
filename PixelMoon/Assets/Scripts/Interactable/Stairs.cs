using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    [SerializeField] private Player pl = null;
    private Rigidbody2D rb = null;

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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canGoUp = false;
            onStair = false;
        }
    }
}
