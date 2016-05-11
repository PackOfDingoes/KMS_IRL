using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlatformerCharacter2D : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float m_ClimbSpeed = 10f;                    // The fastest the player can travel in the y axis.
    [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Animator m_Anim;            // Reference to the player's animator component.
	[HideInInspector]public Rigidbody2D m_Rigidbody2D;
	public bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private SpellCasting windDashing;
	[HideInInspector] public bool onLadder = false;
    public float playerClimbSpeed = 20;
	[HideInInspector]public bool playerIsDead = false;

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
		windDashing = GetComponent<SpellCasting>();

	}


    private void FixedUpdate()
    {
        m_Grounded = false;
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        m_Anim.SetBool("Ground", m_Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }

	private void Update()
	{
		
	}

    public void Move(float move, bool jump, float climb = 0)
    {
		if (m_Grounded && windDashing.isWindDashing == false || m_AirControl && windDashing.isWindDashing == false)
		{
            // Move the character
            if (onLadder == false)
            {
				m_Anim.SetFloat("Speed", Mathf.Abs(move));
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
				m_Rigidbody2D.gravityScale = 3;
            }
            if (onLadder == true)
            {
				m_Anim.SetFloat("Speed",0f);
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed/2, climb* m_ClimbSpeed);
				m_Rigidbody2D.gravityScale = 0;
            }

			if (playerIsDead == true)
			{
				m_Anim.SetFloat("Speed",0f);
				m_Rigidbody2D.velocity = new Vector2(0f, 100f);
				m_Rigidbody2D.velocity = transform.up * -20f;
				m_Rigidbody2D.gravityScale = 3;
			}
            // If the input is moving the player right and the player is facing left...
			if(playerIsDead == false)
			{
	            if (move > 0 && !m_FacingRight)
	            {
	                // ... flip the player.
	                Flip();
	            }
	                // Otherwise if the input is moving the player left and the player is facing right...
	            else if (move < 0 && m_FacingRight)
	            {
	                // ... flip the player.
	                Flip();
	            }
			}
        }
        // If the player should jump...
        if (m_Grounded && jump && m_Anim.GetBool("Ground") && onLadder == false)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
