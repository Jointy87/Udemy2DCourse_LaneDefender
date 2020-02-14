using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	//Parameters
	[SerializeField] GameObject winLabel;
	[SerializeField] GameObject loseLabel;
	[Tooltip("Time in s between winLabel and calling next level")]
	[SerializeField] float timeToNextScene;
	int enemyCount = 0;
	bool levelTimerFinished = false;

	public void Start()
	{
		winLabel.SetActive(false);
		loseLabel.SetActive(false);
	}
	public void AddToEnemyCount()
	{
		enemyCount++;
	}

	public void SubtractFromEnemyCount()
	{
		enemyCount--;

		if(enemyCount <= 0 && levelTimerFinished)
		{
			StartCoroutine(StartWinSequence());
		}
	}

	public void LevelTimerFInished()
	{
		levelTimerFinished = true;

		StopSpawning();
	}
	public void StopSpawning()
	{
		EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

		foreach (EnemySpawner spawner in enemySpawners)
		{
			spawner.DisableSpawning();
		}
	}

	IEnumerator StartWinSequence()
	{
		if (!winLabel) { yield break; }

		winLabel.SetActive(true);

		GetComponent<AudioSource>().Play();

		yield return new WaitForSeconds(timeToNextScene);

		FindObjectOfType<LevelLoader>().LoadNextScene();
	}

	public void StartLoseSequence()
	{
		loseLabel.SetActive(true);

		Time.timeScale = 0;
	}
}
