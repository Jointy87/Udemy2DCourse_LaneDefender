using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	//Parameters
	[SerializeField] GameObject projectile;

	GameObject projectileShot;
	EnemySpawner spawnerInMyLane;
	Animator animator;

	private void Start()
	{
		SetLaneSpawner();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if(IsEnemyInLane())
		{
			animator.SetBool("isAttacking", true);
		}
		else
		{
			animator.SetBool("isAttacking", false);
		}
	}

	private void SetLaneSpawner()
	{
		EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

		foreach (EnemySpawner enemySpawner in enemySpawners)
		{
			bool IsCloseEnough = 
				(Mathf.Abs(enemySpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
			// Mathf.Abs ensures value is absolute. Meaning it won't be negative
			// Mathf.Epsilon ensures value is below value that's nearly 0. 

			if(IsCloseEnough)
			{
				spawnerInMyLane = enemySpawner;
			}
		}
	}

	private bool IsEnemyInLane()
	{
		if(spawnerInMyLane.transform.childCount <= 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void FireProjectile()
	{
		projectileShot = Instantiate(projectile, 
			new Vector2(transform.position.x, transform.position.y), 
			Quaternion.identity);
	}
}
