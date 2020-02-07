using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
	// parameters
	[SerializeField] int stars;

	Text starText;

	void Start()
	{
		starText = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddStars(int starsGained)
	{
		stars += starsGained;
		UpdateDisplay();
	}

	public void SubstractStars(int starCost)
	{
		if (starCost <= stars)
		{
			stars -= starCost;
			UpdateDisplay();
		}
	}

	private void UpdateDisplay()
	{
		starText.text = stars.ToString();
	}

	public int PassStars()
	{
		return stars;
	}
}
