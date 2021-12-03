using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    private bool inRange = false;
    [SerializeField] private GameObject fireWall = null;
    [SerializeField] private GameObject teleports = null;

    void Update()
    {
        MirrorThingh();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }

    private void MirrorThingh()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            fireWall.SetActive(false);
            teleports.SetActive(true);
        }
    }
}
