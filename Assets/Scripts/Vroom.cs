using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vroom : MonoBehaviour {

	private Rigidbody2D rigid;
	public bool state = false;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == true) {
			rigid.velocity = new Vector2 (-3 * 2, rigid.velocity.y);
		} else {
			rigid.velocity = new Vector2 (0 * 2, rigid.velocity.y);
		}
	}
		
}
