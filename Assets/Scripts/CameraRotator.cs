using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour 
{
	public float speed;
	[Range(-15f, -50f)]
	public float camDistance = -20;
	Transform tr;
	Transform cam;
	bool rotate = false;

	void Awake () 
	{
		tr = transform;
		cam = Camera.main.transform;
	}
	
	void Update () 
	{
		Vector3 newDist = cam.localPosition;
		newDist.z = camDistance;
		cam.localPosition = newDist;

		if (rotate) {
			Vector3 newRot = tr.eulerAngles;
			newRot.y += Time.deltaTime * speed;
			tr.eulerAngles = newRot;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			rotate = !rotate;
		}
	}
}
