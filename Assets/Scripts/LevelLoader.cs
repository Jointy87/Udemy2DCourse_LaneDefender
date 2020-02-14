using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	//Parameters
	[SerializeField] int loadTime;

	int currentSceneIndex;

	// Start is called before the first frame update
	void Start()
	{
		//Time.timeScale = 1;
		Debug.Log(Time.timeScale);

		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		if(currentSceneIndex == 0)
		{
			StartCoroutine(LoadTimer());
		}
	}

	IEnumerator LoadTimer()
	{
		yield return new WaitForSeconds(loadTime);
		LoadNextScene();
	}

	public void LoadNextScene()
	{
		SceneManager.LoadSceneAsync(currentSceneIndex + 1);
	}

	public void LoadGameOverScene()
	{
		SceneManager.LoadSceneAsync("Game Over Screen");
	}

	public void ReloadScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync(currentSceneIndex);
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync("Start Screen");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
