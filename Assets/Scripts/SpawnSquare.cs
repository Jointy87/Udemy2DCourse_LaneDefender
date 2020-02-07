using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquare : MonoBehaviour
{
	Defender chosenDefender;
	int defenderCost;
	int stars;
	
	private void OnMouseDown()
	{
		AttemptToSpawn();
	}

	private void AttemptToSpawn()
	{
		stars = FindObjectOfType<StarDisplay>().PassStars();
		chosenDefender = FindObjectOfType<DefenderSpawner>().PassSelectedDefender();
		defenderCost = FindObjectOfType<DefenderSpawner>().PassDefenderCost();

		if(defenderCost <= stars)
		{
			SpawnNewDefender();
			FindObjectOfType<StarDisplay>().SubstractStars(defenderCost);
		}
	}

	private void SpawnNewDefender()
	{
		Defender newDefender = Instantiate(chosenDefender,
		transform.position, Quaternion.identity);

		newDefender.transform.parent = transform;
	}
	
}
