using UnityEngine;
using System.Collections;

public class PreyDetection : MonoBehaviour {
    private Creature hostCreature;
    public bool foundPrey;

    GameObject canvas;
    // Use this for initialization
    void Start () {
        hostCreature = gameObject.GetComponent<Creature>();
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        // get the forward vector of the player's camera
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Vector3 origin = transform.position;// + hostCreature.center;

        // Detect prey forward sphere
        if(Physics.SphereCast(origin, hostCreature.getSightRange(), transform.forward, out hit, hostCreature.getSightRange())) {
            if(hostCreature.CanEat(hit.collider.gameObject)) {
                hostCreature.setPrey(hit.collider.gameObject);
            }
        }

        // TODO: Detect predator around
        // if(Physics.SphereCastAll(origin, hostCreature.getSightRange(), transform.forward, out hit, hostCreature.getSightRange())) {
        //     if(hostCreature.CanEat(hit.collider.gameObject)) {
        //         hostCreature.setPrey(hit.collider.gameObject);
        //     }
        // }

    }

}