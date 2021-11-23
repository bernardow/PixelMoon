using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSound : MonoBehaviour
{
    [SerializeField] private string soundName = null;
    private BoxCollider2D bc2D = null;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayEvent();
    }

    private void PlayEvent()
    {
        if (inRange)
        {
            FindObjectOfType<AudioManager>().Play(soundName);
            bc2D.enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
