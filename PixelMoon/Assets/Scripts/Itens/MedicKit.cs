using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicKit : MonoBehaviour
{
    [SerializeField] private Player pl = null;
    private int maxLife = 3;

    
    // Update is called once per frame
    void Update()
    {
        UseMedic();
    }

    private void UseMedic()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(pl.vida < maxLife)
            {
                pl.vida++;
                Destroy(gameObject);
            }
            
        }
    }
}
