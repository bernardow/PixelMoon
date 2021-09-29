using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Transform castPoint = null;
    [SerializeField] private Player pl = null;
    public bool ledgeGrab = false; 

    private void Update()
    {
        /*if (Grab(3f))
        {

            pl.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            pl.GetComponent<Rigidbody2D>().gravityScale = 0f * Time.deltaTime;
            pl.GetComponent<Rigidbody2D>().simulated = false;
            pl.speed = 0f;
            ledgeGrab = true;
        }
        else
        {
            ledgeGrab = false;
            pl.GetComponent<Rigidbody2D>().simulated = true;
        }*/
        

    }

    private bool Grab(float distance)
    {
        bool canGrab = false;
        float castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.left * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos);

        if(hit.collider != null)
        {
            
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                canGrab = true;
                
            }
            else
                canGrab = false;
        }
        Debug.DrawLine(castPoint.position, endPos);
        return canGrab;
    }
   
}
