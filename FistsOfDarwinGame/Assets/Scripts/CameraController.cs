using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Target that we're following
	public Transform target;
	// Distance in the x and z planes from the Target
	public float distance			= 7.0f;
	// The height of the Camera above the Target
	public float height				= 5.0f;

	public float heightDamping		= 2.0f;
	public float rotationDamping	= 3.0f;


	void Update() {

		// Early exit point
		if (!target) {
			print("Shit don't exist.");
			return;
		}
		// Calculating the current rotation angels
		var wantedRotationAngle			= target.eulerAngles.y;
		var wantedHeight				= target.position.y + height;

		var currentRotatationAngel		= transform.eulerAngles.y;
		var currentHeight				= transform.position.y;

		
		// Damping the rotation around the y-axis
		currentRotatationAngel = Mathf.LerpAngle(currentRotatationAngel, wantedRotationAngle, rotationDamping * Time.deltaTime);
	
		// Damping the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Converting the Angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotatationAngel, 0);

		// Seting the position of the camera on the x-z planes to the
		// distance behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the Camera height
		currentHeight = transform.position.y;

		// Look at the Target
		transform.LookAt(target);
	}
}