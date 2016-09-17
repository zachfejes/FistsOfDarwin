using UnityEngine;
using System.Collections;

public class playerState : MonoBehaviour {

	public timeScaleUpdate worldState;

	timePeriod.timePeriodEnum playerEra;
	// Use this for initialization
	void Start () {
		playerEra = worldState.playerEra;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (worldState.playerEra != playerEra)
			Debug.Log("Level Up!");
		playerEra = worldState.playerEra;

	}
}
