using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
	[SerializeField] int starCost;
	public void AddStars(int starsToAdd)
	{
		FindObjectOfType<StarDisplay>().AddStars(starsToAdd);
	}

	public int PassStarCost()
	{
		return starCost;
	}
}
