using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private Lamp lp;
    [SerializeField] private GameManager gm;
    public bool halfSpeedDebuff = false;

    void Update()
    {
        if ((lp.inLight && pl.crouched) || (!lp.inLight && !pl.crouched) || halfSpeedDebuff)
        {
            pl.speed = 500f;
        }
        else if(!lp.inLight && pl.crouched)
        {
            pl.speed = 400f;
        }
        else if (lp.inLight && (!pl.crouched || !lp.inLight) && !halfSpeedDebuff)
        {
            pl.speed = 700f;
        }
    }
}
