using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTo : MonoBehaviour {

	public float verticalVelocity;
	private CharacterController controller;
	private Vector3 moveVector;
	public float gravity;
	private float waterVelocity = -6;

	public float speed = 5f;
	public GameObject character;

	public GameObject BossHolder;
	private GameObject BossHolder2;
	public GameObject waterPuddle;
	public GameObject floor;
	public GameObject projectilePrefab;
	private List<GameObject> Projectiles = new List<GameObject> ();
	public float projectileVelocity;
	public float projecileVerticleVelocity;
	public int choice;
	private float waterChoice;
	private float choiceForShooting;

	private BossButton bossButtonScript;
	private Animator anim;
	private Nails nailScript;
	public GameObject sheeeeet;
	public GameObject sheeeeeet2;
	private Rigidbody2D rigid;
	public GameObject rocks;
	public int phase = 1;
	public GameObject killsButton;
	public GameObject MainPlatform;
	public GameObject WalkPlatforms;

	private GameObject helloWerld;
	private GameObject killButton;
	private GameObject buttonPlatform;
	private GameObject walkPlatformOne;
	private GameObject walkPlatformTwo;
	public bool bossButtonDown = false;

	void Start () {
		projectileVelocity = 3;
		bossButtonScript = GetComponent<BossButton> ();
		anim = GetComponent<Animator> ();
		nailScript = GetComponent<Nails> ();
		rigid = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("FinalProjectileMachine", 2, 5);
	}

	// Update is called once per frame
	void Update () {
		anim.SetBool ("spitting", false);

		if (GameObject.Find ("buttonCollider").GetComponent<BossButton> ().buttonPressed == true) {
			StopCoroutine (SawMove ());
			StartCoroutine (StopSaw ());
		}

		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject goBullet = Projectiles [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (waterVelocity, projecileVerticleVelocity) * Time.deltaTime * projectileVelocity);
				if (goBullet.transform.position.y <= -3.6) {
					GameObject puddlle = (GameObject)Instantiate (waterPuddle, goBullet.transform.position, Quaternion.identity);
					DestroyObject (goBullet);
					Projectiles.Remove (goBullet);
				}
			}
		}
	}

	public void WaterShooter () {
		waterChoice = Random.Range (1f, 3f);

		if (waterChoice < 1f) {
			StartCoroutine (WaterShoot ());

		} else if (waterChoice >= 1f && waterChoice < 2f) {
			StartCoroutine (WaterShootTwo ());

		} else if (waterChoice >= 2f) {
			StartCoroutine (WaterShootThree ());

		}
	}

	IEnumerator DestroyPuddle () {
		yield return new WaitForSeconds (2);
		DestroyObject (waterPuddle);
	}

	public IEnumerator WaterShoot () {
		projecileVerticleVelocity = 1;
		waterVelocity = -12;
		Projectile ();
		yield return new WaitForSeconds (.6f);
		projecileVerticleVelocity = .85f;
		waterVelocity = -9.5f;
		Projectile ();
		yield return new WaitForSeconds (.4f);
		projecileVerticleVelocity = -.35f;
		waterVelocity = -8.5f;
		Projectile ();
		yield return new WaitForSeconds (.4f);
		projecileVerticleVelocity = -2.5f;
		waterVelocity = -6;
		Projectile ();
	}

	public IEnumerator WaterShootTwo () {
		projecileVerticleVelocity = -2.5f;
		waterVelocity = -6;
		Projectile ();
		yield return new WaitForSeconds (.4f);
		projecileVerticleVelocity = -.35f;
		waterVelocity = -8.5f;
		Projectile ();
		yield return new WaitForSeconds (.4f);
		projecileVerticleVelocity = .85f;
		waterVelocity = -9.5f;
		Projectile ();
		yield return new WaitForSeconds (.6f);
		projecileVerticleVelocity = 1f;
		waterVelocity = -12;
		Projectile ();
	}

	public IEnumerator WaterShootThree () {
		projecileVerticleVelocity = 1;
		waterVelocity = -9;
		Projectile ();
		yield return new WaitForSeconds (.5f);
		projecileVerticleVelocity = .85f;
		waterVelocity = -6.5f;
		Projectile ();
		yield return new WaitForSeconds (.5f);
		projecileVerticleVelocity = -.35f;
		waterVelocity = -5.5f;
		Projectile ();
		yield return new WaitForSeconds (.5f);
		projecileVerticleVelocity = -2.5f;
		waterVelocity = -3;
		Projectile ();
		yield return new WaitForSeconds (.4f);

		projecileVerticleVelocity = -2f;
		waterVelocity = -3;
		Projectile ();
		yield return new WaitForSeconds (.5f);
		projecileVerticleVelocity = 0f;
		waterVelocity = -5.5f;
		Projectile ();
		yield return new WaitForSeconds (.5f);
		projecileVerticleVelocity = .85f;
		waterVelocity = -6.5f;
		Projectile ();
		yield return new WaitForSeconds (1f);
		projecileVerticleVelocity = 1f;
		waterVelocity = -9;
		Projectile ();
	}

	private void Projectile () {
		GameObject bullet = (GameObject)Instantiate (projectilePrefab, transform.position, Quaternion.identity);
		Projectiles.Add (bullet);
	}

	public void ProjectileChoice () {
		waterChoice = Random.Range (1, 3);
		if (waterChoice <= 1) {
			StartCoroutine (WaterShoot ());

		} else if (waterChoice > 1 && waterChoice <= 2) {
			StartCoroutine (WaterShootTwo ());

		} else if (waterChoice > 2 && waterChoice <= 3) {
			StartCoroutine (WaterShootThree ());

		}
	}

	void FinalProjectileMachine () {
		choiceForShooting = Random.Range (1, 3);
		anim.SetBool ("spitting", true);
		if (choiceForShooting <= 1) {
			nailScript.NailShootFunction ();
		} else if (choiceForShooting > 1 && choiceForShooting <= 2) {
			WaterShooter ();
		} else if (choiceForShooting > 2 && choiceForShooting <= 3) {
			WaterShooter ();
		}
		anim.SetBool ("spitting", false);

	}

	IEnumerator SawMove () {
		CancelInvoke ("FinalProjectileMachine");
		float transformx = -28f;
		float transfromy = 0.55f;
		rigid.AddForce (new Vector2 (-27000,-30000));
		anim.SetBool ("saw", true);
		yield return new WaitForSeconds (3);
		Vector2 buttonPlace = new Vector2 (-17.66503f, 7.967938f);
		Vector2 mainPlatformPlace = new Vector2 (-17.68f, 3.97f);
		Vector2 walkPlatformOnePlace = new Vector2 (-27.11f, 1.87f);
		Vector2 walkPlatformTwoPlace = new Vector2 (-34.62f, -0.9911f);

		Vector2 rockPlace = new Vector2 (transformx, transfromy);
		helloWerld = Instantiate (rocks, rockPlace, Quaternion.identity);
		buttonPlatform = Instantiate (MainPlatform, mainPlatformPlace, Quaternion.identity);
		walkPlatformOne = Instantiate (WalkPlatforms, walkPlatformOnePlace, Quaternion.identity);
		walkPlatformTwo = Instantiate (WalkPlatforms, walkPlatformTwoPlace, Quaternion.identity);
		killButton = Instantiate (killsButton, buttonPlace, Quaternion.identity);
			
	}

	IEnumerator StopSaw () {
		CancelInvoke ("spawnMoreRocks");
		anim.SetBool ("saw", false);
		rigid.AddForce (new Vector2 (8000, 10000));
		bossButtonDown = true;
		Destroy (helloWerld);
		yield return new WaitForSeconds (1);
		Destroy (killButton);
		Destroy (buttonPlatform);
		Destroy (walkPlatformOne);
		Destroy (walkPlatformTwo);
		yield return new WaitForSeconds (4);
		Destroy (BossHolder);
		Vector2 bossHolder2Place = new Vector2 (-15.57f, 3f);
		Destroy (BossHolder2);
		BossHolder2 = Instantiate (BossHolder, bossHolder2Place, Quaternion.identity);
		yield return new WaitForSeconds (3);
		if (phase == 2) {
			StartCoroutine (GameObject.Find ("Boss").GetComponent<SymbolShooter> ().ShootSymbols ());
		}
		phase = 3;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (phase == 1) {
			if (col.gameObject == character) {
				if (phase == 1) {
					StartCoroutine (SawMove ());
					phase = 2;
				}
			}
		}
	}
}
