using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverColliders : MonoBehaviour
{
    [SerializeField] private Lever lv = null;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
            lv.timer = 50000f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
            lv.timer = 5f;
    }
}
