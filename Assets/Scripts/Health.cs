using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	// Parameters
	[SerializeField] int hitPoints;
	[SerializeField] GameObject deathVFX;

	public void GetHit(int damageAmmount)
	{
		hitPoints -= damageAmmount;

		CheckForDestroy();
	}

	private void CheckForDestroy()
	{
		if (hitPoints <= 0)
		{
			var spriteInChild = GetComponentInChildren<SpriteRenderer>();
			Destroy(spriteInChild);
			Destroy(gameObject.GetComponent<BoxCollider2D>());

			TriggerDeathVFX();

			Destroy(gameObject, 1);
		}
	}

	private void TriggerDeathVFX()
	{
		if (!deathVFX) { return; }
		GameObject deathVFXParticles = Instantiate(deathVFX, transform.position, Quaternion.identity);
		Destroy(deathVFXParticles, 2f);

		deathVFXParticles.transform.parent = transform;
	}
}
