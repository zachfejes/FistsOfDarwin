using UnityEngine;
using System.Collections;

public class Creature: MonoBehaviour {
    private Vector3 force;
    private GameObject prey;
    private string creatureType;
    private float speed;
    private float size;
    private float sightRange;

    private Dictionary<string, Dictionary<string, float>> creatures = new Dictionary<string, Dictionary<string, float>>() {
        //TODO fill {type,info{size, maxSpeed, sightRange}}
        {},
    };

    public void create(string cType) {
        creatureType = cType;
        size = creatures[cType]["size"];
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