using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButtonChanger : MonoBehaviour {

	private Animator anim;
	private BossButton bossButtonScript;
	private rotateTo bossScript;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		bossButtonScript = GetComponent<BossButton> ();
		bossScript = GetComponent<rotateTo> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("buttonCollider").GetComponent<BossButton> ().buttonPressed == true) {
			anim.SetBool ("button", true);
		}
	}
}
