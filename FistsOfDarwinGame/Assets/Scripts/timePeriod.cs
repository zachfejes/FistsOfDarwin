using UnityEngine;
using System.Collections;

public class timePeriod {

	public enum timePeriodEnum : int
	{
		intro,
		cambrianStage2,
		cambrianStage2x,
		cambrianStage3,
		cambrianStage3x,
		cambrianStage4,
		cambrianStage5,
		collapse,
		showcase
	};

	static public bool isWorldActive(timePeriodEnum world) {
		if (world == timePeriodEnum.intro ||
				world == timePeriodEnum.collapse ||
				world == timePeriodEnum.showcase)
			return false;
		else
			return true;

	}
}
