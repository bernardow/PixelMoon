using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guilhotina : MonoBehaviour
{
    
    [SerializeField] private float backTo;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource sourceAudio;
    private BoxCollider2D bc2d = null;
    [SerializeField] private BoxCollider2D crateCollider = null;

    private bool goUp = false;
    private float initialX = 0f;
    private float yVector = 0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(initialX, transform.position.y, transform.position.z);

        if (goUp)
        {
            transform.position += new Vector3(0, yVector, 0) * jumpForce * Time.deltaTime;
            rb.bodyType = RigidbodyType2D.Static;

        }

        if (transform.position.y >= backTo)
        {
            sourceAudio.Play();
            goUp = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 3f;

        }

        if (rb.bodyType == RigidbodyType2D.Dynamic)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 3f;   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (transform.position.y <= backTo)
        {
        yVector = 1;
        goUp = true;
        }

        
    }

}