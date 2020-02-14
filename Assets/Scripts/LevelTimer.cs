using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
	//Parameters
	[Tooltip("Level timer in seconds")]
	[SerializeField] float levelTime;
	bool triggeredLevelFinished = false;

	void Update()
	{
		if(triggeredLevelFinished) { return; }

		GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

		bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

		if(timerFinished)
		{
			//Debug.Log("OUT OF TIME");

			FindObjectOfType<LevelController>().LevelTimerFInished();

			triggeredLevelFinished = true;
		}
	}
}
