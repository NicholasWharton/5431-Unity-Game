using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour {


	void Update () {
		if (Input.GetKeyDown (KeyCode.N)) {
			ChangeScene ("MenuScreen");
		}
	}

	public void ChangeScene (string sceneName) {
		Application.LoadLevel (sceneName);
	}
}
