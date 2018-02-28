using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	private List<GameObject> ProjectilesL = new List<GameObject> ();
	public float projectileVelocity;
	public GameObject projectilePrefabRight;
	public GameObject projectilePrefabLeft;
	public GameObject projectilePrefabThree;
	private float xProjectileSpeed;
	private float xProjectileSpeedx;
	private float projectileSpeedx;
	private float projectileSpeedy;
	private GameObject theButton = GameObject.Find ("liav");
	private DisableButton disable;

	private Animator anim;
	public bool boxOn = false;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
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
	}

	// Use this for initialization
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "box") {
			anim.SetBool ("BoxOn", true);
			boxOn = true;
			//ShootTwo ();
		}
	}

	private void ShootTwo () {
		GameObject bulletL = (GameObject)Instantiate (projectilePrefabLeft, transform.position, Quaternion.identity);
		ProjectilesL.Add (bulletL);
		projectileSpeedx = Random.Range (-3,4);
		projectileSpeedy = Random.Range (3,6);
	}
}
