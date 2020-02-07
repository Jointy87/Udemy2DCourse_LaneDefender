using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
	//Parameters
	[SerializeField] Defender defenderPrefab;
	int defenderCost;

	public void OnMouseDown()
	{
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach(DefenderButton button in buttons)
		{
			button.GetComponentInChildren<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
		}

		GetComponentInChildren<SpriteRenderer>().color = Color.white;

		FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);

		defenderCost = defenderPrefab.PassStarCost();

		FindObjectOfType<DefenderSpawner>().SetDefenderCost(defenderCost);
	}
}
