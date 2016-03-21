using UnityEngine;
using System.Collections;

public class BerserkerAI : MonoBehaviour
{
    public float walkSpeed = 2.5f;
    public float sprintSpeed = 20f;
    private float move;
    private Rigidbody2D m_Rigidbody2D;
    private bool playerSpotted = false;
    private bool facingRight = false;
    public Transform floorCheck;
    public Transform playerCheck;
    public Transform wallCheck;
    public Transform berzerkerPos;
    // Use this for initialization
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpotted == false)
        {
            move = walkSpeed;
        }
        if (playerSpotted == true)
        {
            move = sprintSpeed;
        }
    }
    void FixedUpdate()
    {
        RayCasts();
        Move();
    }

    public void Move()
    {
        if (facingRight == false)
        {
            m_Rigidbody2D.velocity = new Vector2(-move, m_Rigidbody2D.velocity.y);
        }
        if (facingRight == true)
        {
            m_Rigidbody2D.velocity = new Vector2(move, m_Rigidbody2D.velocity.y);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void RayCasts()
    {
        RaycastHit2D floorIsGone = Physics2D.Raycast(berzerkerPos.position, -berzerkerPos.position + floorCheck.position, Vector2.Distance(berzerkerPos.position, floorCheck.position));
        RaycastHit2D playerInfront = Physics2D.Raycast(berzerkerPos.position, -berzerkerPos.position + playerCheck.position, Vector2.Distance(berzerkerPos.position, playerCheck.position));
        RaycastHit2D wallInWay = Physics2D.Raycast(berzerkerPos.position, -berzerkerPos.position + wallCheck.position, Vector2.Distance(berzerkerPos.position, wallCheck.position));
        /*Debug.DrawLine(berzerkerPos.position, floorIsGone.point, Color.red);
        Debug.DrawLine(berzerkerPos.position, playerInfront.point, Color.red);
        Debug.DrawLine(berzerkerPos.position, wallInWay.point, Color.red);*/
        if (floorIsGone.collider == null)
        {
            Flip();
            //Debug.Log("flip");
        }

        if (wallInWay.collider != null)
        {
            if (wallInWay.collider.tag != "Player")
            {
                Flip();
            }

        }

        if (playerInfront.collider != null)
        {
            if(playerInfront.collider.tag == "Player")
            {
                playerSpotted = true;
            	Debug.Log(playerSpotted);
            }
        }
    }

}
