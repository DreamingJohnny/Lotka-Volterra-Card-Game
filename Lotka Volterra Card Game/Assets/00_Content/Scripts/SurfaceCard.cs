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

	private POCO_OutpostCard outpostCardInfo = null;

	public void SetSurfaceCardData(POCO_OutpostCard outpostCardInfo) {
		this.outpostCardInfo = outpostCardInfo;
		SetSurfaceCardDataToFields();
	}

	public bool HasSurfaceCardData() {
		if (outpostCardInfo != null) return true;
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
