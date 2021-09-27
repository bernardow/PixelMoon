using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private GameManager gm;

    void Update()
    {
        if ((!gm.inDark && pl.crouched) || (gm.inDark && !pl.crouched))
        {
            pl.speed = 500f;
        }
        else if(gm.inDark && pl.crouched)
        {
            pl.speed = 400f;
        }
        else if (!gm.inDark && (!pl.crouched || gm.inDark))
        {
            pl.speed = 1000f;
        }
    }
}
