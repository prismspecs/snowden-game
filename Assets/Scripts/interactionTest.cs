using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionTest : MonoBehaviour {

	public bool isLookedAt = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLookedAt) {
			transform.Rotate (100 * Time.deltaTime, 0, 0);
		}
	}

	public void LookChange() {
		isLookedAt = !isLookedAt;
	}

}
