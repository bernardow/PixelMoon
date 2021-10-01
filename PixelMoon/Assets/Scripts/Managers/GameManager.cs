using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private GameObject fow;
    [SerializeField] private GameObject fowCamera = null;
    [SerializeField] private Transform canvasPosition = null;
    public bool inDark = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FOW();
        //fowCamera.transform.position = canvasPosition.position;

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
