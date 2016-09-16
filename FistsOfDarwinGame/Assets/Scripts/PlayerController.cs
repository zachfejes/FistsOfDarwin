using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float turnSpeed     = 10.0f;
    float maxTurnLean   = 50.0f;
    float maxTilt       = 50.0f;

    float sensitivity   = 10.0f;
    float forwardForce  = 1.0f;

    Transform guiSpeedElement;

    private float normalizeSpeed    = 0.2f;
    private Vector3 force           = Vector3.zero;

    bool horizontalOrientation = true;

	// Use this for initialization
	void Start () {
        if (horizontalOrientation) {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else {
            Screen.orientation = ScreenOrientation.Portrait;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    for ()
	}
}