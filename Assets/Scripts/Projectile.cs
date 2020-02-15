using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	//Parameters
	[SerializeField] float projectileSpeed;
	[SerializeField] float spinSpeed;
	[SerializeField] int projectileDamage;

	void Update()
	{
		transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed, Space.World);

		transform.Rotate(0, 0, -spinSpeed * Time.deltaTime, Space.World);
	}

	public int SetDamage()
	{
		return projectileDamage;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject otherObject = other.gameObject;

		if (otherObject.GetComponent<Attacker>())
		{
			other.gameObject.GetComponent<Health>().GetHit(projectileDamage);

			Destroy(gameObject);
		}
	}
}
