using UnityEngine;

public class EdgeSnake : MonoBehaviour
{
    [SerializeField] private LayerMask layers;

    public bool EdgeBite(float distanceToTarget)
    {
        bool canBite = false;
        float castDist = distanceToTarget;

        Vector2 endPos = transform.position + Vector3.down * castDist;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, layers);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                canBite = true;
            }
            else canBite = false;
        }

        return canBite;
    }
}
