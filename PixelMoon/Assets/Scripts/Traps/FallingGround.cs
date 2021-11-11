using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    private bool initiateTimer = false;
    private float tSLTouch = 0f;
    private Rigidbody2D rb;
    [SerializeField] private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initiateTimer)
            tSLTouch += Time.deltaTime;

        if(tSLTouch >= timer)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        initiateTimer = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        initiateTimer = false;
        tSLTouch = 0f;
    }
}
