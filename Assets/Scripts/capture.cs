using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capture : MonoBehaviour {

	public int resWidth = 1920; 
	public int resHeight = 1080;

	public int frameRate = 24;
	public string folder = "ScreenshotFolder";

	public bool RecVideo = false;

	void Start() {
		// Set the playback framerate (real time will not relate to game time after this).
		Time.captureFramerate = frameRate;

		// Create the folder
		System.IO.Directory.CreateDirectory(folder);
	}

	public string ScreenShotName() {
		return string.Format("{0}/frame{1:D04}.png", folder, Time.frameCount);
	}


	void Update() {

		if (Input.GetKeyDown ("s")) {
			DoScreengrab ();
		}

		// for video mode automatically grab sequential shots
		if (RecVideo) {
			DoScreengrab ();
		}

	}

	void DoScreengrab() {
		RenderTexture rt = new RenderTexture (resWidth, resHeight, 24);
		GetComponent<Camera> ().targetTexture = rt;
		Texture2D screenShot = new Texture2D (resWidth, resHeight, TextureFormat.RGB24, false);
		GetComponent<Camera> ().Render ();
		RenderTexture.active = rt;
		screenShot.ReadPixels (new Rect (0, 0, resWidth, resHeight), 0, 0);
		GetComponent<Camera> ().targetTexture = null;
		RenderTexture.active = null; // JC: added to avoid errors

		byte[] bytes = screenShot.EncodeToPNG ();
		string filename = ScreenShotName ();
		System.IO.File.WriteAllBytes (filename, bytes);

		// clean up!
		Destroy (rt);
		Destroy (screenShot);
	}
}