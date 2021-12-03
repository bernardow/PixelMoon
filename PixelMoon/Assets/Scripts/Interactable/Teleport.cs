using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Lever curLever;
    [SerializeField] private Transform otherTeleport;
    private GameObject target = null;
    private bool playerIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor(curLever);
    }

    private void OpenDoor(Lever atachedLever)
    {
        if(atachedLever != null)
        {
            if (atachedLever.activated)
            {
                if (target != null)
                {
                    target.transform.position = OtherDoorPos(otherTeleport);
                }
            }
        }else
        {
            if(playerIn && Input.GetKeyDown(KeyCode.E))
            {
                target.transform.position = OtherDoorPos(otherTeleport);
            }
        }
        
      
    }

    private Vector3 OtherDoorPos(Transform outPut)
    {
        var newOutput = outPut.position;
        return newOutput;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Ground"))
            target = collision.gameObject;
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            target = null;
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIn = false;
        }
    }
}
