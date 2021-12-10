using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private Lamp lp;
    [SerializeField] private GameManager gm;
    public bool cantMove = false;
    public bool halfSpeedDebuff = false;

    void Update()
    {
        if (((lp.inLight && pl.crouched) || (!lp.inLight && !pl.crouched) || halfSpeedDebuff) && !cantMove)
        {
            pl.speed = 500f;
        }
        else if ((!lp.inLight && pl.crouched) && !cantMove)
        {
            pl.speed = 400f;
        }
        else if ((lp.inLight && (!pl.crouched || !lp.inLight) && !halfSpeedDebuff) && !cantMove)
        {
            pl.speed = 700f;
        }
        else if (cantMove)
        {
            pl.jumpForce = 0f;
            pl.speed = 0f;
        }
        if (!cantMove)
        {
            pl.jumpForce = 500f;
        }
        
    }
}
