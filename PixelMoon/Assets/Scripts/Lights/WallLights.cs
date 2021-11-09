using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLights : MonoBehaviour
{
    [SerializeField] private GameObject lightFrame = null;
    private Lamp lp = null;

    // Start is called before the first frame update
    void Start()
    {
        lp = FindObjectOfType<Lamp>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(lp.inLight && collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            lightFrame.SetActive(true);
        }
    }
}
