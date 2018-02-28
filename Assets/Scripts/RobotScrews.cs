using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScrews : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	private List<GameObject> ProjectilesR = new List<GameObject> ();
	private List<GameObject> ProjectilesL = new List<GameObject> ();
	private List<GameObject> ProjectilesLL = new List<GameObject> ();
	public float projectileVelocity;
	public GameObject projectilePrefabRight;
	public GameObject projectilePrefabLeft;
	public GameObject projectilePrefabThree;
	private Animator myAnimator;
	public GameObject puddle;
	public int isDirectionRight;
	public LayerMask groundLayer;
	public bool fuckme = true;
	private float xProjectileSpeed;
	private float xProjectileSpeedx;
	private float projectileSpeedx;
	private float projectileSpeedy;
	private GameObject theButton = GameObject.Find ("liav");
	private DisableButton disable;
	private bool pleaseFuckingWork = false;

	public movement movementScript;

	void Start() {
		projectileVelocity = 3;
		myAnimator = GetComponent<Animator> ();
		disable = GetComponent<DisableButton> ();

		//starting in _ will be played every _
		InvokeRepeating ("Shoot", 1f, 2f);
		InvokeRepeating ("ShootThree", 2f, 2f);
		InvokeRepeating ("ShootTwo", 2f, 2f);
	}

	void Update () {

		//Projectile Movement Right
		for (int i = 0; i < ProjectilesR.Count; i++) {
			GameObject goBullet = ProjectilesR [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (xProjectileSpeed, 5) * Time.deltaTime * projectileVelocity);
				//goBullet.transform.Rotate (10, 0, 0);
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
				zoBullet.transform.Translate (new Vector3 (projectileSpeedx, projectileSpeedy) * Time.deltaTime * projectileVelocity);	
				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPosL = Camera.main.WorldToScreenPoint (zoBullet.transform.position);
				if (bulletScreenPosL.x >= Screen.width || bulletScreenPosL.x <= 0) {
					DestroyObject (zoBullet);
					ProjectilesL.Remove (zoBullet);
				}
			}
		}

		for (int j = 0; j < ProjectilesLL.Count; j++) {
			GameObject joBullet = ProjectilesLL [j];
			if (joBullet != null) {
				joBullet.transform.Translate (new Vector3 (xProjectileSpeedx, 5) * Time.deltaTime * projectileVelocity);	
				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPosL = Camera.main.WorldToScreenPoint (joBullet.transform.position);
				if (bulletScreenPosL.x >= Screen.width || bulletScreenPosL.x <= 0) {
					DestroyObject (joBullet);
					ProjectilesLL.Remove (joBullet);
				}
			}
		}
	}

	private void LateUpdate () {
		if (GameObject.Find ("Button").GetComponent<DisableButton> ().buttonPressed) {
			myAnimator.SetBool ("pressed", true);
			CancelInvoke ();
		}
	}

	private void Shoot () {
		GameObject bulletR = (GameObject)Instantiate (projectilePrefabRight, transform.position, Quaternion.identity);
		ProjectilesR.Add (bulletR);
		xProjectileSpeed = Random.Range (-3,3);
	}

	private void ShootThree () {
		GameObject bulletLL = (GameObject)Instantiate (projectilePrefabThree, transform.position, Quaternion.identity);
		ProjectilesLL.Add (bulletLL);
		xProjectileSpeedx = Random.Range (-3,3);
	}

	private void ShootTwo () {
		GameObject bulletL = (GameObject)Instantiate (projectilePrefabLeft, transform.position, Quaternion.identity);
		ProjectilesL.Add (bulletL);
		projectileSpeedx = Random.Range (-3,4);
		projectileSpeedy = Random.Range (3,6);
	}
}