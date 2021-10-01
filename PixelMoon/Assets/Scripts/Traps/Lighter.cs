using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    [SerializeField] private Transform castPoint = null;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float range = 0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Falling(range))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private bool Falling(float distanceToGround)
    {
        bool canFall = false;
        float castDis = distanceToGround;

        Vector2 endPos = castPoint.position + Vector3.down * castDis;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, mask);

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                canFall = true;
            }
            else canFall = false;
        }

        Debug.DrawLine(castPoint.position, endPos);
        return canFall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
