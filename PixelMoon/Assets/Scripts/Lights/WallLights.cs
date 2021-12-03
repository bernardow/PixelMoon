using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLights : MonoBehaviour
{
    [SerializeField] private GameObject lightFrame = null;
    
    public bool failingLight;

    private Lamp lp = null;

    // Start is called before the first frame update
    void Start()
    {
        lp = FindObjectOfType<Lamp>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        Blink();  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(lp.inLight && collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            lightFrame.SetActive(true);
        }
    }

    private void Blink()
    {
        if (failingLight)
        {
            float timer = 1f;
            timer -= Time.deltaTime;

            if (timer <= 0 && timer > -1f)
            {
                lightFrame.SetActive(false);
            }
            if(timer <= -1)
            {
                lightFrame.SetActive(true);
                timer = 1f;
            }
        } 
    }
}
