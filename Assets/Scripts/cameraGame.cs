
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraGame : MonoBehaviour {

	public bool isLookedAt = false;
	private float startedLooking = 0f;
	public float discoverDuration = 1f;	// must look at cam for 1 second to find it

	private GameObject gameController;
	public Animator anim;

	public GameObject bonusText;

	private GameObject player;

	void Start () {
		gameController = GameObject.Find ("GAME CONTROLLER");

		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isLookedAt) {
			if (Time.time > startedLooking + discoverDuration) {
				// found it!
				gameController.GetComponent<gameController>().SendMessage("FoundCamera");

				// play camera drooping animation
				anim.SetTrigger ("goDroop");

				// show bonus text
				var direction = transform.position - player.transform.position;

				Instantiate(bonusText, transform.position, Quaternion.LookRotation(direction));

				Destroy (this);
			}
		}
	}

	void OnMouseEnter() {
		Debug.Log("!");
	}

	public void LookChange() {
		isLookedAt = !isLookedAt;
		startedLooking = Time.time;
	}

}
