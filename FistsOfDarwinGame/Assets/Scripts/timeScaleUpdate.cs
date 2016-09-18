using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class timeScaleUpdate : MonoBehaviour
{

    public timePeriod.timePeriodEnum playerEra; 
    public timePeriod.timePeriodEnum worldEra; 
 
    public Image timeScale;
	public Image timeScaleBorder;
	public Text timeScaleText;
    public Button startButton;
	public int scale = 1;

	public UnityEvent startCollapseEvent;

	float gameTime;

    // TIME CONSTANTS
    float MAXGAMETIME = 3*60;
    float FADETOCOLLAPSETIME = 30;
    float SHOWCASETIME = 40;

	// Time bar colours
	Color timeScaleStartColour;
	Color timeScaleEndColour;
	Color timeScaleColourDelta;

    // Use this for initialization
    void Start()
    {
		
        playerEra = timePeriod.timePeriodEnum.intro;
        worldEra = timePeriod.timePeriodEnum.intro;
		gameTime = 0;

		timeScaleStartColour.r = 65/255.0f;
		timeScaleStartColour.g = 136/255.0f;
		timeScaleStartColour.b = 85/255.0f;
		timeScaleStartColour.a = 1;
		
		timeScaleEndColour.r = 167/255f;
		timeScaleEndColour.g = 110/255f;
		timeScaleEndColour.b = 21/255f;
		timeScaleEndColour.a = 1;

		timeScaleColourDelta =timeScaleEndColour - timeScaleStartColour;

	}

    // Update is called once per frame
    void Update()
	{
		Time.timeScale = scale;
		//subtract time if the game has started
		if (worldEra != timePeriod.timePeriodEnum.intro)
            gameTime  -= Time.deltaTime;

		//update the timer bar
		if (gameTime > 0)
		{
			float pct = gameTime / MAXGAMETIME;
			timeScale.fillAmount = 1 - pct;
			timeScale.color = timeScaleStartColour + (1-pct) * timeScaleColourDelta;
			int age = 505 + (int)(25 * pct);
			timeScaleText.text = age + " Million Years Ago...";
		}
		else {
			timeScale.fillAmount = 1; //done
		}

		// Control world age development
		if (worldEra == timePeriod.timePeriodEnum.cambrianStage2 &&
				gameTime / MAXGAMETIME < 5/6)
			worldEra = timePeriod.timePeriodEnum.cambrianStage2x;
		if (worldEra == timePeriod.timePeriodEnum.cambrianStage2x &&
				gameTime / MAXGAMETIME < 4 / 6)
			worldEra = timePeriod.timePeriodEnum.cambrianStage3;
		if (worldEra == timePeriod.timePeriodEnum.cambrianStage3 &&
				gameTime / MAXGAMETIME < 0.5)
			worldEra = timePeriod.timePeriodEnum.cambrianStage3x;
		if (worldEra == timePeriod.timePeriodEnum.cambrianStage3x &&
				gameTime / MAXGAMETIME < 2/6)
			worldEra = timePeriod.timePeriodEnum.cambrianStage4;
		if (worldEra == timePeriod.timePeriodEnum.cambrianStage4 &&
				gameTime / MAXGAMETIME < 1/6)
			worldEra = timePeriod.timePeriodEnum.cambrianStage5;
		if (worldEra == timePeriod.timePeriodEnum.cambrianStage5 &&
				gameTime < 0) {
			worldEra = timePeriod.timePeriodEnum.collapse;
			startCollapseEvent.Invoke();
		}
		if (worldEra == timePeriod.timePeriodEnum.collapse &&
				gameTime < -FADETOCOLLAPSETIME)
			worldEra = timePeriod.timePeriodEnum.showcase;
		if (worldEra == timePeriod.timePeriodEnum.showcase &&
				gameTime < -(FADETOCOLLAPSETIME + SHOWCASETIME))
			worldEra = timePeriod.timePeriodEnum.intro;

		//enable/disable the time bar based on the world era
		if (!gameIsActive())
		{
			timeScale.enabled = false;
			timeScaleText.enabled = false;
			timeScaleBorder.enabled = false;
		}
		else
		{
			timeScale.enabled = true;
			timeScaleText.enabled = true;
			timeScaleBorder.enabled = true;
		}


		//control start button visiblity
		startButton.enabled = (worldEra == timePeriod.timePeriodEnum.intro);
		startButton.targetGraphic.enabled = (worldEra == timePeriod.timePeriodEnum.intro);
		startButton.transform.FindChild("Text").gameObject.GetComponent<Text>().text = (worldEra == timePeriod.timePeriodEnum.intro) ? "Start!" : "";

	}
	
	public void StartGame() {
		gameTime = MAXGAMETIME;
		worldEra = timePeriod.timePeriodEnum.cambrianStage2;
		playerEra = timePeriod.timePeriodEnum.cambrianStage2;
	}

	//Check if the game is active
	public bool gameIsActive()
	{
		return timePeriod.isWorldActive(worldEra);
	}
}
