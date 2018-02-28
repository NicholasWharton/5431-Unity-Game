using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour {

	private Animator anim;
	private BossButton bossButtonScript;
	private Rigidbody2D rigid;
	public bool helloworld = false;
	public float speed = 20;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		bossButtonScript = GetComponent<BossButton> ();	
		rigid.AddForce (transform.up * speed);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("buttonCollider").GetComponent<BossButton> ().buttonPressed == true) {
			anim.SetBool ("buttonPressed", true);
		}
	}
		
}
