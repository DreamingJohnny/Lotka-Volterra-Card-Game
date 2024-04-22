using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SurfaceCardObject : CardObject {

	#region"UI_components"
	[SerializeField] private TextMeshProUGUI scavengingValue;
	[SerializeField] private TextMeshProUGUI threatLevel;
	[SerializeField] private TextMeshProUGUI alertnessValue;
	[SerializeField] private TextMeshProUGUI toughnessValue;
	#endregion

	private SurfaceCardScript surfaceCardScript= null;

	public void SetSurfaceCardScript(CardScript cardScript) {
		surfaceCardScript = cardScript as SurfaceCardScript;
		UpdateAllFields();
	}

	public override void UpdateAllFields() {

		if (!HasCardScript()) {
			Debug.Log($"{name} didn't have a SO_SurfaceCard, so it couldn't set up its own fields.");
			return;
		}

		base.UpdateAllFields();

		scavengingValue.text = surfaceCardScript.GetScavengingValue(out int temp) ? temp.ToString() : nA;

		threatLevel.text = surfaceCardScript.GetThreatLevel(out temp) ? temp.ToString() : nA;

		alertnessValue.text = surfaceCardScript.GetAlertnessValue(out temp) ? temp.ToString() : nA;

		toughnessValue.text = surfaceCardScript.GetToughnessValue(out temp) ? temp.ToString() : nA;

	}
}
