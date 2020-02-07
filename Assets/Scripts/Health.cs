using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	// Parameters
	[SerializeField] int hitPoints;
	[SerializeField] GameObject deathVFX;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != tag)
		{
			Projectile projectileDamage = other.gameObject.GetComponent<Projectile>();

			hitPoints -= projectileDamage.SetDamage();

			CheckForDestroy();
		}
	}
	private void CheckForDestroy()
	{
		if (hitPoints <= 0)
		{
			var spriteInChild = GetComponentInChildren<SpriteRenderer>();
			Destroy(spriteInChild);
			Destroy(gameObject.GetComponent<BoxCollider2D>());

			TriggerDeathVFX();

			Destroy(gameObject, 2);

			Debug.Log("Got this far");
		}
	}

	private void TriggerDeathVFX()
	{
		GameObject deathVFXParticles = Instantiate(deathVFX, transform.position, Quaternion.identity);
		Destroy(deathVFXParticles, 2f);
	}
}
