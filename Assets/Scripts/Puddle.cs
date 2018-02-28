using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour {
	public GameObject puddle;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		StartCoroutine (DeletePuddle ());
	}


	IEnumerator DeletePuddle () {
		yield return new WaitForSeconds (2);
		anim.SetBool ("die", true);
		yield return new WaitForSeconds (.6f);
		DestroyObject (puddle);
	}
}
