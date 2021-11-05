using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private float deactiveRotation;
    [SerializeField] private float activeRotation;
    private bool canPress = false;
    public bool activated = false;
    public float timer = 5f;
    private float timeSinceActivated = 0f;
    private bool activateTimer = false;
   
    // Update is called once per frame
    void Update()
    {
        ActivateLever();
        if (activateTimer)
            timeSinceActivated += Time.deltaTime;
    }

    private void ActivateLever()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<AudioManager>().Play("Lever");
            activated = true;
            activateTimer = true;
            transform.rotation = Quaternion.Euler(0f, 0f, activeRotation);
        } else if(timeSinceActivated >= timer)
        {
            FindObjectOfType<AudioManager>().Play("Lever");
            activated = false;
            activateTimer = false;
            timeSinceActivated = 0f;
            transform.rotation = Quaternion.Euler(0f, 0f, deactiveRotation);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPress = false;
        }
    }
}
