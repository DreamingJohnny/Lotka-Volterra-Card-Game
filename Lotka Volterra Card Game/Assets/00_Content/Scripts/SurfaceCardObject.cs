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

	private CardScript surfaceCardScript= null;

	public void SetSurfaceCardData(CardScript outpostCardInfo) {
		this.surfaceCardScript = outpostCardInfo;
		SetSurfaceCardDataToFields();
	}

	public bool HasSurfaceCardData() {
		if (surfaceCardScript != null) return true;
		else return false;
	}

	public void SetSurfaceCardDataToFields() {

		if (!HasSurfaceCardData()) {
			Debug.Log($"{name} didn't have a SO_SurfaceCard, so it couldn't set up its own fields.");
			return;
		}

		//title.text = outpostCardInfo.CardName.ToString();

		//if (outpostCardInfo.Illustration != null) {
		//	illustration = outpostCardInfo.Illustration;
		//}

		//effectText.text = outpostCardInfo.CardEffect;

		//if (outpostCardInfo.ThreatLevel < 0) threatLevel.text = "-";
		//else threatLevel.text = outpostCardInfo.ThreatLevel.ToString();

		//if (outpostCardInfo.Alertness < 0) alertnessValue.text = "-";
		//else alertnessValue.text = outpostCardInfo.Alertness.ToString();

		//if (outpostCardInfo.Toughness < 0) toughnessValue.text = "-";
		//else toughnessValue.text = outpostCardInfo.Toughness.ToString();
	}
}
