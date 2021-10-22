using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] private LayerMask layers;
    [SerializeField] private float range = 0f;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float limit;
    [SerializeField] private Vector3 originalPos;

    [Header("Referencias")]
    [SerializeField] private EdgeSnake es = null;
    [SerializeField] private Transform castPoint = null;
    [SerializeField] private GameObject body = null;
    private Player pl = null;

    public bool hiden = false;
    private float originalSpeed = 0f;
    private float timer = 3f;
    private float timeSinceLastBite = 0f;
    private bool canAttack = false;
    private bool initiateTimer = false;

    private void Start()
    {
        originalSpeed = speed;
        pl = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initiateTimer)
        {
            timeSinceLastBite += Time.deltaTime;
            speed = 0f;
        }

        if(timeSinceLastBite >= timer)
        {
            speed = originalSpeed;
            timeSinceLastBite = 0f;
            initiateTimer = false;
        }

        if (!hiden)
        {
            if (Attack(range))
            {
                canAttack = true;
            }
            else canAttack = false;
        }
        

        Bite();
    }

    private bool Attack(float distance)
    {
        bool canAttack = false;
        float castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.down * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, layers);

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                canAttack = true;
            }
            else canAttack = false;
        }

        Debug.DrawLine(castPoint.position, endPos);
        return canAttack;
    }

    private void Bite()
    {
        if (canAttack)
        {
            body.transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (body.transform.position.y <= limit)
        {
            if (es.EdgeBite(0.1f))
                pl.vida--;
            initiateTimer = true;
            body.transform.position = originalPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lamp"))
            hiden = true;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lamp"))
            hiden = false;
    }
}
