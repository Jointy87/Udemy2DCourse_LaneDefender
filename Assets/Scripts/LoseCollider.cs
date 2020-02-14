using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject otherObject = other.gameObject;

		if(otherObject.GetComponent<Attacker>())
		{
			SubstractLife();
		}   
	}

	private void SubstractLife()
	{
		FindObjectOfType<HeartsDisplay>().SubstractHeart();
	}
}
