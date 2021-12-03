using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private bool initiateTimer = false;
    private float tslStep = 0f;
    private Player pl = null;
    private BoxCollider2D bc2D = null;
    [SerializeField] private MineRange mr = null;
    [SerializeField] private float timer = 3f;

    private void Start()
    {
        pl = FindObjectOfType<Player>();
        bc2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (initiateTimer)
            tslStep += Time.deltaTime;

        if(tslStep >= timer)
        {
            Kabum();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((!collision.gameObject.CompareTag("Ground")) && (!collision.gameObject.CompareTag("Damage Trap")))
            initiateTimer = true;
    }

    

    private void Kabum()
    {
        if (mr.inRange)
            pl.vida = 0;
        Destroy(gameObject);
    }
}
