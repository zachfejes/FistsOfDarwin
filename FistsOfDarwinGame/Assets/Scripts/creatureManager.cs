using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creatureManager : MonoBehaviour {

	GameObject anomalocarisPrefab;
	GameObject aysheaiaPrefab;
	GameObject hallucigeniaPrefab;
	GameObject opabeniaPrefab;
	GameObject trilobitePrefab;
	GameObject amoebaPrefab;
	GameObject wormPrefab;
	GameObject plankton1Prefab;
	GameObject plankton2Prefab;
	GameObject plankton3Prefab;
	GameObject plankton4Prefab;
	GameObject plankton5Prefab;
	GameObject plankton6Prefab;

	public List<GameObject> activeCreatureList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	GameObject addCreature(creatureGeneration.creatureListEnum creatureType) {
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
		activeCreatureList.Add(newCreature);
		return newCreature;
	}

	void removeAllCreatures() {
		activeCreatureList.Clear();
	}
}
