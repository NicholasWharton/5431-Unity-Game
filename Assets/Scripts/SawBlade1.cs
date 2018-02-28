using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade1 : MonoBehaviour {

	public bool sawEnabled = false;
	public GameObject rockOne;
	public GameObject rockSecond;
	public GameObject rockThree;
	public GameObject rockFour;
	private GameObject nail;
	private float nailVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if it is enabled
			//play sawblade animation
			//make a collistion box over the group of metal shaving that are popping out
		nail.transform.Translate (new Vector3 (-10, 2) * Time.deltaTime * nailVelocity);

	}

	private void SpawnRocks () {
		Vector3 nailsOffsets = new Vector3 (transform.position.x - 1, transform.position.y - 1f, transform.position.z);
		nail = (GameObject)Instantiate (rockOne, nailsOffsets, Quaternion.identity);
	}
}
