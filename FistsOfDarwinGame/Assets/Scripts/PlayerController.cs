using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float turnSpeed     = 3.0f;
    float maxTurnLean	= 40.0f;
    float maxTilt       = 50.0f;

    float sensitivity   = 3.0f;
    float forwardForce  = 3.2f;

    private Transform player;
	private Rigidbody avatar;
	private float playerMag;

	private float maxSpeed			= 5.0f;
    private float normalizeSpeed    = 2.0f;
    private Vector3 force           = Vector3.zero;
	bool horizontalOrientation      = true;

	// Use this for initialization
	void Start()
	{
		avatar = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();
		player = avatar.transform;

		if (horizontalOrientation) {
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else {
			Screen.orientation = ScreenOrientation.Portrait;
		}
		avatar.angularDrag = 0.25f;
	}

	// Update is called once per frame
	void Update() {
		// Extra-Large Steeped Tea
		// So the freaking screen stops going to sleep, the asshole
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		foreach (Touch evt in Input.touches) {
			if (evt.phase == TouchPhase.Moved) {
				normalizeSpeed = evt.position.y / Screen.height;
			}
		}
	}

	void FixedUpdate() {
		// Creating a Vector3 that takes accelerometer input
		Vector3 accelerator = Input.acceleration;

		// Getting a vector magnitude of the player(avatar)
		playerMag = Vector3.Magnitude(avatar.velocity);

		// Rotates the Player
		force.y += accelerator.x * turnSpeed;
        force.z = Mathf.Lerp(force.z, -accelerator.x * maxTurnLean, 0.2f);
        force.x = Mathf.Lerp(force.x, (accelerator.y + 0.6f) * maxTilt * 2, 0.2f);
	
		// Sets max speed
		if (playerMag <= maxSpeed) {
			avatar.AddForce(player.forward * forwardForce);
		}

		// Applies the rotation
        Quaternion rot = Quaternion.Euler(force);
		player.rotation = Quaternion.Lerp(player.rotation, rot, sensitivity);
    }
}


// Commented out of line 34
//guiSpeedElement.position = new Vector3(0, normalizeSpeed, 0);
//Screen.sleepTimeout = SleepTimeout.NeverSleep;
//Screen.sleepTimeout = 0;
//gameObject.GetComponentInChildren<Rigidbody>().angularDrag = 0.25f;
//gameObject.GetComponent<Rigidbody>().angularDrag = 0.25f;
// Commented out of line 46
//guiSpeedElement.position = new Vector3(0, normalizeSpeed, 0);
// Comment out of line 53
// Steering accelerations
//var directionalInput = new Vector3(
//	Input.acceleration.x,
//	Input.acceleration.z,
//	Input.acceleration.y
//) * velocity;
// Commented out of line 58
//Rigidbody av;
//Transform tf;
// Commente out of line 61
//av = gameObject.GetComponentInChildren<Rigidbody>();
//tf = av.transform;
// Commented out of line 66
//av = gameObject.GetComponentInChildren<Rigidbody>();
//tf = av.transform;