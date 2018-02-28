using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexiBoxController : MonoBehaviour {

	public int playerSpeed = 10;
	public bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	private Animator anim;
	private Rigidbody2D rigid;

	[SerializeField] private LayerMask WhatIsGround;
	private Transform GroundCheck;
	const float GroundedRadius = .2f;
	private bool Grounded;
	private Transform CeilingCheck;
	const float CeilingRadius = .01f;
	private int state;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rigid = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement () {
		switch (state) {
		//Not Seeing Player
		case 1:

			break;
		default:

			break;

		}
	}

	void Jump (){
		if (Grounded == true) {
			Grounded = false;
			anim.SetBool ("ground", false);
			rigid.AddForce (Vector2.up * playerJumpPower);
		}
	}
}
