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
		developmentCost.text = outpostCardScript.GetDevelopmentCost(out int temp) ? temp.ToString() : nA;

		resourceCost.text = outpostCardScript.GetResourceCost(out temp) ? temp.ToString() : nA;

		hoursCost.text = outpostCardScript.GetHourCost(out temp) ? temp.ToString() : nA;

		upkeepCost.text = outpostCardScript.GetUpkeepCost(out temp) ? temp.ToString() : nA;

		scavengeValue.text = outpostCardScript.GetScavengeValue(out temp) ? temp.ToString() : nA;

		interveneValue.text = outpostCardScript.GetInterveneValue(out temp) ? temp.ToString() : nA;

		developmentValue.text = outpostCardScript.GetDevelopmentValue(out temp) ? temp.ToString() : nA;
	}
}