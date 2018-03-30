using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipAway : MonoBehaviour {

	// Use this for initialization
	public float time;
	public int totalChips;
	public ParticleSystem particle;
	private float timeBetweenChips;
	private float timePassed;
	private int chipCount;
	private float initialHeight;
	private Vector3 initialPos;
	private float chipMagnitude;
	public float minimumDistance;
	public AudioSource audio;
	public AudioClip[] clips;

	// looking/activation
	public bool isLookedAt = false;
	private float startedLooking = 0f;

	void Start () {
		isLookedAt = false;
		timePassed = chipCount = 0;
		initialPos = transform.position;
		timeBetweenChips = time / totalChips;
		initialHeight = transform.localScale.y;
		chipMagnitude = initialHeight / totalChips;
	}

	// Update is called once per frame
	void Update () {
		if (isLookedAt) {

			var player = GameObject.Find("Player").transform;
			float dist = Vector3.Distance(player.position, transform.position);
			//Debug.Log(dist);

			if (dist < minimumDistance) {

				Chipping ();

			}
		}
		if (timePassed > time) {
			StopChipping ();
		}
	}

	public void LookChange() {
		isLookedAt = !isLookedAt;
		startedLooking = Time.time;
	}

	public void StopChipping() {
		isLookedAt = false;
		transform.localScale = new Vector3 (transform.localScale.x, initialHeight, transform.localScale.z);
		transform.position = initialPos;
		chipCount = 0;
		timePassed = 0;
	}

	void Chipping() {

		if (!audio.isPlaying) {
			audio.PlayOneShot(clips[0], 0.7F);
		}
		timePassed += Time.deltaTime;
		if (chipCount < totalChips) {
			if (timePassed >= timeBetweenChips) {
				timePassed = 0;
				chipCount++;
				Chip ();
			}
		} else {
			// done chipping
			Destroy(this.gameObject);
		}

	}

	void Chip() {
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - chipMagnitude,
		                                    transform.localScale.z);
		transform.position = new Vector3 (transform.position.x, transform.position.y - (chipMagnitude / 2), transform.position.z);

		particle.Play ();


	}
}