using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    private Creature hostCreature;
    private PreyDetection preyDetect;

    float speed = 5.0f;
    Vector3 wayPoint;
    const float FLOORHEIGHT = 10;
    const float DISTNEWWP = 3;

    public float wanderRadius;
    public float wanderTimer;

    public float loseInterestTimer = 60.0f;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void Start() {
        hostCreature = gameObject.GetComponent<Creature>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        preyDetect = gameObject.GetComponent<PreyDetection>();

        timer = wanderTimer;
        wanderRadius = 10.0f;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if(hostCreature.hasPrey()) {
            if(timer < loseInterestTimer) {
                agent.SetDestination(pursue(hostCreature.getPrey()));
                gameObject.transform.LookAt(hostCreature.getPrey().transform.position);
            } else {
                hostCreature.setPrey(null);
            }
        } else {
            if(timer >= wanderTimer) {
                // Wander
                Vector3 newPos = RandNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    public static Vector3 RandNavSphere(Vector3 origin, float distance, int layerMask) {
        Vector3 randDir = UnityEngine.Random.insideUnitSphere * distance;

        randDir += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition (randDir, out navHit, distance, layerMask);

        return navHit.position;
    }

    public Vector3 pursue(GameObject p) {
        Vector3 distance = p.transform.position - transform.position;
        float T = distance.magnitude / hostCreature.getMaxSpeed();
        Vector3 futurePos = p.transform.position + p.GetComponent<NavMeshAgent>().velocity * T;
        return futurePos;
    }

    // TODO: Evade predator if it is close
    // public Vector3 evade(GameObject pred) {
    //     Vector3 distance = pred.transform.position - transform.position;
    //     float updatesAhead = distance.magnitude / hostCreature.getMaxSpeed();
    //     Vector3 futurePosition = pred.transform.position + pred.velocity * updatesAhead;
    //     return futurePos;
    // }

}
