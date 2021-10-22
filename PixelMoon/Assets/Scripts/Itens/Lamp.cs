using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    
    public bool inLight = false;
    
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            inLight = true;
        if (collision.gameObject.CompareTag("Snake"))
        {
            Debug.Log("LALLALA");
            collision.GetComponent<Snake>().hiden = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            inLight = false;
        if (collision.gameObject.CompareTag("Snake"))
        {
            collision.GetComponent<Snake>().hiden = true;
        }
    }
}
