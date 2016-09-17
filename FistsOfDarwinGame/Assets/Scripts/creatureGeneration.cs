using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class creatureGeneration : MonoBehaviour {

	public timeScaleUpdate worldState;
	public float TIMEBETWEENSPAWNS = 5.0f;

	float timeSinceLastSpawn;

	public UnityEvent createCreatureEvent;

	public enum creatureListEnum 
	{
		creature1,
		creature2,
		creature3,
		creature4,
		creature5,
		creature6,
		creature7,
		creature8,
		creautre9,
		creature10,
		creatureMidway1to2
	};

	timePeriod.timePeriodEnum worldEra;
	// Use this for initialization
	void Start () {
		worldEra = worldState.worldEra;
		timeSinceLastSpawn = TIMEBETWEENSPAWNS;
	}
	
	// Update is called once per frame
	void Update () {
		if (worldState.worldEra != worldEra)
			Debug.Log("We've switched Eras!");
		worldEra = worldState.worldEra;

		if (worldState.gameIsActive())
		{
			timeSinceLastSpawn -= Time.deltaTime;
			if (timeSinceLastSpawn < 0)
			{
				timeSinceLastSpawn = TIMEBETWEENSPAWNS;
				createCreatureEvent.Invoke();
			}
		}
	}

	public void createCreature()
	{
		Debug.Log("Spawn a dude!");
	}
}
