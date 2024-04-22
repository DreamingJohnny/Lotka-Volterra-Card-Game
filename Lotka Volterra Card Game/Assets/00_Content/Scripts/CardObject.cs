using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

	#region"UI_components"
	[SerializeField] protected TextMeshProUGUI cardName;
	[SerializeField] protected TextMeshProUGUI cardType;
	[SerializeField] protected Image illustration;
	[SerializeField] protected TextMeshProUGUI keywords;
	[SerializeField] protected TextMeshProUGUI cardEffect;
	#endregion

	private CardScript cardInfo = null;

	[Tooltip("Used on field for traits when the CardScript does not have acceptable data")]
	protected readonly string nA = "N/A";

	[Tooltip("Used when the CardScript does not have a image")]
	[SerializeField] protected Sprite nullImage;

	private void OnEnable() {
		Debug.Assert(nullImage != null);
	}

	public virtual void SetCardInfo(CardScript _CardScript) {
		cardInfo = _CardScript;
		UpdateAllFields();
	}

	public CardScript GetCardScript { get { return cardInfo; } }

	public bool HasCardScript() {
		if (cardInfo != null) return true;
		else return false;
	}

	/// <summary>
	/// If the object doesn't contain a outpostCardInfo it logs that and returns. Otherwise it sets all of the values from outpostCardInfo to its own UI.
	/// </summary>
	public virtual void UpdateAllFields() {

		if (!HasCardScript()) {
			Debug.Log($"{name} didn't have a CardScript, so it couldn't set up its own fields.");
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