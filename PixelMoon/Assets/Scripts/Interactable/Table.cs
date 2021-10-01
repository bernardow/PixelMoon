using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private Transform armEdge;
    [SerializeField] private GameObject lamp = null;
    [SerializeField] private Transform restPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            pl.InventoryCheck().Remove("lamp");
            lamp.GetComponent<Transform>().position = restPoint.position;
        }
        if(Input.GetKeyDown(KeyCode.E) && lamp.GetComponent<Transform>().position == restPoint.position)
        {
            pl.InventoryCheck().Add("lamp");
            lamp.GetComponent<Transform>().position = armEdge.position;
        }
    }
}
