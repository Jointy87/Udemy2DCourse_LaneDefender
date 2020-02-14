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
	[SerializeField] float defaultDiff;

	int diffSliderValue;

	void Start()
	{
		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		diffSlider.value = PlayerPrefsController.GetDifficulty();
		//diffSliderValue = (int)diffSlider.value;

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
	}

	public void SaveAndExit()
	{
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
		PlayerPrefsController.SetDifficulty(diffSlider.value);
		FindObjectOfType<LevelLoader>().LoadMainMenu();
		Debug.Log(PlayerPrefsController.GetDifficulty());
	}

	public void SetDefaults()
	{
		volumeSlider.value = defaultVolume;
		diffSlider.value = defaultDiff;
	}
}
