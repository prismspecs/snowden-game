using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {

			Renderer r = GetComponent<Renderer>();
			MovieTexture movie = (MovieTexture)r.material.mainTexture;

			if (movie.isPlaying) {
				movie.Pause();
				GetComponent<AudioSource> ().Pause ();
				GetComponent<Animator> ().Play ("screen-go-down");
			}
			else {
				movie.Play();
				GetComponent<AudioSource> ().Play ();
				GetComponent<Animator> ().Play ("screen-come-up");
			}
		}
	}
}
