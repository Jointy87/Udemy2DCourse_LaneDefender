using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
	//Parameters
	[SerializeField] Slider volumeSlider;
	[SerializeField] float defaultVolume;
	[SerializeField] Slider diffSlider;
	[SerializeField] int defaultDiff; //float to int

	int diffSliderValue;

	void Start()
	{
		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		diffSlider.value = PlayerPrefsController.GetDifficulty();
		diffSliderValue = (int)diffSlider.value; //to convert float to int

	}

	void Update()
	{
		var musicPlayer = FindObjectOfType<MusicPlayer>();

		if (musicPlayer)
		{
			musicPlayer.SetVolume(volumeSlider.value);
		}
		else
		{
			Debug.LogWarning("No music player found!");
		}

		diffSliderValue = (int)diffSlider.value; //to convert float to int
	}

	public void SaveAndExit()
	{
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
		PlayerPrefsController.SetDifficulty(diffSliderValue); //diffSlider.value to diffSliderValue (float to int)
		Debug.Log("Slider value is " + diffSlider.value);
		FindObjectOfType<LevelLoader>().LoadMainMenu();
		Debug.Log("Difficulty is " + PlayerPrefsController.GetDifficulty());
	}

	public void SetDefaults()
	{
		volumeSlider.value = defaultVolume;
		diffSlider.value = defaultDiff;
	}
}
