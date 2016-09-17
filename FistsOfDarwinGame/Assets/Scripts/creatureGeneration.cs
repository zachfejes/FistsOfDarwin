using UnityEngine;
using System.Collections;

public class creatureGeneration : MonoBehaviour {

	public timeScaleUpdate worldState;

	timeScaleUpdate.timePeriodEnum worldEra;
	timeScaleUpdate.timePeriodEnum playerEra;
	// Use this for initialization
	void Start () {
		worldEra = worldState.worldEra;
		playerEra = worldState.worldEra;
	}
	
	// Update is called once per frame
	void Update () {
		if (worldState.worldEra != worldEra)
			Debug.Log("We've switched Eras!");
		worldEra = worldState.worldEra;

		if (worldState.playerEra != playerEra)
			Debug.Log("Level Up!");
		playerEra = worldState.playerEra;
	}
}
