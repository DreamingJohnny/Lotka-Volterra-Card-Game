using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OutpostCardObject : CardObject {

	#region"UI_components"
	[SerializeField] private TextMeshProUGUI developmentCost;
	[SerializeField] private TextMeshProUGUI cardName;
	[SerializeField] private TextMeshProUGUI resourceCost;
	[SerializeField] private TextMeshProUGUI hoursCost;
	[SerializeField] private TextMeshProUGUI upkeepCost;
	[SerializeField] private TextMeshProUGUI cardType;
	[SerializeField] private Image illustration;
	[SerializeField] private TextMeshProUGUI keywords;
	[SerializeField] private TextMeshProUGUI cardEffect;
	[SerializeField] private TextMeshProUGUI scavengeValue;
	[SerializeField] private TextMeshProUGUI interveneValue;
	[SerializeField] private TextMeshProUGUI developeValue;
	#endregion

	private POCO_OutpostCard outpostCardInfo = null;

	[Tooltip("Used on field for traits when the OutpostCardInfo does not have acceptable data")]
	private readonly string nA = "N/A";

	[Tooltip("Used when the OutpostCardInfo does not have a image")]
	[SerializeField] private Sprite nullImage;

	private void OnEnable() {
		Debug.Assert(nullImage != null);
	}

	public void SetOutpostCardInfo(POCO_OutpostCard _outpostCardInfo) {
		outpostCardInfo = _outpostCardInfo;
		UpdateAllFields();
	}

	public POCO_OutpostCard GetOutpostCardInfo { get { return outpostCardInfo; } }

	public bool HasOutpostCardInfo() {
		if (outpostCardInfo != null) return true;
		else return false;
	}

	/// <summary>
	/// If the object doesn't contain a outpostCardInfo it logs that and returns. Otherwise it sets all of the values from outpostCardInfo to its own UI.
	/// </summary>
	public void UpdateAllFields() {

		if (!HasOutpostCardInfo()) {
			Debug.Log($"{name} didn't have a POCO_OutpostCard, so it couldn't set up its own fields.");
			return;
		}

		// TODO: it seems strange that I'm initializing the int "temp" here, and that it's then used in all of the functions below. I wish I could initialize it in each, so that it didn't have such a long life, with several different values. I'm unsure of how to fix this though.
		developmentCost.text = outpostCardInfo.GetDevelopmentCost(out int temp) ? temp.ToString() : nA;

		if (outpostCardInfo.GetCardName != null) {
			cardName.text = outpostCardInfo.GetCardName;
		}
		else {
			cardName.text = nA;
		}

		resourceCost.text = outpostCardInfo.GetResourceCost(out temp) ? temp.ToString() : nA;

		hoursCost.text = outpostCardInfo.GetHourCost(out temp) ? temp.ToString() : nA;

		upkeepCost.text = outpostCardInfo.GetUpkeepCost(out temp) ? temp.ToString() : nA;

		cardType.text = outpostCardInfo.GetCardType.ToString();

		//Check if the script has a illustration, otherwise uses the "nullImage".
		if (outpostCardInfo.GetIllustration != null) {
			illustration.sprite = outpostCardInfo.GetIllustration;
		}
		else { illustration.sprite = nullImage; }

		if (outpostCardInfo.GetKeywords(out List<Keyword> keywordsList)) {
			string keywords = string.Empty;
			foreach (Keyword keyword in keywordsList) {
				//Converts the keyword to a string and adds it to this string, adds a comma and space at the end.
				keywords += keyword.ToString() + ", ";
			}

			//Removes any trailing commas or spaces
			this.keywords.text = keywords.TrimEnd(',',' ');
		}
		else {
			//If the cardData does not contain any keywords the field is left empty.
			keywords.text = string.Empty;
		}

		if (outpostCardInfo.GetCardEffect != null) {
			cardEffect.text = outpostCardInfo.GetCardEffect;
		}
		else { cardEffect.text = nA; }

		scavengeValue.text = outpostCardInfo.GetScavengeValue(out temp) ? temp.ToString() : nA;

		interveneValue.text = outpostCardInfo.GetInterveneValue(out temp) ? temp.ToString() : nA;

		developeValue.text = outpostCardInfo.GetDevelopmentValue(out temp) ? temp.ToString() : nA;
	}
}