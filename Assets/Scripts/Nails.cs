using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nails : MonoBehaviour {

	public bool shootNails;
	public GameObject nailPrefab;
	private List<GameObject> nailsList = new List<GameObject> ();
	private List<GameObject> nailsListUp = new List<GameObject> ();
	private List<GameObject> nailsListDown = new List<GameObject> ();
	private List<GameObject> nailsLista = new List<GameObject> ();
	private List<GameObject> nailsListUpa = new List<GameObject> ();
	private List<GameObject> nailsListDowna = new List<GameObject> ();
	private List<GameObject> nailsListDownc = new List<GameObject> ();
	public float nailVelocity;
	private float nailsUpOffset;
	private float nailsDownOffset;
	private float nailsOffset;
	private Animator anim;
	private float playerJumpPower;
	private Rigidbody2D rigid;
	private float choice;
	private float projectileVerticleVelocity;
	public GameObject nailPrefabSmall;
	public bool helloWorld = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
		playerJumpPower = -200;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.L)) {
			helloWorld = true;
			//StartCoroutine (NailsTest());
		}

		if (helloWorld == true) {
			StartCoroutine (NailShoot ());
			helloWorld = false;
		}

		for (int i = 0; i < nailsList.Count; i++) {
			GameObject goBullet = nailsList [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (-10, 2) * Time.deltaTime * nailVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					nailsList.Remove (goBullet);
				}
			}
		}

		for (int i = 0; i < nailsListUp.Count; i++) {
			GameObject goBullet = nailsListUp [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (-11, 2) * Time.deltaTime * nailVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					nailsListUp.Remove (goBullet);
				}
			}
		}

		for (int i = 0; i < nailsListDown.Count; i++) {
			GameObject goBullet = nailsListDown [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (-12, projectileVerticleVelocity) * Time.deltaTime * nailVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					nailsListDown.Remove (goBullet);
				}
			}
		}

		for (int i = 0; i < nailsLista.Count; i++) {
			GameObject goBullet = nailsLista [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (-8, 2) * Time.deltaTime * nailVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					nailsLista.Remove (goBullet);
				}
			}
		}

		for (int i = 0; i < nailsListUpa.Count; i++) {
			GameObject goBullet = nailsListUpa [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (-6, 2) * Time.deltaTime * nailVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					nailsListUpa.Remove (goBullet);
				}
			}
		}

		for (int i = 0; i < nailsListDowna.Count; i++) {
			GameObject goBullet = nailsListDowna [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (-11, 2) * Time.deltaTime * nailVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					nailsListDowna.Remove (goBullet);
				}
			}
		}

		for (int i = 0; i < nailsListDownc.Count; i++) {
			GameObject goBullet = nailsListDownc [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (-12, 2) * Time.deltaTime * nailVelocity);

				//if the projectile goes off the screen it gets destroyed
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					nailsListDownc.Remove (goBullet);
				}
			}
		}
	}

	private void NailsShooterNormal() {
		Vector3 nailsOffsets = new Vector3 (transform.position.x - 1, transform.position.y - 1f, transform.position.z);
		GameObject nail = (GameObject)Instantiate (nailPrefab, nailsOffsets, Quaternion.identity);
		nailsList.Add (nail);
	}
	private void NailsShooterFast() {
		Vector3 nailsOffsetsUp = new Vector3 (transform.position.x -1, transform.position.y - 0f, transform.position.z);
		GameObject nailUp = (GameObject)Instantiate (nailPrefab, nailsOffsetsUp, Quaternion.identity);
		nailsListUp.Add (nailUp);
	}
	private void NailsShooterFastFast() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - -1f, transform.position.z);
		GameObject nailDown = (GameObject)Instantiate (nailPrefab, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDown);
	}
	private void NailsShooterSlow() {
		Vector3 nailsOffsets = new Vector3 (transform.position.x - 1, transform.position.y - 1f, transform.position.z);
		GameObject naila = (GameObject)Instantiate (nailPrefab, nailsOffsets, Quaternion.identity);
		nailsList.Add (naila);
	}
	private void NailsShooterSlowSlow() {
		Vector3 nailsOffsetsUp = new Vector3 (transform.position.x -1, transform.position.y - 0f, transform.position.z);
		GameObject nailUpa = (GameObject)Instantiate (nailPrefab, nailsOffsetsUp, Quaternion.identity);
		nailsListUp.Add (nailUpa);
	}
	private void NailsShooterMid() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - -1f, transform.position.z);
		GameObject nailDowna = (GameObject)Instantiate (nailPrefab, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDowna);
	}

	public void NailShootFunction () {
		StartCoroutine (NailShoot ());
	}

	IEnumerator NailsTest () {
		NailsOne ();
		yield return new WaitForSeconds (0.5f);

		NailsTwo ();
		yield return new WaitForSeconds (0.5f);

		NailsThree ();
		yield return new WaitForSeconds (0.5f);

		NailsGroup ();
		yield return new WaitForSeconds (0.1f);
		NailsGroup ();
		yield return new WaitForSeconds (0.1f);
		NailsGroup ();
		yield return new WaitForSeconds (0.1f);

		yield return new WaitForSeconds (0.5f);
			
	}

	public IEnumerator NailShoot () {
		rigid.AddForce (Vector2.up * playerJumpPower);
		yield return new WaitForSeconds (0.05f);
		rigid.AddForce (Vector2.up * 0);
		anim.SetBool ("Nails", true);
		yield return new WaitForSeconds (1f);
		anim.SetBool ("Nails", false);

		choice = Random.Range (1.0f, 4.0f);
		if (choice < 1.5f) {
			NailsOne ();
		} else if (choice >= 1.5f && choice <= 2.5f) {
			NailsTwo ();
		} else if (choice > 2.5f && choice <= 3.5) {
			NailsThree ();
		} else if (choice > 3.5) {
			NailsGroup ();
			yield return new WaitForSeconds (0.1f);
			NailsGroup ();
			yield return new WaitForSeconds (0.1f);
			NailsGroup ();
			yield return new WaitForSeconds (0.1f);
		}
		yield return new WaitForSeconds (0.5f);

		choice = Random.Range (1.0f, 4.0f);
		if (choice < 1.5f) {
			NailsOne ();
		} else if (choice >= 1.5f && choice <= 2.5f) {
			NailsTwo ();
		} else if (choice > 2.5f && choice <= 3.5) {
			NailsThree ();
		} else if (choice > 3.5) {
			NailsGroup ();
			yield return new WaitForSeconds (0.1f);
			NailsGroup ();
			yield return new WaitForSeconds (0.1f);
			NailsGroup ();
			yield return new WaitForSeconds (0.1f);
		}
	}

	private void NailsShooterNormalOne() {
		Vector3 nailsOffsets = new Vector3 (transform.position.x - 1, transform.position.y - 1f, transform.position.z);
		GameObject nail = (GameObject)Instantiate (nailPrefab, nailsOffsets, Quaternion.identity);
		nailsList.Add (nail);
	}
	private void NailsShooterFastOne() {
		Vector3 nailsOffsetsUp = new Vector3 (transform.position.x -1, transform.position.y - 0f, transform.position.z);
		GameObject nailUp = (GameObject)Instantiate (nailPrefab, nailsOffsetsUp, Quaternion.identity);
		nailsListUp.Add (nailUp);
	}
		
	private void NailsShooterFastFastOne() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - -1f, transform.position.z);
		GameObject nailDownc = (GameObject)Instantiate (nailPrefab, nailsOffsetsDown, Quaternion.identity);
		nailsListDownc.Add (nailDownc);
	}

	private void NailsOne () {
		nailVelocity = 2;
		NailsShooterNormalOne ();
		NailsShooterFastOne ();
		NailsShooterFastFastOne ();
	}

	private void NailsShooterMidTwo() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - 1f, transform.position.z);
		GameObject nailDowna = (GameObject)Instantiate (nailPrefab, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDowna);
	}

	private void NailsShooterNormalTwo() {
		Vector3 nailsOffsets = new Vector3 (transform.position.x - 1, transform.position.y - 2f, transform.position.z);
		GameObject nail = (GameObject)Instantiate (nailPrefab, nailsOffsets, Quaternion.identity);
		nailsList.Add (nail);
	}
	private void NailsShooterSlowTwo() {
		Vector3 nailsOffsets = new Vector3 (transform.position.x - 1, transform.position.y - 3f, transform.position.z);
		GameObject naila = (GameObject)Instantiate (nailPrefab, nailsOffsets, Quaternion.identity);
		nailsList.Add (naila);
	}

	private void NailsTwo () {
		nailVelocity = 2;
		NailsShooterMidTwo ();
		NailsShooterNormalTwo ();
		NailsShooterSlowTwo ();
	}

	private void NailsShooterFastFastThree() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - 1f, transform.position.z);
		GameObject nailDown = (GameObject)Instantiate (nailPrefab, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDown);
	}
	private void NailsShooterFastFastThreeThree() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - 2f, transform.position.z);
		GameObject nailDown = (GameObject)Instantiate (nailPrefab, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDown);
	}
	private void NailsShooterFastFastThreeThreeThree() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - 3f, transform.position.z);
		GameObject nailDown = (GameObject)Instantiate (nailPrefab, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDown);
	}
	private void NailsThree () {
		nailVelocity = 3;
		projectileVerticleVelocity = 5;
		NailsShooterFastFastThree ();
		NailsShooterFastFastThreeThree ();
		NailsShooterFastFastThreeThreeThree ();
		nailVelocity = 2;
		projectileVerticleVelocity = 2;
	}

	private void NailsShooterFastFastThreeA() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - 1f, transform.position.z);
		GameObject nailDown = (GameObject)Instantiate (nailPrefabSmall, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDown);
	}
	private void NailsShooterFastFastThreeThreeA() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - 2f, transform.position.z);
		GameObject nailDown = (GameObject)Instantiate (nailPrefabSmall, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDown);
	}
	private void NailsShooterFastFastThreeThreeThreeA() {
		Vector3 nailsOffsetsDown = new Vector3 (transform.position.x - 1, transform.position.y - 3f, transform.position.z);
		GameObject nailDown = (GameObject)Instantiate (nailPrefabSmall, nailsOffsetsDown, Quaternion.identity);
		nailsListDown.Add (nailDown);
	}

	private void NailsGroup () {
		NailsShooterFastFastThreeA ();
		NailsShooterFastFastThreeThreeA ();
		NailsShooterFastFastThreeThreeThreeA ();
	}

	IEnumerator NailsGrouped () {
		NailsGroup ();
		yield return new WaitForSeconds (.2f);
		NailsGroup ();
		yield return new WaitForSeconds (.2f);
		NailsGroup ();
	}
}
