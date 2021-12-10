using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    private Player pl = null;
    private SpeedHandler sh = null;
    private bool inRange = false;
    private Transform tf = null;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        pl = FindObjectOfType<Player>();
        sh = pl.GetComponent<SpeedHandler>();
    }

    private void Update()
    {
        if (pl.hidden)
        {
            sh.cantMove = true;
        }
        else sh.cantMove = false;

        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                pl.transform.position = tf.position;
                pl.hidden = true;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                pl.hidden = false;
            }
        }
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
}
