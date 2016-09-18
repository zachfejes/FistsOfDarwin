using UnityEngine;
using System.Collections;

public class playerState : MonoBehaviour {

	public timeScaleUpdate worldState;

	public GameObject avatar;

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
			Vector3 loc = avatar.transform.position;
			PlayerController pc = avatar.GetComponent<PlayerController>();

			//swap out avatar
			if (!worldState.gameIsActive())
				;
			//somehow remove avatar
			if (playerEra == timePeriod.timePeriodEnum.cambrianStage2) {
				avatar = Instantiate(creatures.amoebaPrefab);
				avatar.transform.position = loc;
				avatar.AddComponent<PlayerController>();
			}
			if (playerEra == timePeriod.timePeriodEnum.cambrianStage4) {
				avatar = Instantiate(creatures.wormPrefab);
				avatar.transform.position = loc;
				avatar.AddComponent<PlayerController>();
			}
			if (playerEra == timePeriod.timePeriodEnum.cambrianStage5) {
				avatar = Instantiate(creatures.trilobitePrefab);
				avatar.transform.position = loc;
				avatar.AddComponent<PlayerController>();
			}
		}
		playerEra = worldState.playerEra;

			

	}
}
