using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowNew : MonoBehaviour {
	private Transform m_Player;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		m_Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x = Mathf.Lerp(transform.position.x, m_Player.position.x, speed * Time.deltaTime);
		//position.y = Mathf.Lerp(transform.position.y, m_Player.position.y, speed * Time.deltaTime);
		transform.position = position;
	}
}
