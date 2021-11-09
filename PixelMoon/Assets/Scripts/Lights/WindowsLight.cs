using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsLight : MonoBehaviour
{
    private Lamp lp;

    // Start is called before the first frame update
    void Start()
    {
        lp = FindObjectOfType<Lamp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            lp.inLight = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            lp.inLight = false;
    }
}
