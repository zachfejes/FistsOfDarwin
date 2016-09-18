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
		Anomalocaris,
		Aysheaia,
		Hallucigenia,
		Opabinia,
		Trilobite,
		Amoeba,
		Worm,
		Midstage1,
		Midstage2,
		Midstage3,
		Plankton
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
// Evolution Tree
// | Era 1 | Era 2 |   Era 3       |    Era 4    |   Era 5   |  Era 6
// Amoeba --- Worm	--- Aysheaia
//					\-- Midstage1 --- Hallucigenia
//								  \-- Midstage2 --- Opabinia
//												\-- Midstage3 --- Anomalocaris
//															  \-- Trilobite
	public void createCreature()
	{
		Debug.Log("Spawn a dude!");

		//pick a creature type
		creatureListEnum spawnCreatureType;
		System.Random randGen = new System.Random();
		double randD = randGen.NextDouble();

		switch (worldEra) {
			case timePeriod.timePeriodEnum.cambrianStage2:
				if (randD < .9)
					spawnCreatureType = creatureListEnum.Plankton;
				else
					spawnCreatureType = creatureListEnum.Amoeba;
				break;
			case timePeriod.timePeriodEnum.cambrianStage2x:
				if (randD < .7)
					spawnCreatureType = creatureListEnum.Plankton;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Amoeba;
				else
					spawnCreatureType = creatureListEnum.Worm;
				break;
			case timePeriod.timePeriodEnum.cambrianStage3:
				if (randD < .6)
					spawnCreatureType = creatureListEnum.Plankton;
				else if (randD < .8)
					spawnCreatureType = creatureListEnum.Worm;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Aysheaia;
				else
					spawnCreatureType = creatureListEnum.Midstage1;
				break;
			case timePeriod.timePeriodEnum.cambrianStage3x:
				if (randD < .5)
					spawnCreatureType = creatureListEnum.Plankton;
				else if (randD < .65)
					spawnCreatureType = creatureListEnum.Aysheaia;
				else if (randD < .8)
					spawnCreatureType = creatureListEnum.Midstage1;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Hallucigenia;
				else
					spawnCreatureType = creatureListEnum.Midstage2;
				break;
			case timePeriod.timePeriodEnum.cambrianStage4:
				if (randD < .5)
					spawnCreatureType = creatureListEnum.Plankton;
				else if (randD < .65)
					spawnCreatureType = creatureListEnum.Hallucigenia;
				else if (randD < .8)
					spawnCreatureType = creatureListEnum.Midstage2;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Opabinia;
				else
					spawnCreatureType = creatureListEnum.Midstage3;
				break;
			case timePeriod.timePeriodEnum.cambrianStage5:
				if (randD < .5)
					spawnCreatureType = creatureListEnum.Plankton;
				else if (randD < .65)
					spawnCreatureType = creatureListEnum.Opabinia;
				else if (randD < .8)
					spawnCreatureType = creatureListEnum.Midstage3;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Anomalocaris;
				else
					spawnCreatureType = creatureListEnum.Trilobite;
				break;
		}

		//Add Actor to mesh?
	}

	string getCreatureTypeString(creatureListEnum type) {
		switch (type) {
			case creatureListEnum.Anomalocaris:
				return "Anomalocaris";
			case creatureListEnum.Aysheaia:
				return "Aysheaia";
			case creatureListEnum.Hallucigenia:
				return "Hallucigenia";
			case creatureListEnum.Opabinia:
				return "Opabinia";
			case creatureListEnum.Trilobite:
				return "Trilobite";
			case creatureListEnum.Amoeba:
				return "Amoeba";
			case creatureListEnum.Worm:
				return "Worm";
			case creatureListEnum.Midstage1:
				return "Midstage1";
			case creatureListEnum.Midstage2:
				return "Midstage2";
			case creatureListEnum.Midstage3:
				return "Midstage3";
			case creatureListEnum.Plankton:
				return "Plankton";
			default: return "";

		}
	}
}
