using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {

	private Rigidbody avatar;
	private Transform player;
	private float damping	= 6.0f;
	public bool smooth		= true;

	// Update is called once per frame
	void LateUpdate () {
	if (smooth) {
			// Look at and Dampen the rotation
			var rotation = Quaternion.LookRotation(player.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);			
		}
		else {
			// Just Look
			transform.LookAt(player);
		}
	}
	
	// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
		player = avatar.transform;

		// Make the rigid body not change rotation
		if (avatar) {
			avatar.freezeRotation = true;
		}
	}
	void SmoothLookAt()
	{
		float smooth = 1.5f;

		Vector3 relPlayerPos = player.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPos, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}
}
