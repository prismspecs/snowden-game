using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipAway : MonoBehaviour {

	// Use this for initialization
	public float time;
	public int totalChips;
	public 	ParticleSystem particle;
	private float timeBetweenChips;
	private float timePassed;
	private int chipCount;
	private bool isChipping;
	private float initialHeight;
	private Vector3 initialPos;
	private float chipMagnitude;

	void Start () {
		isChipping = false;
		timePassed = chipCount = 0;
		initialPos = transform.position;
		timeBetweenChips = time / totalChips;
		initialHeight = transform.localScale.y;
		chipMagnitude = initialHeight / totalChips;
	}

	// Update is called once per frame
	void Update () {
		if (isChipping) {
			Chipping ();
		}
		if (timePassed > time) {
			StopChipping ();
		}
	}

	public void StartChipping(){
		isChipping = true;
	}

	public void StopChipping(){
		isChipping = false;
		transform.localScale = new Vector3 (transform.localScale.x, initialHeight, transform.localScale.z);
		transform.position = initialPos;
		chipCount = 0;
		timePassed = 0;

	}

	void Chipping(){
		timePassed += Time.deltaTime;
		if (chipCount < totalChips) {
			if (timePassed >= timeBetweenChips) {
				timePassed = 0;
				chipCount++;
				Chip ();
			}
		}
	}

	void Chip(){
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - chipMagnitude, 
			transform.localScale.z);
		transform.position = new Vector3 (transform.position.x, transform.position.y - (chipMagnitude / 2), transform.position.z);

		particle.Play ();
	}
}