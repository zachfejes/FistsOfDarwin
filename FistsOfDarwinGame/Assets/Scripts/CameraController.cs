using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float smooth = 1.5f;

	// Target that we're following
	private Rigidbody avatar;
	private Transform player;
	// Distance in the x and z planes from the Target
	private float distance			= 7.0f;
	// The height of the Camera above the Target
	private float height			= 5.0f;
	private float heightDamping		= 2.0f;
	private float rotationDamping	= 3.0f;

	void Start() {
		avatar = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
		player = avatar.transform;
	}

	void Update() {

		// Early exit point
		if (!player) {
			print("Shit don't exist.");
			return;
		}
		// Calculating the current rotation angels
		var currentRotatationAngel		= transform.eulerAngles.y;
		var currentHeight				= transform.position.y;

		var wantedRotationAngle			= player.eulerAngles.y;
		var wantedHeight				= player.position.y + height;

	
		// Damping the rotation around the y-axis
		currentRotatationAngel = Mathf.LerpAngle(currentRotatationAngel, wantedRotationAngle, rotationDamping * Time.deltaTime);
	
		// Damping the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Converting the Angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotatationAngel, 0);

		// Seting the position of the camera on the x-z planes to the
		// distance behind the target
		transform.position = player.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Look at the Target
		transform.LookAt(player);
		//SmoothLookAt();

		// Set the Camera height
		//currentHeight = transform.position.y;
	}

	void SmoothLookAt() {
		Vector3 relPlayerPos = player.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPos, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}
}