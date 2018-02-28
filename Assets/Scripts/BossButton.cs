using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButton : MonoBehaviour {

	public bool buttonPressed = false;
	public GameObject playerCharacter;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject == playerCharacter) {
			buttonPressed = true;
		}
	}
}
