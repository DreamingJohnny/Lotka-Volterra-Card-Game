using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POCO_OutpostCard {

	private SO_OutpostCard outpostCardData;

	public POCO_OutpostCard(SO_OutpostCard outpostCardData) {
		this.outpostCardData = outpostCardData;
	}

	public string GetCardID { get { return outpostCardData != null ? outpostCardData.CardID : null; } }
	public string GetCardName { get { return outpostCardData != null ? outpostCardData.CardName : null; } }

	private int developmentCostAddition = 0;
	public int DevelopmentCostAddition { get { return developmentCostAddition; } set { developmentCostAddition = value; } }

	private float developmentCostMultiplier = 1;
	public float DevelopmentCostMultiplier {
		get { return developmentCostMultiplier; }
		set {
			developmentCostMultiplier = value;
			if (developmentCostMultiplier < 0) developmentCostMultiplier = 0;
		}
	}
	public bool GetDevelopmentCost(out int developmentCost) {
		if (outpostCardData == null || outpostCardData.DevelopmentCost < 0) {
			developmentCost = -1;
			return false;
		}
		else {
			developmentCost = GetModifiedValue(outpostCardData.DevelopmentCost, developmentCostAddition, developmentCostMultiplier);
			return true;
		}
	}


	public Image GetIllustration { get { return outpostCardData.Illustration != null ? outpostCardData.Illustration : null; } }


	/// <summary>
	/// Carries out the calculations based on the modifier before returning the resulting value.
	/// Rounds down to closest integer before returning.
	/// </summary>
	/// <param name="sO_value"></param>
	/// <param name="addition"></param>
	/// <param name="multiplier"></param>
	/// <returns></returns>
	private int GetModifiedValue(int sO_value, int addition, float multiplier) {
		float temp = (sO_value + addition) * multiplier;
		//Ensures the value isn't below 0
		temp = (temp < 0) ? 0 : temp;
		//Convert value to an int (rounded down).
		temp = Mathf.FloorToInt(temp);
		return (int)temp;
	}
}