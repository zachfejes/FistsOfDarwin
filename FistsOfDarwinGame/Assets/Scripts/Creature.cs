using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creature: MonoBehaviour {
    private Vector3 force;
    private GameObject prey;
    private string creatureType;
    private float speed;
    private float size;
    private float sightRange;


	struct creatureFeatures {
		public float size;
		public float maxSpeed;
		public float sightRange;
	}
	static private Dictionary<string, creatureFeatures> creatures;
	void Start() {
		creatures = new Dictionary<string, creatureFeatures>();
		creatures.Add("Anomalocaris", new creatureFeatures { size = 1, maxSpeed =1, sightRange = 1 }) ;
		creatures.Add("Aysheaia", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Hallucigenia", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Opabinia", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Trilobite", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Amoeba", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Worm", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Midstage1", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Midstage3", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Plankton1", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Plankton2", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Plankton3", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Plankton4", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Plankton5", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Plankton6", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });

	}
	public void create(string cType) {
        creatureType = cType;
        size = creatures[cType].size;
    }

    public Vector3 getDirectionHeading() { return force; }

    public void setDirectionHeading(Vector3 newHeading) { force = newHeading; }

    public GameObject getPrey() { return prey; }

    public void setPrey(GameObject newPrey) { prey = newPrey; }

    public float getSightRange() { return sightRange; }

    public float getSize() { return size; }

    public void setSize(float s) { size = s; }

    public float getSpeed() { return speed; }

    public void setSpeed(float sp) { speed = sp; }

    public bool hasPrey() { if(prey) { return true; } else { return false; } }

    public bool CanEat(GameObject potentialPrey) { return potentialPrey.GetComponent<Creature>().getSize() < size; }

}