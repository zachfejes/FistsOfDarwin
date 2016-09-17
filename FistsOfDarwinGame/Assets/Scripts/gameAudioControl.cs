using UnityEngine;
using System.Collections;

public class gameAudioControl : MonoBehaviour {

	public AudioSource splashAudio;
	public AudioSource gameAudio;
	public AudioSource endgameAudio;

	public timeScaleUpdate worldState;

	float AUDIOFADETIME = 5.0f;
	float splashgamefade;
	float gameendfade;

	// Use this for initialization
	void Start () {
		splashgamefade = 0;
		gameendfade = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (splashgamefade > 0)	{
			splashgamefade -= Time.deltaTime;
			if (!gameAudio.isPlaying) gameAudio.Play();
			gameAudio.volume = 1 - (splashgamefade / AUDIOFADETIME);
			splashAudio.volume = splashgamefade / AUDIOFADETIME;

		}
		else if (gameAudio.isPlaying){
			splashAudio.Stop();
		}

		if (gameendfade > 0) {
			gameendfade -= Time.deltaTime;
			if (!endgameAudio.isPlaying) endgameAudio.Play();
			endgameAudio.volume = 1 - (gameendfade / AUDIOFADETIME);
			gameAudio.volume = gameendfade / AUDIOFADETIME;

		}
		else if (endgameAudio.isPlaying) {
			gameAudio.Stop();
		}
		if (worldState.worldEra == timePeriod.timePeriodEnum.intro && !splashAudio.isPlaying) {
			splashAudio.Play();
			splashAudio.volume = 1;
			gameAudio.Stop();
			endgameAudio.Stop();
		}
	}

	public void StartSplashGameFade() {
		splashgamefade = AUDIOFADETIME;
	}

	public void StartGameEndgameFade() {
		gameendfade = AUDIOFADETIME;
	}
}
