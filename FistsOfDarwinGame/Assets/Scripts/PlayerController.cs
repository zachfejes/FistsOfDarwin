﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float turnSpeed     = 10.0f;
    float maxTurnLean	= 50.0f;
    float maxTilt       = 50.0f;

    float sensitivity   = 10.0f;
    float forwardForce  = 1.0f;

    Transform guiSpeedElement;

    private float normalizeSpeed    = 0.2f;
    private Vector3 force           = Vector3.zero;

    bool horizontalOrientation      = true;

	// Use this for initialization
	void Start () {
        if (horizontalOrientation) {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        guiSpeedElement.position = new Vector3(0, normalizeSpeed, 0);
	}                                                                                                                                                                                                                                                                                                                                                                                                                    
	
	// Update is called once per frame
	void Update () {
	    foreach (Touch evt in Input.touches) {
            if (evt.phase == TouchPhase.Moved) {
                normalizeSpeed = evt.position.y / Screen.height;
                guiSpeedElement.position = new Vector3 (0, normalizeSpeed, 0);
            }
        }
	}

    void FixedUpdate() {
        normalizeSpeed = 1.0f;

        GetComponent<Rigidbody>().AddRelativeForce(0, 0, normalizeSpeed * forwardForce);

        Vector3 accelerator = Input.acceleration;        

        force.y += accelerator.x * turnSpeed;
        force.z = Mathf.Lerp(force.z, -accelerator.x * maxTurnLean, 0.2f);
        force.x = Mathf.Lerp(force.x, (accelerator.y + 0.6f - 0.6f) * maxTilt, 0.2f);

        Quaternion rot = Quaternion.Euler(force);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, sensitivity);
    }
} 