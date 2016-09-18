using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float turnSpeed     = 5.0f;
    float maxTurnLean	= 50.0f;
    float maxTilt       = 50.0f;

    float sensitivity   = 10.0f;
    float forwardForce  = 3.2f;

    public Transform guiSpeedElement;

	public float maxSpeed			= 5.0f;

	public float velocity			= 0.0f;
	public float movement			= 0.0f;
    private float normalizeSpeed    = 2.0f;
    private Vector3 force           = Vector3.zero;

	bool horizontalOrientation      = true;

	// Use this for initialization
	void Start()
	{
		if (horizontalOrientation)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;

		}
		else
		{
			Screen.orientation = ScreenOrientation.Portrait;
		}
		guiSpeedElement.position = new Vector3(0, normalizeSpeed, 0);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.sleepTimeout = 0;
	}

	// Update is called once per frame
	void Update() {
		// Extra-Large Steeped Tea
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		foreach (Touch evt in Input.touches)
		{
			if (evt.phase == TouchPhase.Moved)
			{
				normalizeSpeed = evt.position.y / Screen.height;
				guiSpeedElement.position = new Vector3(0, normalizeSpeed, 0);
			}
		}
	}

	void FixedUpdate() {
		Vector3 accelerator = Input.acceleration;
		velocity = Vector3.Magnitude(GetComponent<Rigidbody>().velocity);

		// Steering accelerations
		var directionalInput = new Vector3(
			Input.acceleration.x,
			Input.acceleration.z,
			Input.acceleration.y
		) * velocity;

		// Rotates the Player
		force.y += accelerator.x * turnSpeed;
        force.z = Mathf.Lerp(force.z, -accelerator.x * maxTurnLean, 0.2f);
        force.x = Mathf.Lerp(force.x, (accelerator.y + 0.6f) * maxTilt * 2, 0.2f);

		// Sets max speed
		if (velocity <= maxSpeed) {
			GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);

		}

		// Rotates the Camera
        Quaternion rot = Quaternion.Euler(force);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, sensitivity);
    }
} 