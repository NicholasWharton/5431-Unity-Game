using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public int playerSpeed = 10;
	public bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	private Animator anim;
	private Rigidbody2D rigid;
	public int healthBar = 3;

	[SerializeField] private LayerMask WhatIsGround;
	private Transform GroundCheck;
	const float GroundedRadius = .2f;
	private bool Grounded;
	private Transform CeilingCheck;
	const float CeilingRadius = .01f;

	public GameObject bolt;
	public GameObject nut;
	public GameObject gear;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rigid = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
	}

	void PlayerMove () {
		moveX = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

		if(moveX < 0.0f && facingRight == false) {
			FlipPlayer ();
		}else if(moveX > 0.0f && facingRight == true) {
			FlipPlayer ();
		}
	
		rigid.velocity = new Vector2 (moveX * playerSpeed, rigid.velocity.y);
		anim.SetFloat("speed", Mathf.Abs (rigid.velocity.x));

		if (healthBar == 0) {
			DestroyObject (this);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "ground") {
			Grounded = true;
			anim.SetBool ("ground", true);
		}
	}

	void Jump (){
		if (Grounded == true) {
			Grounded = false;
			anim.SetBool ("ground", false);
			rigid.AddForce (Vector2.up * playerJumpPower);
		}
	}

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}