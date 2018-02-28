using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

	public GameObject self;
	public bool Hitting = false;
	public int Health = 3;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Hitting = true;
			Health--;
			if (Health == 0) {
				Destroy (self);
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Hitting = false;
		}
	}
}
