using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private float goTo;
    [SerializeField] private Lever curLever = null;
    
    private Transform tf;
    private Vector3 inicialPos;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        inicialPos = tf.position;
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor(curLever);
    }

    private void OpenDoor(Lever atachedLever)
    {
        if (atachedLever.activated)
        {
            transform.position = new Vector3(tf.position.x, goTo, transform.position.z);
        }
        else transform.position = inicialPos;
    }
}
