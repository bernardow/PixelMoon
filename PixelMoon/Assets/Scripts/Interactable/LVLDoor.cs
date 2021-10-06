using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLDoor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform outPutDoor;
    [SerializeField] private Fade gm;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = OtherDoorPos(outPutDoor);
            gm.RunFade(true);
            
        }
    }

    private Vector3 OtherDoorPos(Transform outPut)
    {
        var newOutput = outPut.position;
        return newOutput;
    }
}
