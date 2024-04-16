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

	#region"DevelopmentCost"
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
	#endregion

	#region"ResourceCost"
	private int resourceCostAddition = 0;
	public int ResourceCostAddition { get { return resourceCostAddition; } set { resourceCostAddition = value; } }

	private float resourceCostMultiplier = 1;
	public float ResourceCostMultiplier {
		get { return resourceCostMultiplier; }
		set {
			resourceCostMultiplier = value;
			if (resourceCostMultiplier < 0) resourceCostMultiplier = 0;
		}
	}
	public bool GetResourceCost(out int resourceCost) {
		if (outpostCardData == null || outpostCardData.ResourceCost < 0) {
			resourceCost = -1;
			return false;
		}
		else {
			resourceCost = GetModifiedValue(outpostCardData.ResourceCost, resourceCostAddition, resourceCostMultiplier);
			return true;
		}
	}
	#endregion

	#region"HourCost"
	private int hourCostAddition = 0;
	public int HourCostAddition { get { return hourCostAddition; } set { hourCostAddition = value; } }

	private float hourCostMultiplier = 1;
	public float HourCostMultiplier {
		get { return hourCostMultiplier; }
		set {
			hourCostMultiplier = value;
			if (hourCostMultiplier < 0) hourCostMultiplier = 0;
		}
	}
	public bool GetHourCost(out int hourCost) {
		if (outpostCardData == null || outpostCardData.HourCost < 0) {
			hourCost = -1;
			return false;
		}
		else {
			hourCost = GetModifiedValue(outpostCardData.HourCost, hourCostAddition, hourCostMultiplier);
			return true;
		}
	}
	#endregion

	#region"UpkeepCost"
	private int upkeepCostAddition = 0;
	public int UpkeepCostAddition { get { return upkeepCostAddition; } set { upkeepCostAddition = value; } }

	private float upkeepCostMultiplier = 1;
	public float UpkeepCostMultiplier {
		get { return upkeepCostMultiplier; }
		set {
			upkeepCostMultiplier = value;
			if (upkeepCostMultiplier < 0) upkeepCostMultiplier = 0;
		}
	}
	public bool GetUpkeepCost(out int upkeepCost) {
		if (outpostCardData == null || outpostCardData.UpkeepCost < 0) {
			upkeepCost = -1;
			return false;
		}
		else {
			upkeepCost = GetModifiedValue(outpostCardData.UpkeepCost, upkeepCostAddition, upkeepCostMultiplier);
			return true;
		}
	}
	#endregion

	public Sprite GetIllustration { get { return outpostCardData.Illustration != null ? outpostCardData.Illustration : null; } }

	public OutpostCardType GetCardType { get { return outpostCardData.CardType; } }

	public bool GetKeywords(out List<Keyword> keywords) {
		if (outpostCardData.Keywords == null || outpostCardData.Keywords.Count <= 0) {
			keywords = new List<Keyword>();
			return false;
		}
		else {
			keywords = outpostCardData.Keywords;
			return true;
		}
	}

	public string GetCardEffect { get { return outpostCardData.CardEffect ?? null; } }

	#region"ScavengeValue"
	private int scavengeValueAddition = 0;
	public int ScavengeValueAddition { get { return scavengeValueAddition; } set { scavengeValueAddition = value; } }
	private float scavengeValueMultiplier = 1;
	public float ScavengeValueMultiplier {
		get { return scavengeValueMultiplier; }
		set {
			scavengeValueMultiplier = value;
			if (scavengeValueMultiplier < 0) scavengeValueMultiplier = 0;
		}
	}
	public bool GetScavengeValue(out int scavengeValue) {
		if (outpostCardData == null || outpostCardData.ScavengeValue < 0) {
			scavengeValue = -1;
			return false;
		}
		else {
			scavengeValue = GetModifiedValue(outpostCardData.ScavengeValue, scavengeValueAddition, scavengeValueMultiplier);
			return true;
		}
	}
	#endregion

	#region"InterveneValue"
	private int interveneValueAddition = 0;
	public int InterveneValueAddition { get { return interveneValueAddition; } set { interveneValueAddition = value; } }
	private float interveneValueMultiplier = 1;
	public float InterveneValueMultiplier {
		get { return interveneValueMultiplier; }
		set {
			interveneValueMultiplier = value;
			if (interveneValueMultiplier < 0) interveneValueMultiplier = 0;
		}
	}
	public bool GetInterveneValue(out int scavengeValue) {
		if (outpostCardData == null || outpostCardData.InterveneValue < 0) {
			scavengeValue = -1;
			return false;
		}
		else {
			scavengeValue = GetModifiedValue(outpostCardData.InterveneValue, interveneValueAddition, interveneValueMultiplier);
			return true;
		}
	}
	#endregion

	#region"Development
	private int developmentValueAddition = 0;
	public int DevelopementValueAddition { get { return developmentValueAddition; } set { developmentValueAddition = value; } }
	private float developmentValueMultiplier = 1;
	public float DevelopmentValueMultiplier {
		get { return developmentValueMultiplier; }
		set {
			developmentValueMultiplier = value;
			if (developmentValueMultiplier < 0) developmentValueMultiplier = 0;
		}
	}
	public bool GetDevelopmentValue(out int developmentValue) {
		if (outpostCardData == null || outpostCardData.DevelopmentValue < 0) {
			developmentValue = -1;
			return false;
		}
		else {
			developmentValue = GetModifiedValue(outpostCardData.DevelopmentValue, developmentValueAddition, developmentValueMultiplier);
			return true;
		}
	}
	#endregion

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