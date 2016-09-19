using UnityEngine;
using System.Collections;

public class CameraMain : MonoBehaviour {

	public float smooth = 1.5f;

	private Rigidbody avatar;
	private Transform player;
	private Vector3 relCamPos;
	private float relCamPosMag;
	private Vector3 newCamPos;

	void Awake() {
		// allows a method of calling the Empty Player Object, and then making reference
		// to the child object. 
		avatar = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Rigidbody>();

		player = avatar.transform;
		relCamPos = transform.position - player.position;
		relCamPosMag = relCamPos.magnitude - 0.5f;
	}

	void FixedUpdate() {
		// Setting the position of the standard camera, and the top down camera
		Vector3 standardPos = player.position + relCamPos;
		Vector3 abovePos = player.position + Vector3.up * relCamPosMag;
		Vector3[] checkPoints = new Vector3[5];
		checkPoints[0] = standardPos;
		checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
		checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
		checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);
		checkPoints[4] = abovePos;

		for (int i = 0; i < checkPoints.Length; i++) {
			if (ViewingPosCheck(checkPoints[i])) {
				break;
			}
		}
		transform.position = Vector3.Lerp(transform.position, newCamPos, smooth * Time.deltaTime);
		SmoothLookAt();
	}

	bool ViewingPosCheck(Vector3 checkPos) {
		RaycastHit hit;

		if (Physics.Raycast(checkPos, player.position - checkPos, out hit, relCamPosMag)) {
			if (hit.transform != player) {
				return false;
			}
		}
		newCamPos = checkPos;
		return true;
	}

	void SmoothLookAt() {
		Vector3 relPlayerPos = player.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPos, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}

}
