using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public sealed class OutpostCardObject : CardObject {

	#region"TMP components"
	[SerializeField] private TextMeshPro developmentCost;
	[SerializeField] private TextMeshPro resourceCost;
	[SerializeField] private TextMeshPro hoursCost;
	[SerializeField] private TextMeshPro upkeepCost;
	[SerializeField] private TextMeshPro scavengeValue;
	[SerializeField] private TextMeshPro interveneValue;
	[SerializeField] private TextMeshPro developmentValue;
	#endregion

	private OutpostCardScript outpostCardScript;
	public override CardScript CardScript => outpostCardScript;

	public override void SetCardScriptBase(CardScript cardScript) => SetCardScript((OutpostCardScript)cardScript);

	public void SetCardScript(OutpostCardScript newOutpostCardScript) {
		outpostCardScript = newOutpostCardScript;
		UpdateAllFields();
	}

	public override bool TryAttachCard(CardObject card) {
		// Need to check type of the card
		// Need to get the cardtype of this card
		if(outpostCardScript.GetCardType != CardType.Unit) {
			//This need to be added with Equipment, or have it sent or something.
			Debug.Log($"{name} is not a Unit card, and cannot have cards attached to it.");
			return false;
		} else if(card.CardScript.GetCardType != CardType.Equipment) {
			Debug.Log($"{name} can only have Equipment cards attached to it, and {card.name} is a {card.CardScript.GetCardType} card.");
			return false;
		} else {
			//If it passes the checks, we can call the base function to do the actual attaching.
			return base.TryAttachCard(card);
			//However, we also need to update the values on this card now.
			//Actually, lets do that without the chain first. Because we might be able to just have an array of all children of the same card here.
			//So, in that case we need to let the script know about this new script then, so that it can ask them for all of their values? So yeah, do we just set that value here, and then the CardScript needs to ask for it?

			//So, we need to update the values of the top card in this chain. This card should always be the top card.
			//How do I do that?
			//So, when the top card asks for values, it asks the card below, that asks the card below that, and so forth, until it reaches the bottom card, which returns its own values.
			//However, this means that the bottom card needs to know if it has a card attached to it or not.
			//Which might not be a big thing, each card will then need to know both cards?
		}
	}

	/// <summary>
	/// If the object doesn't contain a outpostCardInfo it logs that and returns. Otherwise it sets all of the values from outpostCardInfo to its own UI.
	/// </summary>
	public override void UpdateAllFields() {

		if (!HasCardScript()) {
			Debug.Log($"{name} didn't have a OutpostCardScript, so it couldn't set up its own fields.");
			return;
		}

		base.UpdateAllFields();

		// TODO: it seems strange that I'm initializing the int "temp" here, and that it's then used in all of the functions below. I wish I could initialize it in each, so that it didn't have such a long life, with several different values. I'm unsure of how to fix this though.
		//Here I'll need a function then, that also asks possible attached cards for their values, and adds them together.
		//Now, currently that is in the OutpostCardScript, and yeah, maybe that should be there actually? Because it deals with that values, not the UI.
		developmentCost.text = outpostCardScript.GetDevelopmentCost(out int temp) ? temp.ToString() : nA;

		resourceCost.text = outpostCardScript.GetResourceCost(out temp) ? temp.ToString() : nA;

		hoursCost.text = outpostCardScript.GetHourCost(out temp) ? temp.ToString() : nA;

		upkeepCost.text = outpostCardScript.GetUpkeepCost(out temp) ? temp.ToString() : nA;

		scavengeValue.text = outpostCardScript.GetScavengeValue(out temp) ? temp.ToString() : nA;

		interveneValue.text = outpostCardScript.GetInterveneValue(out temp) ? temp.ToString() : nA;

		developmentValue.text = outpostCardScript.GetDevelopmentValue(out temp) ? temp.ToString() : nA;
	}
}