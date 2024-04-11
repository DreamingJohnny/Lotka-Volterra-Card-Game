using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SurfaceCard : MonoBehaviour {

	#region"UI_components"
	[SerializeField] private TextMeshProUGUI title;
	[SerializeField] private TextMeshProUGUI cardType;
	[SerializeField] private Image illustration;
	[SerializeField] private TextMeshProUGUI keywords;
	[SerializeField] private TextMeshProUGUI effectText;
	[SerializeField] private TextMeshProUGUI threatLevel;
	[SerializeField] private TextMeshProUGUI alertnessValue;
	[SerializeField] private TextMeshProUGUI toughnessValue;
	#endregion

	private SO_SurfaceCard sO_SurfaceCard = null;

	public void SetSurfaceCardData(SO_SurfaceCard sO) {
		sO_SurfaceCard = sO;
		SetSurfaceCardDataToFields();
	}

	public bool HasSurfaceCardData() {
		if (sO_SurfaceCard != null) return true;
		else return false;
	}

	public void SetSurfaceCardDataToFields() {

		if (!HasSurfaceCardData()) {
			Debug.Log($"{name} didn't have a SO_SurfaceCard, so it couldn't set up its own fields.");
			return;
		}

		title.text = sO_SurfaceCard.CardName.ToString();

		if (sO_SurfaceCard.Illustration != null) {
			illustration = sO_SurfaceCard.Illustration;
		}

		effectText.text = sO_SurfaceCard.CardEffect;

		if (sO_SurfaceCard.ThreatLevel < 0) threatLevel.text = "-";
		else threatLevel.text = sO_SurfaceCard.ThreatLevel.ToString();

		if (sO_SurfaceCard.Alertness < 0) alertnessValue.text = "-";
		else alertnessValue.text = sO_SurfaceCard.Alertness.ToString();

		if (sO_SurfaceCard.Toughness < 0) toughnessValue.text = "-";
		else toughnessValue.text = sO_SurfaceCard.Toughness.ToString();
	}
}
