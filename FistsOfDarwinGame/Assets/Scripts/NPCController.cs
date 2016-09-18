using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    private GameObject prey;
    private Creature hostCreature;
    private PreyDetection preyDetect;

    float speed = 5.0f;
    Vector3 wayPoint;
    const float FLOORHEIGHT = 10;
    const float DISTNEWWP = 3;

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void Start() {
        hostCreature = gameObject.GetComponent<Creature>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        preyDetect = gameObject.GetComponent<PreyDetection>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if(timer >= wanderTimer) {
            if(!hostCreature.hasPrey()) {
                // TODO: follow prey

                agent.SetDestination(prey.transform.position);
            }
            // Wander
            Vector3 newPos = RandNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandNavSphere(Vector3 origin, float distance, int layerMask) {
        Vector3 randDir = UnityEngine.Random.insideUnitSphere * distance;

        randDir += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition (randDir, out navHit, distance, layerMask);

        return navHit.position;
    }


}
