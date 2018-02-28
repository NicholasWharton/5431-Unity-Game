using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolShooter : MonoBehaviour {

	public GameObject circle;
	public GameObject square;
	public GameObject triangle;

	private List<GameObject> CircleProjectile;
	private List<GameObject> SquareProjectile;
	private List<GameObject> TriangleProjectile;

	public bool phase = false;
	private rotateTo bossScript;
	private float circleVerticleVelocity = -1;
	private float circleHorizontalVelocity = 1;
	private float squareVerticleVelocity = -1;
	private float squareHorizontalVelocity = 1;
	private float triangleVerticleVelocity = -1;
	private float triangleHorizontalVelocity = 1;
	private float projectileVelocity = -10;


	// Use this for initialization
	void Start () {
		bossScript = GetComponent<rotateTo> ();
		CircleProjectile = new List<GameObject> ();
		SquareProjectile = new List<GameObject> ();
		TriangleProjectile = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
			StartCoroutine (ShootSymbols ());
		}

		for (int i = 0; i < CircleProjectile.Count; i++) {
			GameObject goBullet = CircleProjectile [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (circleHorizontalVelocity, circleVerticleVelocity) * Time.deltaTime * projectileVelocity);
				if (goBullet.transform.position.y <= -3.6) {
					DestroyObject (goBullet);
					CircleProjectile.Remove (goBullet);
				}
			}
		}
		for (int i = 0; i < SquareProjectile.Count; i++) {
			GameObject goBullet = SquareProjectile [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (squareHorizontalVelocity, squareVerticleVelocity) * Time.deltaTime * projectileVelocity);
				if (goBullet.transform.position.y <= -3.6) {
					DestroyObject (goBullet);
					CircleProjectile.Remove (goBullet);
				}
			}
		}
		for (int i = 0; i < TriangleProjectile.Count; i++) {
			GameObject goBullet = TriangleProjectile [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (triangleHorizontalVelocity, triangleVerticleVelocity) * Time.deltaTime * projectileVelocity);
				if (goBullet.transform.position.y <= -3.6) {
					DestroyObject (goBullet);
					CircleProjectile.Remove (goBullet);
				}
			}
		}
	}

	public IEnumerator ShootSymbols () {
		Vector2 circlePos = new Vector2 (-18.05f, 2);
		GameObject circleBullet = Instantiate (circle, circlePos, Quaternion.identity);
		CircleProjectile.Add (circleBullet);
		yield return new WaitForSeconds (1.5f);
		Vector2 squarePos = new Vector2 (-18.05f, 2);
		GameObject squareBullet = Instantiate (square, squarePos, Quaternion.identity);
		SquareProjectile.Add (squareBullet);
		yield return new WaitForSeconds (0.75f);
		Vector2 trianglePos = new Vector2 (-18.05f, 2);
		GameObject triangleBullet = Instantiate (triangle, trianglePos, Quaternion.identity);
		TriangleProjectile.Add (triangleBullet);
	}
}
