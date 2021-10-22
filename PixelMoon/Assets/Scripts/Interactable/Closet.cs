using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    private Player pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (pl.hidden)
        {
            pl.transform.position = transform.position;
        }
        else pl.transform.position = pl.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            pl.transform.position = transform.position;   
            pl.hidden = true;
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            pl.hidden = false;
        }
    }
}
