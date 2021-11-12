using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private GameObject fow;
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
            SceneManager.LoadScene(1);
        }
    }
}
