using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OutpostCardObject : CardObject {

	#region"UI_components"
	[SerializeField] private TextMeshProUGUI developmentCost;
	[SerializeField] private TextMeshProUGUI resourceCost;
	[SerializeField] private TextMeshProUGUI hoursCost;
	[SerializeField] private TextMeshProUGUI upkeepCost;
	[SerializeField] private TextMeshProUGUI scavengeValue;
	[SerializeField] private TextMeshProUGUI interveneValue;
	[SerializeField] private TextMeshProUGUI developeValue;
	#endregion

	private OutpostCardScript outpostCardScript = null;

	public override void SetCardScript(CardScript _outpostCardScript) {
		outpostCardScript = (OutpostCardScript)_outpostCardScript;
		UpdateAllFields();
	}

	public CardScript GetOutpostCardInfo { get { return outpostCardScript; } }

	/// <summary>
	/// If the object doesn't contain a outpostCardInfo it logs that and returns. Otherwise it sets all of the values from outpostCardInfo to its own UI.
	/// </summary>
	public override void UpdateAllFields() {

		if (!HasCardScript()) {
			Debug.Log($"{name} didn't have a POCO_OutpostCard, so it couldn't set up its own fields.");
			return;
		}

		base.UpdateAllFields();

		// TODO: it seems strange that I'm initializing the int "temp" here, and that it's then used in all of the functions below. I wish I could initialize it in each, so that it didn't have such a long life, with several different values. I'm unsure of how to fix this though.
		developmentCost.text = outpostCardScript.GetDevelopmentCost(out int temp) ? temp.ToString() : nA;

		resourceCost.text = outpostCardScript.GetResourceCost(out temp) ? temp.ToString() : nA;

		hoursCost.text = outpostCardScript.GetHourCost(out temp) ? temp.ToString() : nA;

		upkeepCost.text = outpostCardScript.GetUpkeepCost(out temp) ? temp.ToString() : nA;

		scavengeValue.text = outpostCardScript.GetScavengeValue(out temp) ? temp.ToString() : nA;

		interveneValue.text = outpostCardScript.GetInterveneValue(out temp) ? temp.ToString() : nA;

		developeValue.text = outpostCardScript.GetDevelopmentValue(out temp) ? temp.ToString() : nA;
	}
}