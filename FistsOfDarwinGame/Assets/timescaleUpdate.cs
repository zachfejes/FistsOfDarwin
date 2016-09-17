using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class timescaleUpdate : MonoBehaviour
{
    public enum timePeriodEnum :int {
        intro,
        cambrianStage2,
        cambrianStage3,
        cambrianStage4,
        cambrianStage5,
        collapse,
        showcase
    };
    public timePeriodEnum playerEra; 
    public timePeriodEnum worldEra; 
 
    public Image timeScale;
	public Text timeScaleText;
    public Button startButton;
	public int scale = 1;

	float gameTime;

    // TIME CONSTANTS
    float MAXGAMETIME = 3*60;
    float FADETOCOLLAPSETIME = 2;
    float SHOWCASETIME = 5;

	// Time bar colours
	Color timeScaleStartColour;
	Color timeScaleEndColour;
	Color timeScaleColourDelta;

    // Use this for initialization
    void Start()
    {

        playerEra = timePeriodEnum.intro;
        worldEra = timePeriodEnum.intro;
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
		if (worldEra != timePeriodEnum.intro)
            gameTime  -= Time.deltaTime;

		//update the timer bar
		if (gameTime > 0)
		{
			float pct = gameTime / MAXGAMETIME;
			timeScale.fillAmount = 1 - pct;
			timeScale.color = timeScaleStartColour + (1-pct) * timeScaleColourDelta;
			//Debug.Log(timeScale.color.ToString());
			int age = 505 + (int)(25 * pct);
			timeScaleText.text = age + " Million Years Ago...";
		}
		else {
			timeScale.fillAmount = 1; //done
			worldEra = timePeriodEnum.collapse;
		}

		if (worldEra == timePeriodEnum.cambrianStage2 &&
				gameTime / MAXGAMETIME < 0.75)
			worldEra = timePeriodEnum.cambrianStage3;
		if (worldEra == timePeriodEnum.cambrianStage3 &&
				gameTime / MAXGAMETIME < 0.5)
			worldEra = timePeriodEnum.cambrianStage4;
		if (worldEra == timePeriodEnum.cambrianStage4 &&
				gameTime / MAXGAMETIME < 0.25)
			worldEra = timePeriodEnum.cambrianStage5;

		//enable/disable the time bar based on the world era'
		if (worldEra == timePeriodEnum.intro ||
				worldEra == timePeriodEnum.collapse ||
				worldEra == timePeriodEnum.showcase)
		{
			timeScale.enabled = false;
			timeScaleText.enabled = false;
		}
		else
		{
			timeScale.enabled = true;
			timeScaleText.enabled = true;
		}

		//set timebar colour
/*		switch(worldEra)
		{
			case timePeriodEnum.cambrianStage2:
				timeScale.color = Color.yellow;
				break;
			case timePeriodEnum.cambrianStage3:
				timeScale.color = Color.red;
				break;
			case timePeriodEnum.cambrianStage4:
				timeScale.color = Color.green;
				break;
			case timePeriodEnum.cambrianStage5:
				timeScale.color = Color.cyan;
				break;
		}*/

    }
	
	public void StartGame() {
		gameTime = MAXGAMETIME;
		worldEra = timePeriodEnum.cambrianStage2;
		playerEra = timePeriodEnum.cambrianStage2;
	}
	

}
