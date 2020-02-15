using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
	const string MASTER_VOLUME_KEY = "master volume";
	const string DIFFICULTY_KEY = "difficulty";

	const float MIN_VOLUME = 0f;
	const float MAX_VOLUME = 1f;
	const int MIN_DIFF = 0; //float to int
	const int MAX_DIFF = 2; // float to int
	public static void SetMasterVolume(float volume)
	{
		if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else
		{
			Debug.LogError("Master volume out of range");
		}
	}

	public static void SetDifficulty(int difficulty) //float to int
	{
		if(difficulty >= MIN_DIFF && difficulty <= MAX_DIFF)
		{
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty); //float to int
			Debug.Log("Difficulty in PlayerPrefs set to " + difficulty);

		}
		else
		{
			Debug.LogError("Difficulty out of range");
		}
	}

	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static int GetDifficulty() //float to int
	{
		return PlayerPrefs.GetInt(DIFFICULTY_KEY); //float to int
	}

}
