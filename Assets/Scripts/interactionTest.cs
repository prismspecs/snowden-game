using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionTest : MonoBehaviour {

	public bool isLookedAt = false;
	private GameObject Player;
	public float triggerDistance = 5;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isLookedAt) {
			transform.Rotate (100 * Time.deltaTime, 0, 0);
		}
	}

	public void LookChange() {
		float theDist = Vector3.Distance (Player.transform.position, transform.position);
		Debug.Log (theDist);
		if(theDist < triggerDistance)
			isLookedAt = !isLookedAt;
	}

}
