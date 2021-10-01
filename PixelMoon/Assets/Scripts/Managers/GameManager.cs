using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private GameObject fow;
    public bool inDark = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FOW();

    }

    private void FOW()
    {
        if (!fow.active)
        {
            inDark = true;
        }
        else inDark = false;
    }
}
