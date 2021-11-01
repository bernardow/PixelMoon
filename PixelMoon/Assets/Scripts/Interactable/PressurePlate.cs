using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private LayerMask masks;
    [SerializeField] private float range = 0f;
    [SerializeField] private float yPos = 0;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressure(range))
        {
            Debug.Log(Pressure(range));
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        else if(!Pressure(range)) transform.position = originalPosition;   
    }

    private bool Pressure(float distanceToTarget)
    {
        bool goDown = false;
        float castDist = distanceToTarget;

        Vector2 endPos = transform.position + Vector3.up * castDist;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, masks);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                goDown = true;
            }
            else goDown = false;
        }

        Debug.DrawLine(transform.position, endPos);
        return goDown;
    } 
}
