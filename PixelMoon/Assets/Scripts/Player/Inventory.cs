using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Referencia do Player")]
    [SerializeField] private Player pl = null;
    public string current1;
    public string current2;

    [Header("Auras")]
    [SerializeField] private GameObject aura1 = null;
    [SerializeField] private GameObject aura2 = null;
    public bool select1 = false;
    public bool select2 = false;
    

    [Header("Slots")]
    [SerializeField] private GameObject slot1 = null;
    [SerializeField] private GameObject slot2 = null;

    [Header("Classe dos Itens")]
    [SerializeField] private Lampião lp;
    [SerializeField] private Medic md;
    [SerializeField] private GameObject lamp;
    [SerializeField] private GameObject medic;

    private void Start()
    {
        aura1.SetActive(true);
    }

    void Update()
    { 

        NumberSelect();
        InventoryMaster();

        if (aura1.active == true)
        {
            select1 = true;
        }
        else select1 = false;

        if (aura2.active == true)
        {
            select2 = true;
        }
        else select2 = false;
    }

    private void NumberSelect()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            aura1.SetActive(true);
            aura2.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            aura1.SetActive(false);
            aura2.SetActive(true);
        }
       
    }

    private void InventoryMaster()
    {
        


        if (pl.InventoryCheck().Count > 0 && pl.InventoryCheck().Count < 2)
        {
            var _item1 = pl.InventoryCheck()[0];
            slot1.GetComponent<Image>().enabled = true;
            if (_item1 == lp.name)
            {
                slot1.GetComponent<Image>().sprite = lp.spr;
            }
            else if (_item1 == md.name && _item1 != null)
            {
                slot1.GetComponent<Image>().sprite = md.spr;
            }

            if(pl.removed && pl.actSlot == "1")
                slot1.GetComponent<Image>().sprite = null;
        }
        else if (pl.InventoryCheck().Count > 1 && pl.InventoryCheck().Count < 3)
        {
            var _item2 = pl.InventoryCheck()[1];
            slot2.GetComponent<Image>().enabled = true;
            if (_item2 == lp.name)
            {
                slot2.GetComponent<Image>().sprite = lp.spr;
            }
            else if (_item2 == md.name && _item2 != null)
            {
                slot2.GetComponent<Image>().sprite = md.spr;
            }
            if(pl.removed && pl.actSlot == "2")
                slot2.GetComponent<Image>().sprite = null;

        }
    }
}
