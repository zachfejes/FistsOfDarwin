using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float distance = 3.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;

	void Update()
	{
		Vector3 wantedPosition;
		if (followBehind) {
			wantedPosition = target.TransformPoint(0, height, -distance);
		}
		else {
			wantedPosition = target.TransformPoint(0, height, distance);
		}

		transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

		if (smoothRotation)
		{
			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else transform.LookAt(target, target.up);
	}

	/*	public Transform target;    // The target we are following
		public float distance;      // The distance from the target along its Z axis
		public float height;        // the height we want the camera to be above the target
		public float positionDamping;   // how quickly we should get to the target position
		public float rotationDamping;   // how quickly we should get to the target rotation
		Rigidbody rBody;

		void Awake()
		{
			rBody = GetComponent<Rigidbody>();
		}

		// Use this for public variable initialization
		public void Reset()
		{
			distance = 3.0f;
			height = 0.1f;
			positionDamping = 6.0f;
			rotationDamping = 60.0f;
		}

		// LateUpdate is called once per frame
		public void FixedUpdate()
		{
			ensureReferencesAreIntact();
			#region Get Transform Manipulation
			// The desired position
			Vector3 targetPosition = target.position + target.up * height - target.forward * distance;
			// The desired rotation
			Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			#endregion

			#region Manipulate Transform
			rBody.position = Vector3.MoveTowards(rBody.position, targetPosition, positionDamping * Time.deltaTime);
			rBody.rotation = Quaternion.RotateTowards(rBody.rotation, targetRotation, rotationDamping * Time.deltaTime);
			#endregion
		}

		// Checks to make sure all required references still exist and disables the script if not
		private void ensureReferencesAreIntact()
		{
			if (target == null)
			{
				Debug.LogError("No target is set in the SmoothFollow Script attached to " + name);
				this.enabled = false;
			}
		}*/

	/*GameObject playerObject;
	// Use this for initialization
	void Start()
	{
		playerObject = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		if (playerObject != null)
		{
			print("Shit Exists");
		}
		else
		{
			print("Shit doesn't exist");
			return;
		}

		Vector3 directionVector;

		directionVector = new Vector3(playerObject.transform.position.x - transform.position.x, playerObject.transform.position.y - transform.position.y, playerObject.transform.position.z - transform.position.z);
		directionVector.Normalize();
		//Debug.Log("directionVector Vector: ", "+ directionVector.x + ", "+ directionVector.y", " + directionVector.z");
		transform.rotation = Quaternion.LookRotation(directionVector);

	}*/
}
