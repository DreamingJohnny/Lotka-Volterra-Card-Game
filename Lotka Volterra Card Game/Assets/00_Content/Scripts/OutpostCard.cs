using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutpostCard : MonoBehaviour {

	#region"UI_components"
	[SerializeField] private TextMeshProUGUI developmentCost;
	[SerializeField] private TextMeshProUGUI title;
	[SerializeField] private TextMeshProUGUI resourceCost;
	[SerializeField] private TextMeshProUGUI hoursCost;
	[SerializeField] private TextMeshProUGUI upkeepCost;
	[SerializeField] private TextMeshProUGUI cardType;
	[SerializeField] private Image illustration;
	[SerializeField] private TextMeshProUGUI keywords;
	[SerializeField] private TextMeshProUGUI effectText;
	[SerializeField] private TextMeshProUGUI scavengeValue;
	[SerializeField] private TextMeshProUGUI interveneValue;
	[SerializeField] private TextMeshProUGUI developeValue;
	#endregion

	private SO_OutpostCard sO_OutpostCard;

	//So, this is the script for showing the card I take it?
	//Yeah, so everything else I'll want to move to another script, I think.

	//Needs ways to get the values that it has,
	//Needs the  values
	//Needs to be able to change and fix the values? Might want to do this, seeing as we might want to be able to temporarily update them.
	//Should probably be able to check like: Am I missing components? Am I missing values?
	//Needs to contain the info for its own max and minis?

	//Needs to be able to get a scriptable object and set its own values to that.
	void Start() {

	}

	public void SetSO(SO_OutpostCard sO) {
		sO_OutpostCard = sO;
		SetSOToFields();
	}

	public bool HasSO() {
		if (sO_OutpostCard != null) return true;
		else return false;
	}

	public void SetSOToFields() {
		//So this one should set the values in the fields according to the SO that it has received then?
		if (!HasSO()) {
			Debug.Log($"{name} didn't have a SO_OutpostCard, so it couldn't set up its own fields.");
			return;
		}

		developmentCost.text = sO_OutpostCard.DevelopmentCost.ToString();
		title.text = sO_OutpostCard.CardName.ToString();
		resourceCost.text = sO_OutpostCard.ResourceCost.ToString();
		hoursCost.text = sO_OutpostCard.HourCost.ToString();
		upkeepCost.text = sO_OutpostCard.UpkeepCost.ToString();

		if (sO_OutpostCard.Illustration != null) {
			illustration = sO_OutpostCard.Illustration;
		}

		effectText.text = sO_OutpostCard.CardEffect;

		if (sO_OutpostCard.ScavengeValue < 0) scavengeValue.text = "-";
		else scavengeValue.text = sO_OutpostCard.ScavengeValue.ToString();

		if (sO_OutpostCard.InterveneValue < 0) interveneValue.text = "-";
		else interveneValue.text = sO_OutpostCard.InterveneValue.ToString();

		if (sO_OutpostCard.DevelopmentValue < 0) developeValue.text = "-";
		else developeValue.text = sO_OutpostCard.DevelopmentValue.ToString();
	}

	void Update() {

	}
}
