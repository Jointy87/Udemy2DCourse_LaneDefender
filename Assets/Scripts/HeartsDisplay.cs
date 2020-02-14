using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartsDisplay : MonoBehaviour
{
	//Parameters
	[SerializeField] GameObject heartPrefab;
	[SerializeField] int heartsAmount;

	void Start()
	{
		int[] heartContainers = new int [heartsAmount];

		foreach(int heart in heartContainers)
		{
			int amountSpawned = transform.childCount;
			
			GameObject heartSpawned = Instantiate(heartPrefab, 
				new Vector2 (transform.position.x + amountSpawned, transform.position.y),
				Quaternion.identity);

			heartSpawned.transform.parent = transform;
		}
	}

	public void SubstractHeart()
	{
		heartsAmount--;

		if(transform.childCount <= 0) { return; }

		Destroy(GetComponent<Transform>().GetChild(heartsAmount).gameObject);

		CheckForGameOver();
	}

	private void CheckForGameOver()
	{
		if(heartsAmount <= 0)
		{
			FindObjectOfType<LevelController>().StartLoseSequence();
		}
	}
}
