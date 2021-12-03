using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTube : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] private float waitFor = 2f;
    [SerializeField] private float timer = 2f;

    [Header("Referencias")]
    [SerializeField] private GameObject steam = null;
    private GameObject smoke = null;

    private bool initiateTimer = false;
    private float timeSinceLastShoosh = 0f;
    private float timeSinceLastDeactive = 0f;
    private bool initiateSecondTimer = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        smoke = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (initiateTimer)
        {
            timeSinceLastShoosh += Time.deltaTime;
            smoke.SetActive(true);
            steam.SetActive(true);
        }

        if(timeSinceLastShoosh >= timer)
        {
            smoke.SetActive(false);
            steam.SetActive(false);
            initiateTimer = false;
            timeSinceLastShoosh = 0f;
            initiateSecondTimer = true;
        }

        if (initiateSecondTimer)
            timeSinceLastDeactive += Time.deltaTime;

        if(timeSinceLastDeactive >= waitFor)
        {
            initiateTimer = true;
            initiateSecondTimer = false;
            timeSinceLastDeactive = 0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            initiateTimer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            initiateTimer = false;
            timeSinceLastShoosh = 0f;
        }
    }
}
