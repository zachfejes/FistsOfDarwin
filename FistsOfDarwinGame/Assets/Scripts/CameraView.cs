using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {

	public Transform target;
	public float damping	= 6.0f;
	public bool smooth		= true;

	// Update is called once per frame
	void LateUpdate () {
	if (smooth) {
			// Look at and Dampen the rotation
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);			
		}
		else {
			// Just Look
			transform.LookAt(target);
		}
	}
	
	// Use this for initialization
	void Start () {
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>()) {
			GetComponent<Rigidbody>().freezeRotation = true;
		}
	}
}
