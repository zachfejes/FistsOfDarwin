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

	//public float distance			= 5.0f;
	//public float height				= 2.0f;
	//public float damping			= 3.0f;
	//public bool smoothRotation		= false;
	//public bool followBehind		= false;
	//public float rotationDamping	= 10.0f;

	void Update() {

		// Early exit point
		if (!target) {
			print("Shit don't exist.");
			return;
		}
		// Calculating the current rotation angels
		var wantedRotationAngle		= target.eulerAngles.y;
		var wantedHeight			= target.position.y + height;

		var currentRotatationAngel	= transform.eulerAngles.y;
		var currentHeight			= transform.position.y;

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





		//followBehind = true;
		//Vector3 desiredPosition;
		//if (followBehind) {
		//	desiredPosition = target.TransformPoint(0, height, -distance);
		//}
		//else {
		//	desiredPosition = target.TransformPoint(0, height, distance);
		//}
		//transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
		//if (smoothRotation) {
		//	Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
		//	transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationDamping);
		//}
		//else {
		//	transform.LookAt(target, target.up);
		//}

	}
}

//public class CameraController : MonoBehaviour {

//	void Update()
//	{
//		Vector3 wantedPosition;
//		if (followBehind) {
//			wantedPosition = target.TransformPoint(0, height, -distance);
//		}
//		else {
//			wantedPosition = target.TransformPoint(0, height, distance);
//		}

//		transform.position = Vector3.Slerp(transform.position, wantedPosition, Time.deltaTime * damping);

//		if (smoothRotation)
//		{
//			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
//			transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
//		}
//		else transform.LookAt(target, target.up);
//	}

//	/*	public Transform target;    // The target we are following
//		public float distance;      // The distance from the target along its Z axis
//		public float height;        // the height we want the camera to be above the target
//		public float positionDamping;   // how quickly we should get to the target position
//		public float rotationDamping;   // how quickly we should get to the target rotation
//		Rigidbody rBody;

//		void Awake()
//		{
//			rBody = GetComponent<Rigidbody>();
//		}

//		// Use this for public variable initialization
//		public void Reset()
//		{
//			distance = 3.0f;
//			height = 0.1f;
//			positionDamping = 6.0f;
//			rotationDamping = 60.0f;
//		}

//		// LateUpdate is called once per frame
//		public void FixedUpdate()
//		{
//			ensureReferencesAreIntact();
//			#region Get Transform Manipulation
//			// The desired position
//			Vector3 targetPosition = target.position + target.up * height - target.forward * distance;
//			// The desired rotation
//			Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
//			#endregion

//			#region Manipulate Transform
//			rBody.position = Vector3.MoveTowards(rBody.position, targetPosition, positionDamping * Time.deltaTime);
//			rBody.rotation = Quaternion.RotateTowards(rBody.rotation, targetRotation, rotationDamping * Time.deltaTime);
//			#endregion
//		}

//		// Checks to make sure all required references still exist and disables the script if not
//		private void ensureReferencesAreIntact()
//		{
//			if (target == null)
//			{
//				Debug.LogError("No target is set in the SmoothFollow Script attached to " + name);
//				this.enabled = false;
//			}
//		}*/

//	/*GameObject playerObject;
//	// Use this for initialization
//	void Start()
//	{
//		playerObject = GameObject.FindGameObjectWithTag("Player");
//	}

//	// Update is called once per frame
//	void Update()
//	{
//		if (playerObject != null)
//		{
//			print("Shit Exists");
//		}
//		else
//		{
//			print("Shit doesn't exist");
//			return;
//		}

//		Vector3 directionVector;

//		directionVector = new Vector3(playerObject.transform.position.x - transform.position.x, playerObject.transform.position.y - transform.position.y, playerObject.transform.position.z - transform.position.z);
//		directionVector.Normalize();
//		//Debug.Log("directionVector Vector: ", "+ directionVector.x + ", "+ directionVector.y", " + directionVector.z");
//		transform.rotation = Quaternion.LookRotation(directionVector);

//	}*/
//}
