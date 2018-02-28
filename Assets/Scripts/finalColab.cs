using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalColab : MonoBehaviour {

	[SerializeField] private float MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float JumpForce = 400f;                  // Amount of force added when the player jumps.
	[SerializeField] private bool AirControl = false;                 // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask WhatIsGround;                  // A mask determining what is ground to the character

	private Transform GroundCheck;    // A position marking where to check if the player is grounded.
	const float GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool Grounded;            // Whether or not the player is grounded.
	private Transform CeilingCheck;   // A position marking where to check for ceilings
	const float CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
	private Animator Anim;            // Reference to the player's animator component.
	private Rigidbody2D Rigidbody2D;
	private bool FacingRight = true;  // For determining which way the player is currently facing.

	private void Awake()
	{
		// Setting up references.
		GroundCheck = transform.Find("GroundCheck");
		CeilingCheck = transform.Find("CeilingCheck");
		Anim = GetComponent<Animator>();
		Rigidbody2D = GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate()
	{
		Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				Grounded = true;
		}
		Anim.SetBool("Ground", Grounded);
		Anim.SetFloat("vSpeed", Rigidbody2D.velocity.y);
	}



	public void Move(float move, bool crouch, bool jump)
	{
		if (Grounded || AirControl)
		{
			Anim.SetFloat("Speed", Mathf.Abs(move));

			Rigidbody2D.velocity = new Vector2(move*MaxSpeed, Rigidbody2D.velocity.y);

			if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}
		}
		if (Grounded && jump && Anim.GetBool("Ground"))
		{
			Grounded = false;
			Anim.SetBool("Ground", false);
			Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
		}
	}


	private void Flip()
	{
		FacingRight = !FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
