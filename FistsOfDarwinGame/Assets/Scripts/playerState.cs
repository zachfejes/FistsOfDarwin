using UnityEngine;
using System.Collections;

public class playerState : MonoBehaviour {

	public timeScaleUpdate worldState;

	public PlayerController avatar;

	public creatureManager creatures;

	timePeriod.timePeriodEnum playerEra;
	// Use this for initialization
	void Start () {
		playerEra = worldState.playerEra;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (worldState.playerEra != playerEra) {
			Debug.Log("Level Up!");
			Vector3 loc = avatar.gameObject.GetComponentInChildren<Transform>().position;
			//PlayerController pc = avatar.GetComponent<PlayerController>();

			GameObject newavatar;

			//swap out avatar
			//	if (!worldState.gameIsActive())
			//		;
			Transform[] ta = avatar.gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform t in ta)
				if (t.transform != avatar.transform)
					Destroy(t.gameObject);
			//somehow remove avatar
			if (worldState.playerEra == timePeriod.timePeriodEnum.cambrianStage2) {
				newavatar = Instantiate(creatures.amoebaPrefab);
				newavatar.transform.position = loc;
				newavatar.transform.parent = avatar.transform;
			}
			if (worldState.playerEra == timePeriod.timePeriodEnum.cambrianStage4) {
				newavatar = Instantiate(creatures.wormPrefab);
				newavatar.transform.position = loc;
				newavatar.transform.parent = avatar.transform;
			}
			if (worldState.playerEra == timePeriod.timePeriodEnum.cambrianStage5) {
				newavatar = Instantiate(creatures.trilobitePrefab);
				newavatar.transform.position = loc;
				newavatar.transform.parent = avatar.transform;
			}
		}
		playerEra = worldState.playerEra;

			

	}
}
