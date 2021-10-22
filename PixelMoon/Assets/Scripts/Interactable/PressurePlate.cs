using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private bool active = false;
    private Vector3 deactivePos;

    // Start is called before the first frame update
    void Start()
    {
        deactivePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PressureWork();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = false;
        }
    }

    private void PressureWork()
    {
        if (active)
        {
            transform.Translate(new Vector3(0f, -1f, 0f));
        }
        else transform.position = deactivePos;
    }
}
