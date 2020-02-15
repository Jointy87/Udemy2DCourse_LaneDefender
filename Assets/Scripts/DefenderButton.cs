using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
	//Parameters
	[SerializeField] Defender defenderPrefab;
	int defenderCost;

	private void Start()
	{
		defenderCost = defenderPrefab.PassStarCost();

		Text priceTag = GetComponentInChildren<Text>();
		priceTag.text = defenderCost.ToString();
		
	}

	public void OnMouseDown()
	{
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach(DefenderButton button in buttons)
		{
			button.GetComponentInChildren<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
		}

		GetComponentInChildren<SpriteRenderer>().color = Color.white;

		FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);

		FindObjectOfType<DefenderSpawner>().SetDefenderCost(defenderCost);
	}
}
