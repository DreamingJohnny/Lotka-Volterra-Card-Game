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
	public int DevelopmentCostAddition {
		get {
			if (CardSlotter.SlottedCards.Count > 0) {
				int totalAddition = developmentCostAddition;
				foreach (CardObject card in CardSlotter.SlottedCards) {
					if (card.CardScript is OutpostCardScript outpostCardScript) {
						if (outpostCardScript.GetDevelopmentCost(out int devCost)) {
							totalAddition += devCost;
						}
					}
				}
				return totalAddition;
			}
			return developmentCostAddition;
		}
		set { developmentCostAddition = value; }
	}

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
			developmentCost = GetModifiedValue(m_SO_OutpostCardData.DevelopmentCost, DevelopmentCostAddition, developmentCostMultiplier);
			return true;
		}
	}
	#endregion

	#region"ResourceCost"
	private int resourceCostAddition = 0;
	public int ResourceCostAddition { get {
			if (CardSlotter.SlottedCards.Count > 0) {
				int totalAddition = resourceCostAddition;
				foreach (CardObject card in CardSlotter.SlottedCards) {
					if (card.CardScript is OutpostCardScript outpostCardScript) {
						if (outpostCardScript.GetResourceCost(out int resourceCostValue)) {
							Debug.Log($"Adding {resourceCostValue} to resource cost from {card.name}");
							totalAddition += resourceCostValue;
						}
					}
				}
				return totalAddition;
			}
			return resourceCostAddition;
		} set { resourceCostAddition = value; } }

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
			resourceCost = GetModifiedValue(m_SO_OutpostCardData.ResourceCost, ResourceCostAddition, resourceCostMultiplier);
			return true;
		}
	}
	#endregion

	#region"HourCost"
	private int hourCostAddition = 0;
	public int HourCostAddition { get {
			if (CardSlotter.SlottedCards.Count > 0) {
				int totalAddition = hourCostAddition;
				foreach (CardObject card in CardSlotter.SlottedCards) {
					if (card.CardScript is OutpostCardScript outpostCardScript) {
						if (outpostCardScript.GetHourCost(out int hourCostAdditionValue)) {
							Debug.Log($"Adding {hourCostAdditionValue} to hour cost addition value from {card.name}");
							totalAddition += hourCostAdditionValue;
						}
					}
				}
				return totalAddition;
			}
			return hourCostAddition;
		} set { hourCostAddition = value; } }

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
			hourCost = GetModifiedValue(m_SO_OutpostCardData.HourCost, HourCostAddition, hourCostMultiplier);
			return true;
		}
	}
	#endregion

	#region"UpkeepCost"
	private int upkeepCostAddition = 0;
	public int UpkeepCostAddition {
		get {
			if (CardSlotter.SlottedCards.Count > 0) {
				int totalAddition = upkeepCostAddition;
				foreach (CardObject card in CardSlotter.SlottedCards) {
					if (card.CardScript is OutpostCardScript outpostCardScript) {
						if (outpostCardScript.GetUpkeepCost(out int upkeepCost)) {
							Debug.Log($"Adding {upkeepCost} to upkeep cost addition from {card.name}");
							totalAddition += upkeepCost;
						}
					}
				}
				return totalAddition;
			}
			return upkeepCostAddition;
		}
		set { upkeepCostAddition = value; }
	}

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
			upkeepCost = GetModifiedValue(m_SO_OutpostCardData.UpkeepCost, UpkeepCostAddition, upkeepCostMultiplier);
			return true;
		}
	}
	#endregion

	#region"ScavengeValue"
	private int scavengeValueAddition = 0;
	public int ScavengeValueAddition {
		get {
			if (CardSlotter.SlottedCards.Count > 0) {
				int totalAddition = scavengeValueAddition;
				foreach (CardObject card in CardSlotter.SlottedCards) {
					if (card.CardScript is OutpostCardScript outpostCardScript) {
						if (outpostCardScript.GetScavengeValue(out int scavValue)) {
							Debug.Log($"Adding {scavValue} to development value from {card.name}");
							totalAddition += scavValue;
						}
					}
				}
				return totalAddition;
			}
			return scavengeValueAddition;
		}
		set { scavengeValueAddition = value; }
	}
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
			scavengeValue = GetModifiedValue(m_SO_OutpostCardData.ScavengeValue, ScavengeValueAddition, scavengeValueMultiplier);
			return true;
		}
	}
	#endregion

	#region"InterveneValue"
	private int interveneValueAddition = 0;
	public int InterveneValueAddition {
		get {
			if (CardSlotter.SlottedCards.Count > 0) {
				int totalAddition = interveneValueAddition;
				foreach (CardObject card in CardSlotter.SlottedCards) {
					if (card.CardScript is OutpostCardScript outpostCardScript) {
						if (outpostCardScript.GetInterveneValue(out int intervValue)) {
							Debug.Log($"Adding {intervValue} to intervene value from {card.name}");
							totalAddition += intervValue;
						}
					}
				}
				return totalAddition;
			}
			return interveneValueAddition;
		}
		set { interveneValueAddition = value; }
	}
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
			scavengeValue = GetModifiedValue(m_SO_OutpostCardData.InterveneValue, InterveneValueAddition, interveneValueMultiplier);
			return true;
		}
	}
	#endregion

	#region"Development
	private int developmentValueAddition = 0;
	public int DevelopementValueAddition {
		get {
			if (CardSlotter.SlottedCards.Count > 0) {
				int totalAddition = developmentValueAddition;
				foreach (CardObject card in CardSlotter.SlottedCards) {
					if (card.CardScript is OutpostCardScript outpostCardScript) {
						if (outpostCardScript.GetDevelopmentValue(out int devValue)) {
							Debug.Log($"Adding {devValue} to development value from {card.name}");
							totalAddition += devValue;
						}
					}
				}
				return totalAddition;
			}
			return developmentCostAddition;
		}
		set { developmentValueAddition = value; }
	}

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
			//TODO: if this works, I need to look through add check so that it asks for the correct, capital lettered, values in all of these.
			developmentValue = GetModifiedValue(m_SO_OutpostCardData.DevelopmentValue, DevelopementValueAddition, DevelopmentValueMultiplier);
			Debug.Log($"Development value for {GetCardName} calculated to be {developmentValue}");
			return true;
		}
	}
	#endregion
}