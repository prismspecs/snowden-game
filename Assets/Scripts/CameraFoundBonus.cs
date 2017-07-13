using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFoundBonus : MonoBehaviour {

	public float fadeTime = 1f;

	private bool fadeOut = false;

	void Start() {

	}

	public void killMe() {
		Destroy(this.gameObject);
	}
}
