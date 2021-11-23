using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private GameObject fow;

    [Header("HUD")]
    [SerializeField] private GameObject life1 = null;
    [SerializeField] private GameObject life2 = null;
    [SerializeField] private GameObject life3 = null;
    
    public bool inDark = false;

    // Start is called before the first frame update
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifes();
        Restart();
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

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void UpdateLifes()
    {
        int lifeCount = pl.vida;
        
        
        if(lifeCount == 3)
        {
            life3.SetActive(true);
            life2.SetActive(true);
            life1.SetActive(true);
        }
        else if(lifeCount == 2)
        {
            life3.SetActive(false);
            life2.SetActive(true);
        }
        else if(lifeCount == 1)
        {
            life2.SetActive(false);
        }
        else if(lifeCount < 1)
        {
            life1.SetActive(false);
        }

    }
}
