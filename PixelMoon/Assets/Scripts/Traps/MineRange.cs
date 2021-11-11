using UnityEngine;

public class MineRange : MonoBehaviour
{
    public bool inRange = false;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            inRange = false;
    }
}
