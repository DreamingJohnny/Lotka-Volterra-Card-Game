using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class SurfaceCardObject : CardObject {

	#region"UI_components"
	[SerializeField] private TextMeshProUGUI keywords;
	[SerializeField] private TextMeshProUGUI scavengingValue;
	[SerializeField] private TextMeshProUGUI threatLevel;
	[SerializeField] private TextMeshProUGUI alertnessValue;
	[SerializeField] private TextMeshProUGUI toughnessValue;
	#endregion

	private SurfaceCardScript surfaceCardScript;
	public override CardScript CardScript => surfaceCardScript;

	public override void SetCardScriptBase(CardScript cardScript) => SetCardScript((SurfaceCardScript)cardScript);

	public void SetCardScript(SurfaceCardScript cardScript) {
		surfaceCardScript = cardScript;
		UpdateAllFields();
	}

	public override void UpdateAllFields() {

		if (!HasCardScript()) {
			Debug.Log($"{name} didn't have a SO_SurfaceCard, so it couldn't set up its own fields.");
			return;
		}

		base.UpdateAllFields();

		if (surfaceCardScript.GetKeywords(out List<Keyword> keywordsList)) {
			string tempKeywords = string.Empty;
			foreach (Keyword keyword in keywordsList) {
				//Converts the keyword to a string and adds it to this string, adds a comma and space at the end.
				tempKeywords += keyword.ToString() + ", ";
			}

			//Removes any trailing commas or spaces
			keywords.text = tempKeywords.TrimEnd(',', ' ');
		}
		else {
			//If the cardData does not contain any keywords the field is left empty.
			keywords.text = string.Empty;
		}

		scavengingValue.text = surfaceCardScript.GetScavengingValue(out int temp) ? temp.ToString() : nA;

		threatLevel.text = surfaceCardScript.GetThreatLevel(out temp) ? temp.ToString() : nA;

		alertnessValue.text = surfaceCardScript.GetAlertnessValue(out temp) ? temp.ToString() : nA;

		toughnessValue.text = surfaceCardScript.GetToughnessValue(out temp) ? temp.ToString() : nA;

	}
}
