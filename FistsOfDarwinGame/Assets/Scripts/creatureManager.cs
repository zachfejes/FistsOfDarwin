using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creatureManager : MonoBehaviour {

	public GameObject anomalocarisPrefab;
	public GameObject aysheaiaPrefab;
	public GameObject hallucigeniaPrefab;
	public GameObject opabeniaPrefab;
	public GameObject trilobitePrefab;
	public GameObject amoebaPrefab;
	public GameObject wormPrefab;
	public GameObject plankton1Prefab;
	public GameObject plankton2Prefab;
	public GameObject plankton3Prefab;
	public GameObject plankton4Prefab;
	public GameObject plankton5Prefab;
	public GameObject plankton6Prefab;

	public List<GameObject> activeCreatureList;

	public creatureGeneration creatureGenControl;

	// Use this for initialization
	void Start () {
		creatureGenControl.createCreatureEvent.AddListener(addCreature);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addCreature(creatureGeneration.creatureListEnum creatureType) {
		GameObject newCreature;// = new GameObject(creatureGeneration.getCreatureTypeString(creatureType));
		switch (creatureType) {
			case creatureGeneration.creatureListEnum.Anomalocaris:
				newCreature = Instantiate(anomalocarisPrefab);
				break;
			case creatureGeneration.creatureListEnum.Aysheaia:
				newCreature = Instantiate(aysheaiaPrefab);
				break;
			case creatureGeneration.creatureListEnum.Hallucigenia:
				newCreature = Instantiate(hallucigeniaPrefab);
				break;
			case creatureGeneration.creatureListEnum.Opabinia:
				newCreature = Instantiate(opabeniaPrefab);
				break;
			case creatureGeneration.creatureListEnum.Trilobite:
				newCreature = Instantiate(trilobitePrefab);
				break;
			case creatureGeneration.creatureListEnum.Amoeba:
				newCreature = Instantiate(amoebaPrefab);
				break;
			case creatureGeneration.creatureListEnum.Worm:
				newCreature = Instantiate(wormPrefab);
				break;
			case creatureGeneration.creatureListEnum.Midstage1:
				newCreature = Instantiate(plankton1Prefab);
				break;
			case creatureGeneration.creatureListEnum.Midstage2:
				newCreature = Instantiate(plankton2Prefab);
				break;
			case creatureGeneration.creatureListEnum.Midstage3:
				newCreature = Instantiate(plankton3Prefab);
				break;
			case creatureGeneration.creatureListEnum.Plankton1:
				newCreature = Instantiate(plankton1Prefab);
				break;
			case creatureGeneration.creatureListEnum.Plankton2:
				newCreature = Instantiate(plankton2Prefab);
				break;
			case creatureGeneration.creatureListEnum.Plankton3:
				newCreature = Instantiate(plankton3Prefab);
				break;
			case creatureGeneration.creatureListEnum.Plankton4:
				newCreature = Instantiate(plankton4Prefab);
				break;
			case creatureGeneration.creatureListEnum.Plankton5:
				newCreature = Instantiate(plankton5Prefab);
				break;
			case creatureGeneration.creatureListEnum.Plankton6:
				newCreature = Instantiate(plankton6Prefab);
				break;
			default:
				newCreature = Instantiate(plankton4Prefab);
				break;
		}
		System.Random randGen = new System.Random();
		Vector3 spawn = new Vector3((float)randGen.NextDouble()*300+100, (float)randGen.NextDouble()*60+20, (float)randGen.NextDouble() * 300 + 100);
		newCreature.transform.position = spawn;
		//newCreature.AddComponent<NavMeshAgent>();
		newCreature.AddComponent<Creature>();
		newCreature.GetComponent<Creature>().create(creatureGeneration.getCreatureTypeString(creatureType));
		newCreature.AddComponent<PreyDetection>();
		activeCreatureList.Add(newCreature);
		//return newCreature;
	}

	void removeAllCreatures() {
		activeCreatureList.Clear();
	}
}
