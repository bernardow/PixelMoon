using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [Header("Aim")]
    [SerializeField] private Camera cam = null;
    [SerializeField] private GameObject aim = null;
    [SerializeField] private Transform leftArm = null;
    [SerializeField] private Player pl = null;
    private Vector2 mousePos;
    private Rigidbody2D aimRB;

    void Start()
    {
        aimRB = GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate()
    {
        Aiming();
    }

    private void Update()
    {
        transform.position = leftArm.position;
    }

    private void Aiming()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        aim.GetComponent<Transform>().position = mousePos;

        Vector2 lookDir = mousePos - aimRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        aimRB.rotation = angle;

        if(aimRB.rotation >= 90f || aimRB.rotation <= -90f)
        {
            pl.GetComponent<SpriteRenderer>().flipX = true;
        }else pl.GetComponent<SpriteRenderer>().flipX = false;
    }
}
