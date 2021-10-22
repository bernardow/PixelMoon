using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] private float range = 0f;
    [SerializeField] private Vector2 logDirection;
    [SerializeField] private float speed = 0f;
    private bool hitTheGround = false;

    [Header("Referencias")]
    [SerializeField] private Transform castPos;
    [SerializeField] private LayerMask masks;
    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();   
    }

    private bool WoodFall(float distanceToTarget)
    {
        bool canFall = false;
        float castDist = distanceToTarget;

        Vector2 endPos = castPos.position + Vector3.down * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPos.position, endPos, masks);
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                canFall = true;
            }
            else canFall = false;
        }

        Debug.DrawLine(castPos.position, endPos);
        return canFall;
    }

    private void Attack()
    {
        if (WoodFall(range))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(logDirection * speed, ForceMode2D.Impulse);
    }
}
