using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private Transform armEdge;
    [SerializeField] private GameObject lamp = null;
    [SerializeField] private Transform restPoint;
    [SerializeField] private List<WallLights> lights;

    private bool isResting = false;
    private bool canCatch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canCatch)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pl.InventoryCheck().Remove("lamp");
                lamp.GetComponent<Transform>().position = restPoint.position;
            }
            if (Input.GetKeyDown(KeyCode.E) && lamp.GetComponent<Transform>().position == restPoint.position)
            {
                pl.InventoryCheck().Add("lamp");
                lamp.GetComponent<Transform>().position = armEdge.position;
            }
        }

        if(lights != null)
            LightUp();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canCatch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canCatch = false;
    }

    private void LightUp()
    {
        if (lamp.GetComponent<Transform>().position == restPoint.position)
            isResting = true;
        else isResting = false;

        foreach(WallLights light in lights)
        {
            if(isResting)
                light.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
        }
    }
}
