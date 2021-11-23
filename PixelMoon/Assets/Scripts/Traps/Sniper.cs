using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    private Player pl = null;
    private bool inRange = false;
    private float tslSeen = 0f;
    [SerializeField] private float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }

    private void Shoot()
    {
        if (inRange)
        {
            tslSeen += Time.deltaTime;
        }

        if (tslSeen >= timer)
        {
            pl.vida--;
            tslSeen = 0f;
        }

        if (!inRange)
        {
            tslSeen = 0f;
        }
        
    }
}
