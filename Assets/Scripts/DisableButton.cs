using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButton : MonoBehaviour {

	public bool buttonPressed = false;
	public GameObject playerCharacter;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject == playerCharacter) {
			buttonPressed = true;
			anim.SetBool ("buttonPressed", true);
		}
	}
}
