using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class OutpostCardScript : CardScript {

	private SO_OutpostCardData m_SO_OutpostCardData;
	protected override SO_CardData CardData => m_SO_OutpostCardData;

	public OutpostCardScript(SO_CardData cardData) : base(cardData) {
		m_SO_OutpostCardData = (SO_OutpostCardData)cardData;
	}

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
		if (m_SO_OutpostCardData == null || m_SO_OutpostCardData.DevelopmentCost < 0) {
			developmentCost = -1;
			return false;
		}
		else {
			developmentCost = GetModifiedValue(m_SO_OutpostCardData.DevelopmentCost, developmentCostAddition, developmentCostMultiplier);
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
		if (m_SO_OutpostCardData == null || m_SO_OutpostCardData.ResourceCost < 0) {
			resourceCost = -1;
			return false;
		}
		else {
			resourceCost = GetModifiedValue(m_SO_OutpostCardData.ResourceCost, resourceCostAddition, resourceCostMultiplier);
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
		if (m_SO_OutpostCardData == null || m_SO_OutpostCardData.HourCost < 0) {
			hourCost = -1;
			return false;
		}
		else {
			hourCost = GetModifiedValue(m_SO_OutpostCardData.HourCost, hourCostAddition, hourCostMultiplier);
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
		if (m_SO_OutpostCardData == null || m_SO_OutpostCardData.UpkeepCost < 0) {
			upkeepCost = -1;
			return false;
		}
		else {
			upkeepCost = GetModifiedValue(m_SO_OutpostCardData.UpkeepCost, upkeepCostAddition, upkeepCostMultiplier);
			return true;
		}
	}
	#endregion
	
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
		if (m_SO_OutpostCardData == null || m_SO_OutpostCardData.ScavengeValue < 0) {
			scavengeValue = -1;
			return false;
		}
		else {
			scavengeValue = GetModifiedValue(m_SO_OutpostCardData.ScavengeValue, scavengeValueAddition, scavengeValueMultiplier);
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
		if (m_SO_OutpostCardData == null || m_SO_OutpostCardData.InterveneValue < 0) {
			scavengeValue = -1;
			return false;
		}
		else {
			scavengeValue = GetModifiedValue(m_SO_OutpostCardData.InterveneValue, interveneValueAddition, interveneValueMultiplier);
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
		if (m_SO_OutpostCardData == null || m_SO_OutpostCardData.DevelopmentValue < 0) {
			developmentValue = -1;
			return false;
		}
		else {
			developmentValue = GetModifiedValue(m_SO_OutpostCardData.DevelopmentValue, developmentValueAddition, developmentValueMultiplier);
			return true;
		}
	}
	#endregion
}