using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

	#region"UI_components"
	[SerializeField] private TextMeshProUGUI cardName;
	[SerializeField] private TextMeshProUGUI cardType;
	[SerializeField] private Image illustration;
	[SerializeField] private TextMeshProUGUI keywords;
	[SerializeField] private TextMeshProUGUI cardEffect;
	#endregion

	private POCO_OutpostCard cardInfo = null;

	[Tooltip("Used on field for traits when the OutpostCardInfo does not have acceptable data")]
	private readonly string nA = "N/A";

	[Tooltip("Used when the OutpostCardInfo does not have a image")]
	[SerializeField] private Sprite nullImage;

	private void OnEnable() {
		Debug.Assert(nullImage != null);
	}

	public virtual void SetCardInfo(POCO_OutpostCard _outpostCardInfo) {
		cardInfo = _outpostCardInfo;
		UpdateAllFields();
	}

	public POCO_OutpostCard GetOutpostCardInfo { get { return cardInfo; } }

	public bool HasOutpostCardInfo() {
		if (cardInfo != null) return true;
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

		if (cardInfo.GetCardName != null) {
			cardName.text = cardInfo.GetCardName;
		}
		else {
			cardName.text = nA;
		}

		cardType.text = cardInfo.GetCardType.ToString();

		//Check if the script has a illustration, otherwise uses the "nullImage".
		if (cardInfo.GetIllustration != null) {
			illustration.sprite = cardInfo.GetIllustration;
		}
		else { illustration.sprite = nullImage; }

		if (cardInfo.GetKeywords(out List<Keyword> keywordsList)) {
			string keywords = string.Empty;
			foreach (Keyword keyword in keywordsList) {
				//Converts the keyword to a string and adds it to this string, adds a comma and space at the end.
				keywords += keyword.ToString() + ", ";
			}

			//Removes any trailing commas or spaces
			this.keywords.text = keywords.TrimEnd(',', ' ');
		}
		else {
			//If the cardData does not contain any keywords the field is left empty.
			keywords.text = string.Empty;
		}

		if (cardInfo.GetCardEffect != null) {
			cardEffect.text = cardInfo.GetCardEffect;
		}
		else { cardEffect.text = nA; }
	}
}
