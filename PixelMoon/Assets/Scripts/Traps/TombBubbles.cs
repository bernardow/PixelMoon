using UnityEngine;

public class TombBubbles : MonoBehaviour
{
    private SpeedHandler sh = null;

    private void Start()
    {
        sh = FindObjectOfType<SpeedHandler>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sh.halfSpeedDebuff = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sh.halfSpeedDebuff = false;
    }
}
