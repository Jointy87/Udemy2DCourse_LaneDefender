using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
	//Parameters
	Defender selectedDefender;
	int defenderCost;

	public void SetSelectedDefender(Defender chosenDefender)
	{
		selectedDefender = chosenDefender;
	}

	public void SetDefenderCost(int cost)
	{
		defenderCost = cost;
	}

	public Defender PassSelectedDefender()
	{
		return selectedDefender;
	}

	public int PassDefenderCost()
	{
		return defenderCost;
	}
}
