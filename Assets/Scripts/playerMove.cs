using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	float currY;

	void Update () {
		if (Input.GetMouseButton(0)) {
			currY = transform.position.y;
			transform.position = transform.position + Camera.main.transform.forward * .05f;
			transform.position = new Vector3 (transform.position.x, currY, transform.position.z);
		}
	}
}
