using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLDoor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform outPutDoor;
    [SerializeField] private Fade gm;
    private bool inRange = false;

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = OtherDoorPos(outPutDoor);
                gm.RunFade(true);
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

    private Vector3 OtherDoorPos(Transform outPut)
    {
        var newOutput = outPut.position;
        return newOutput;
    }
}
