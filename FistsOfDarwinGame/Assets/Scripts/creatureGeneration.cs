using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class createCreatureEventClass : UnityEvent<creatureGeneration.creatureListEnum> { };

public class creatureGeneration : MonoBehaviour {

	public timeScaleUpdate worldState;
	public float TIMEBETWEENSPAWNS = 1.0f;

	float timeSinceLastSpawn;

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
		Plankton1,
		Plankton2,
		Plankton3,
		Plankton4,
		Plankton5,
		Plankton6
	};

	public createCreatureEventClass createCreatureEvent;

	timePeriod.timePeriodEnum worldEra;

	// Use this for initialization
	void Start () {
		worldEra = worldState.worldEra;
		timeSinceLastSpawn = TIMEBETWEENSPAWNS;
		worldState.eraChanged.AddListener(createCreatureEraChange);
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
				createCreature();
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
		//pick a creature type
		creatureListEnum spawnCreatureType;
		System.Random randGen = new System.Random();
		double randD = randGen.NextDouble();
		double planktonOdds;

		switch (worldEra) {
			case timePeriod.timePeriodEnum.cambrianStage2:
				planktonOdds = 0.9;
				if (randD < planktonOdds/6)
					spawnCreatureType = creatureListEnum.Plankton1;
				else if (randD < planktonOdds * 2 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton2;
				else if (randD < planktonOdds * 3 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton3;
				else if (randD < planktonOdds * 4 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton4;
				else if (randD < planktonOdds * 5 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton5;
				else if (randD < planktonOdds)
					spawnCreatureType = creatureListEnum.Plankton6;
				else
					spawnCreatureType = creatureListEnum.Amoeba;
				break;
			case timePeriod.timePeriodEnum.cambrianStage2x:
				planktonOdds = 0.7;
				if (randD < planktonOdds / 6)
					spawnCreatureType = creatureListEnum.Plankton1;
				else if (randD < planktonOdds * 2 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton2;
				else if (randD < planktonOdds * 3 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton3;
				else if (randD < planktonOdds * 4 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton4;
				else if (randD < planktonOdds * 5 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton5;
				else if (randD < planktonOdds)
					spawnCreatureType = creatureListEnum.Plankton6;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Amoeba;
				else
					spawnCreatureType = creatureListEnum.Worm;
				break;
			case timePeriod.timePeriodEnum.cambrianStage3:
				planktonOdds = 0.6;
				if (randD < planktonOdds / 6)
					spawnCreatureType = creatureListEnum.Plankton1;
				else if (randD < planktonOdds * 2 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton2;
				else if (randD < planktonOdds * 3 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton3;
				else if (randD < planktonOdds * 4 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton4;
				else if (randD < planktonOdds * 5 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton5;
				else if (randD < planktonOdds)
					spawnCreatureType = creatureListEnum.Plankton6;
				else if (randD < .8)
					spawnCreatureType = creatureListEnum.Worm;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Aysheaia;
				else
					spawnCreatureType = creatureListEnum.Midstage1;
				break;
			case timePeriod.timePeriodEnum.cambrianStage3x:
				planktonOdds = 0.5;
				if (randD < planktonOdds / 6)
					spawnCreatureType = creatureListEnum.Plankton1;
				else if (randD < planktonOdds * 2 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton2;
				else if (randD < planktonOdds * 3 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton3;
				else if (randD < planktonOdds * 4 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton4;
				else if (randD < planktonOdds * 5 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton5;
				else if (randD < planktonOdds)
					spawnCreatureType = creatureListEnum.Plankton6;
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
				planktonOdds = 0.5;
				if (randD < planktonOdds / 6)
					spawnCreatureType = creatureListEnum.Plankton1;
				else if (randD < planktonOdds * 2 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton2;
				else if (randD < planktonOdds * 3 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton3;
				else if (randD < planktonOdds * 4 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton4;
				else if (randD < planktonOdds * 5 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton5;
				else if (randD < planktonOdds)
					spawnCreatureType = creatureListEnum.Plankton6;
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
				planktonOdds = 0.5;
				if (randD < planktonOdds / 6)
					spawnCreatureType = creatureListEnum.Plankton1;
				else if (randD < planktonOdds * 2 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton2;
				else if (randD < planktonOdds * 3 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton3;
				else if (randD < planktonOdds * 4 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton4;
				else if (randD < planktonOdds * 5 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton5;
				else if (randD < planktonOdds)
					spawnCreatureType = creatureListEnum.Plankton6;
				else if (randD < .65)
					spawnCreatureType = creatureListEnum.Opabinia;
				else if (randD < .8)
					spawnCreatureType = creatureListEnum.Midstage3;
				else if (randD < .9)
					spawnCreatureType = creatureListEnum.Anomalocaris;
				else
					spawnCreatureType = creatureListEnum.Trilobite;
				break;
			default:
				planktonOdds = 1;
				if (randD < planktonOdds / 6)
					spawnCreatureType = creatureListEnum.Plankton1;
				else if (randD < planktonOdds * 2 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton2;
				else if (randD < planktonOdds * 3 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton3;
				else if (randD < planktonOdds * 4 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton4;
				else if (randD < planktonOdds * 5 / 6.0)
					spawnCreatureType = creatureListEnum.Plankton5;
				else
					spawnCreatureType = creatureListEnum.Plankton6;
				break;
		}

		Debug.Log("Spawn a dude! (" + getCreatureTypeString(spawnCreatureType) +")");
		createCreatureEvent.Invoke(spawnCreatureType);
		//Add Actor to mesh?
	}

	public void createCreature(int n) {
		for (int i=0; i< n; i++) {
			createCreature();
		}
	}

	public void createCreatureEraChange() {
		Debug.Log("Populating after era change!");
		if (worldState.gameIsActive())
			createCreature(10);
	}

	public string getCreatureTypeString(creatureListEnum type) {
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
			case creatureListEnum.Plankton1:
				return "Plankton";
			case creatureListEnum.Plankton2:
				return "Plankton";
			case creatureListEnum.Plankton3:
				return "Plankton";
			case creatureListEnum.Plankton4:
				return "Plankton";
			case creatureListEnum.Plankton5:
				return "Plankton";
			case creatureListEnum.Plankton6:
				return "Plankton";
			default: return "";

		}
	}
}
