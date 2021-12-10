using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Propriedades de Movimento")]
    public float speed = 0f;
    public float crouchSpeed = 0f;
    public float jumpRange = 0.4f;
    public float jumpForce = 0f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private LayerMask mask;
    private CircleCollider2D cc = null;
    private SpriteRenderer sr = null;
    public bool slowDebuff = false;
    public bool crouched = false;
    private bool canJump = false;

    [Header("Propriedades da Vida")]
    public int vida = 3;

    [Header("Inventário")]
    [SerializeField] private List<string> inventory;
    public bool removed = false;
    public string actSlot = null;
    private float inventoryTimer = 1f;
    private float timeSinceLastCath;
    private float timeSinceLastJump = 0f;
    private Rigidbody2D rb;

    public bool hidden = false;

    [Header("Referencias")]
    [SerializeField] private List<Stairs> st = null;
    [SerializeField] private Transform gdCP = null;
    [SerializeField] private Transform feetCastPoint = null;
    [SerializeField] private Transform headCastPoint = null;
    [SerializeField] private GameObject head = null;
    [SerializeField] private Sprite crouchedSprite;
    [SerializeField] private Sprite standSprite;
    [SerializeField] private GameObject lampPrefab = null;
    [SerializeField] private Transform lampEdge = null;
    [SerializeField] private GameObject medicKitPrefab = null;
    [SerializeField] private GameObject armPrefab;
    [SerializeField] private Inventory inv;
    [SerializeField] private SpriteRenderer armSPR = null;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        st.Add(FindObjectOfType<Stairs>());
        
        crouchSpeed = 500;
       
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastJump += Time.deltaTime;
        timeSinceLastCath += Time.deltaTime;
        Death();
        InventoryVisible();
        Closet();

        if (Jump(jumpRange))
            canJump = true;
        else canJump = false;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            if (Input.GetKeyDown(KeyCode.E) && timeSinceLastCath >= inventoryTimer)
            {

                inventory.Add(collision.gameObject.name);
                Destroy(collision.gameObject);
                timeSinceLastCath = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage Trap"))
        {
            vida--;
        }
    }

    private void Movement()
    {
        //Base Movement
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor * speed, 0));

        // Jump
        if (timeSinceLastJump >= timer)
        {
            if (crouched == false && Jump(jumpRange) == true && Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                timeSinceLastJump = 0;
            }
        }

        //Crouching
        if ((Crouch(0.5f) == true || Input.GetKey(KeyCode.S)) && canJump)
        {
            crouched = true;
            cc.enabled = false;
            sr.sprite = crouchedSprite;
            head.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else
        {
            crouched = false;
            cc.enabled = true;
            sr.sprite = standSprite;
            head.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 1f, 0);
        }

        //Stairs :D
        Stairs();



    }

    private bool Jump(float distance)
    {
        bool canJump = false;
        float castDist = distance;

        Vector2 endPos = feetCastPoint.position + Vector3.down * castDist;

        RaycastHit2D hit = Physics2D.Linecast(feetCastPoint.position, endPos, mask);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Ground") || hit.collider.gameObject.CompareTag("Crate"))
            {
                canJump = true;
            }
            else
                canJump = false;
        }

        Debug.DrawLine(feetCastPoint.position, endPos);

        return canJump;
    }

    public bool Crouch(float distance)
    {
        bool isCrouched = false;
        float castDist = distance;

        Vector2 endPos = headCastPoint.position + Vector3.up * castDist;

        RaycastHit2D hit = Physics2D.Linecast(headCastPoint.position, endPos, mask);

        if (hit.collider != null)
        {


            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                isCrouched = true;
            }
            else
                isCrouched = false;
        }
        Debug.DrawLine(headCastPoint.position, endPos);

        return isCrouched;
    }

    private void Stairs()
    {
        if(st != null)
        {
            foreach(Stairs stair in st)
            {

                if (stair.canGoUp && Input.GetKey(KeyCode.W))
                {
                    stair.onStair = true;
                    transform.position = new Vector3(stair.transform.position.x, transform.localPosition.y, 0);

                    transform.position += new Vector3(0, 1, 0) * 3 * Time.fixedDeltaTime;
                    
                    
                }
                if (stair.canGoUp && Input.GetKey(KeyCode.S))
                {
                    stair.onStair = true;

                    
                    transform.position = new Vector3(stair.transform.position.x, transform.localPosition.y, 0);
                    transform.position += new Vector3(0, -1, 0) * 3 * Time.fixedDeltaTime;
                }

                if (transform.position.x != stair.transform.position.x)
                {
                    stair.onStair = false;
                }

                if (stair.onStair)
                {
                    
                    rb.velocity = Vector2.zero;
                    speed = 0f;
                    
                    
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        stair.onStair = false;
                        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        timeSinceLastJump = 0;
                    }
                }
            }

        }
        
    }


    public List<string> InventoryCheck()
    {
        return inventory;
    }

    private void InventoryVisible()
    {
        foreach( string item in inventory)
        {
            if(item == "lamp")
            {
                lampEdge.position = armPrefab.GetComponent<Transform>().position;

                if (inv.select1 && InventoryCheck()[0] == "lamp")
                {
                    lampPrefab.SetActive(true);
                }
                else if (inv.select2 && InventoryCheck()[1] == "lamp")
                {
                    lampPrefab.SetActive(true);
                }
                else lampPrefab.SetActive(false);
                
                
            }else if (item == "medic")
            {
                if(medicKitPrefab != null)
                {
                    medicKitPrefab.GetComponent<Transform>().position = armPrefab.GetComponent<Transform>().position;

                    if (inv.select1 && InventoryCheck()[0] == "medic")
                    {
                        medicKitPrefab.SetActive(true);
                    }
                    else if (inv.select2 && InventoryCheck()[1] == "medic")
                    {
                        medicKitPrefab.SetActive(true);
                    }
                    else medicKitPrefab.SetActive(false);

                }else if(medicKitPrefab == null)
                {
                    if (InventoryCheck()[0] == "medic")
                    {
                        inventory.Remove(inventory[0]);
                        removed = true;
                        actSlot = "1";
                    }
                    else if (InventoryCheck()[1] == "medic")
                    {
                        inventory.Remove(inventory[1]);
                        removed = true;
                        actSlot = "2";
                    }
                    else
                    {
                        removed = false;
                        actSlot = null;
                    }
                    
                }
            }

        }
    }

   

    private void Death()
    {
        if (vida <= 0)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }

    private void Closet()
    {
        if (hidden)
        {
            sr.sortingOrder = 4;
            armSPR.sortingOrder = 3;

        }
        else if (!hidden)
        {
            armSPR.sortingOrder = 9;
            sr.sortingOrder = 10;
        }
    }

}
