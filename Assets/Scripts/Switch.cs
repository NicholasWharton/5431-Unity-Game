using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public Tower towerScript;
	private Animator anim;
	public BoxCollider2D colliderBox;

	void Start () {
		towerScript = GetComponent<Tower> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (GameObject.Find ("BoxHolder").GetComponent<Tower> ().boxOn == true) {
			anim.SetBool ("BoxIn", true);
			colliderBox.enabled = false;
		}	
	}
}
