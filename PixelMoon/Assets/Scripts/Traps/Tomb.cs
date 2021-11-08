using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    [SerializeField] private Transform handPos;
    private Player player = null;
    private CircleCollider2D cc = null;
    private bool activateTimer = false;
    private bool activateCC = false;
    private float timeSinceDisable = 0f;
    private float timeSinceCatch = 0f;
    private float timer = 5f;
    private float ccTimer = 3f;
    private bool initiateJumpTimer = false;
    private float jumpTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (activateTimer)
        {
            timeSinceCatch += Time.deltaTime;
            
        }

        if (activateCC)
            timeSinceDisable += Time.deltaTime;

        if (timeSinceDisable >= ccTimer)
        {
            activateCC = false;
            cc.enabled = true;
            timeSinceDisable = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activateTimer = true;
            player.jumpRange = -1f;
            CatchPlayer();
        }
    }

    private void CatchPlayer()
    {
        
        player.transform.position = new Vector3(handPos.position.x, player.transform.position.y, transform.position.z);
        

        if (timeSinceCatch >= timer)
        {
            cc.enabled = false;
            activateCC = true;
            activateTimer = false;
            timeSinceCatch = 0f;

        }else if(timeSinceCatch >= jumpTimer)
        {
            player.jumpRange = 0.4f;  
        }
        
    }
}
