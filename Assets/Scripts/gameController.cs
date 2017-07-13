using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

	public int CamerasFound = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FoundCamera() {
		CamerasFound++;

		Debug.Log ("found camera, " + CamerasFound + " found");

		// maybe put some text on screen?
	}
}
