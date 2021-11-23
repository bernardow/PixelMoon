using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSound : MonoBehaviour
{
    [SerializeField] private string soundName = null;
    private bool inRange = false;

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
            Destroy(gameObject);
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
