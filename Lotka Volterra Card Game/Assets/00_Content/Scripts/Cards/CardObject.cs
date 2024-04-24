using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardObject : MonoBehaviour {

	#region"UI_components"
	[SerializeField] protected TextMeshProUGUI cardName;
	[SerializeField] protected TextMeshProUGUI cardType;
	[SerializeField] protected Image illustration;
	[SerializeField] protected TextMeshProUGUI keywords;
	[SerializeField] protected TextMeshProUGUI cardEffect;
	#endregion

	private CardScript cardScript;
	//TODO: look over if this should be public, if so, should it have getter and setter here instead?
	//public CardScript GetCardScript { get { return cardScript; } }
	//public virtual CardScript GetCardScript { get { return CardScript; } }

	protected CardScript CardScript { get => cardScript; set => cardScript = value; }

	public virtual void SetCardScript(CardScript _cardScript) {
		CardScript = _cardScript;
		UpdateAllFields();
	}

	[Tooltip("Used on field for traits when the CardScript does not have acceptable data")]
	protected readonly string nA = "N/A";

	[Tooltip("Used when the CardScript does not have a image")]
	[SerializeField] protected Sprite nullImage;

	private void OnEnable() {
		Debug.Assert(nullImage != null);
	}


	

	public bool HasCardScript() {
		if (CardScript != null) return true;
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

		if (CardScript.GetCardName != null) {
			cardName.text = CardScript.GetCardName;
		}
		else {
			cardName.text = nA;
		}

		cardType.text = CardScript.GetCardType.ToString();

		//Check if the script has a illustration, otherwise uses the "nullImage".
		if (CardScript.GetIllustration != null) {
			illustration.sprite = CardScript.GetIllustration;
		}
		else { illustration.sprite = nullImage; }

		if (CardScript.GetKeywords(out List<Trait> keywordsList)) {
			string keywords = string.Empty;
			foreach (Trait keyword in keywordsList) {
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

		if (CardScript.GetCardEffect != null) {
			cardEffect.text = CardScript.GetCardEffect;
		}
		else { cardEffect.text = nA; }
	}
}