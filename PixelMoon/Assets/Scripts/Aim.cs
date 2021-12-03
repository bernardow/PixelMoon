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
    [SerializeField] private SpriteRenderer armSpRen;
    [SerializeField] private Transform rigthArm = null;
    [SerializeField] private GameObject edgeArm = null;
    private Vector3 originalArmPos;

    private bool changeEdge = false;
    private Vector2 mousePos;
    private Rigidbody2D aimRB;

    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        originalArmPos = leftArm.position;
        aimRB = GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate()
    {
        Aiming();
    }

    private void Update()
    {
        ArmDealer();
        
    }

    private void Aiming()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        aim.GetComponent<Transform>().position = mousePos;

        Vector2 lookDir = mousePos - aimRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        aimRB.rotation = angle;

        if (aimRB.rotation >= 90f || aimRB.rotation <= -90f)
        {
            armSpRen.flipY = true;
            pl.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            armSpRen.flipY = false;
            pl.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void ArmDealer()
    {
        /*if (changeEdge)
        {
            edgeArm.transform.rotation = Quaternion.FromToRotation(Vector3.down, Vector3.up);
        }
        else edgeArm.transform.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.down);*/


        if (armSpRen.flipY == true)
        {
          
            transform.position = rigthArm.position;
            changeEdge = true;
        }
        else
        {
            changeEdge = false;
            transform.position = leftArm.position;
        }
    }

}
