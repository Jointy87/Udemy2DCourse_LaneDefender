using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	// Parameters
	[SerializeField] Attacker[] enemies;
	[SerializeField] float spawnIntMin;
	[SerializeField] float spawnIntMax;

	bool keepSpawning = true;

	int enemyToSpawn;

	IEnumerator Start()
	{
		while (keepSpawning) 
		{
			yield return new WaitForSeconds(Random.Range(spawnIntMin, spawnIntMax));
			SpawnEnemies();
		}		
	}

	private void SpawnEnemies()
	{
		enemyToSpawn = Random.Range(0, enemies.Length);

		Attacker newAttacker = 
		Instantiate(enemies[enemyToSpawn], 
			transform.position, Quaternion.identity);

		newAttacker.transform.parent = transform;
	}

	public void DisableSpawning()
	{
		keepSpawning = false;

		Debug.Log("Stopped Spawning");
	}
}
