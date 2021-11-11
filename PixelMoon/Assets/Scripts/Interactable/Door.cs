using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite closeDoor = null;
    [SerializeField] private Sprite openDoor = null;
    [SerializeField] private Lever curLever = null;
    [SerializeField] private GameObject doorFrame = null;
    [SerializeField] private BoxCollider2D bc2D;

    private SpriteRenderer spr = null;


    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor(curLever);
    }

    private void OpenDoor(Lever atachedLever)
    {
        if (atachedLever.activated)
        {
            bc2D.isTrigger = true;
            doorFrame.SetActive(true);
            spr.sprite = openDoor;
        }
        else
        {
            bc2D.isTrigger = false;
            doorFrame.SetActive(false);
            spr.sprite = closeDoor;
        }
    }
}
