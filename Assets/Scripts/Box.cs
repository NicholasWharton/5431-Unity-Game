using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	private Animator anim;
	private Tower towerScript;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "wall") {
			anim.SetBool ("BoxIn", true);
		}
	}
}
