using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creature: MonoBehaviour {
    private Vector3 velocity;
    private GameObject prey;
    private string creatureType;

	struct creatureFeatures {
		public float size;
		public float maxSpeed;
		public float sightRange;
	}
	static private Dictionary<string, creatureFeatures> creatures;

	void Start() {
		creatures = new Dictionary<string, creatureFeatures>();
		creatures.Add("Amoeba", new creatureFeatures { size = 2, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Worm", new creatureFeatures { size = 4, maxSpeed = 1.5f, sightRange = 2 });
		creatures.Add("Aysheaia", new creatureFeatures { size = 8, maxSpeed = 2, sightRange = 3 });
		creatures.Add("Hallucigenia", new creatureFeatures { size = 10, maxSpeed = 3, sightRange = 5 });
		creatures.Add("Opabinia", new creatureFeatures { size = 12, maxSpeed = 4, sightRange = 7 });
		creatures.Add("Anomalocaris", new creatureFeatures { size = 15, maxSpeed = 5, sightRange = 10 });
		creatures.Add("Trilobite", new creatureFeatures { size = 15, maxSpeed = 5, sightRange = 10 });
		creatures.Add("Midstage1", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Midstage2", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Midstage3", new creatureFeatures { size = 1, maxSpeed = 1, sightRange = 1 });
		creatures.Add("Plankton1", new creatureFeatures { size = 1, maxSpeed = 0, sightRange = 0 });
		creatures.Add("Plankton2", new creatureFeatures { size = 1, maxSpeed = 0, sightRange = 0 });
		creatures.Add("Plankton3", new creatureFeatures { size = 1, maxSpeed = 0, sightRange = 0 });
		creatures.Add("Plankton4", new creatureFeatures { size = 1, maxSpeed = 0, sightRange = 0 });
		creatures.Add("Plankton5", new creatureFeatures { size = 1, maxSpeed = 0, sightRange = 0 });
		creatures.Add("Plankton6", new creatureFeatures { size = 1, maxSpeed = 0, sightRange = 0 });
	}

	public void create(string cType) {
        creatureType = cType;
    }

    public Vector3 getDirectionHeading() { return velocity; }

    public void setDirectionHeading(Vector3 newHeading) { velocity = newHeading; }

    public bool hasPrey() { if(prey) { return true; } else { return false; } }

    public GameObject getPrey() { return prey; }

    public void setPrey(GameObject newPrey) { prey = newPrey; }

    public float getMaxSpeed() { return creatures[creatureType].maxSpeed; }

    public float getSightRange() { return creatures[creatureType].sightRange; }

    public float getSize() { return creatures[creatureType].size; }

    public bool CanEat(GameObject potentialPrey) { return potentialPrey.GetComponent<Creature>() && potentialPrey.GetComponent<Creature>().getSize() < creatures[creatureType].size; }

    void OnCollisionEnter(Collision obj) {
        if(CanEat(obj.gameObject)) {
            // Stop Movement
            gameObject.GetComponent<NavMeshAgent>().Stop();
            obj.gameObject.GetComponent<NavMeshAgent>().Stop();
            // Destroy
            Destroy(obj.gameObject);
            // Resume Movement
            gameObject.GetComponent<NavMeshAgent>().Resume();
        }
    }

}