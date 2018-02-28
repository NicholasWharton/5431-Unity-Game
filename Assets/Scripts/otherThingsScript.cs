using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	private List<GameObject> ProjectilesR = new List<GameObject> ();
	private List<GameObject> ProjectilesL = new List<GameObject> ();
	public float projectileVelocity;
	public GameObject projectilePrefabRight;
	public GameObject projectilePrefabLeft;
	private Animator myAnimator;
	public GameObject puddle;
	public int isDirectionRight;
	public LayerMask groundLayer;

	void Start() {
		projectileVelocity = 3;
		myAnimator = GetComponent<Animator> ();
	}

	void Update () {
		//Projectile Creation
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Vector3 rotaa;
			rotaa.x = 0;
			rotaa.y = 1;
			rotaa.z = 0;

			if (facingRight == false) {
				GameObject bulletR = (GameObject)Instantiate (projectilePrefabRight, transform.position, Quaternion.identity);
				ProjectilesR.Add (bulletR);
				//bulletR.transform.rotation = Quaternion.AngleAxis (0, rotaa);
			} else {
				GameObject bulletL = (GameObject)Instantiate (projectilePrefabLeft, transform.position, Quaternion.identity);
				ProjectilesL.Add (bulletL);
				//bulletL.transform.rotation = Quaternion.AngleAxis (180, rotaa);
			}
		}

		Vector3 dright;
		dright.x = 30;
		Vector3 dleft;
		dleft.x = -30;

		//Projectile Movement Right
		for (int i = 0; i < ProjectilesR.Count; i++) {
			GameObject goBullet = ProjectilesR [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (10, 0) * Time.deltaTime * projectileVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					ProjectilesR.Remove (goBullet);
				}
			}
		}

		//Projectile Movement Left
		for (int j = 0; j < ProjectilesL.Count; j++) {
			GameObject zoBullet = ProjectilesL [j];
			if (zoBullet != null) {
				zoBullet.transform.Translate (new Vector3 (-10, 0) * Time.deltaTime * projectileVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPosL = Camera.main.WorldToScreenPoint (zoBullet.transform.position);
				if (bulletScreenPosL.x >= Screen.width || bulletScreenPosL.x <= 0) {
					DestroyObject (zoBullet);
					ProjectilesL.Remove (zoBullet);
				}
			}
		}

		if (Input.GetKey (KeyCode.F)) {
			Mopping ();
		}

		if (Input.GetKeyUp (KeyCode.F)) {
			StopMopping ();
		}
	}

	void Mopping () {
		//add mopping animation
		myAnimator.SetBool ("mopping", true);
	
		if (puddle.transform.position == transform.position) {
			DestroyObject (puddle);
		}
	}


	void StopMopping () {
		//stop mopping animation
		myAnimator.SetBool ("mopping", false);
	}
}