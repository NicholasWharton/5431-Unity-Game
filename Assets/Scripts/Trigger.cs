using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public Vroom vroomScript;
	public Vroom vroomScripts;

	// Use this for initialization
	void Start () {
		vroomScript = GameObject.Find ("VroomBot").GetComponent<Vroom> ();
		vroomScripts = GameObject.Find ("VroomBot (1)").GetComponent<Vroom> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			vroomScript.state = true;
			vroomScripts.state = true;
		}
	}
}	
