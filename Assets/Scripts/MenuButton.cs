using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ChangeScene ("5431 robot");
		}
	}

	public void ChangeScene (string sceneName) {
		Application.LoadLevel (sceneName);
	}
}
