using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardObject : MonoBehaviour {

	#region"TMP components"
	[SerializeField] protected TextMeshPro cardName;
	[SerializeField] protected TextMeshPro cardType;
	[SerializeField] protected SpriteRenderer illustration;
	[SerializeField] protected TextMeshPro traits;
	[SerializeField] protected TextMeshPro cardEffect;
	#endregion

	public abstract CardScript CardScript { get; }

	public abstract void SetCardScriptBase(CardScript cardScript);

	[Tooltip("Used on field for traits when the CardScript does not have acceptable data")]
	protected readonly string nA = "N/A";

	[Tooltip("Used when the CardScript does not have a image")]
	[SerializeField] protected Sprite nullImage;

	protected CardZone currentZone;

	public CardZone CurrentZone {
		get {
			if (currentZone == null) {
				Debug.Log($"{name} does not have a current zone assigned, returning null.");
				return null;
			}
			return currentZone;
		}
		set {
			if (currentZone != value) {
				// If the card is being moved to a new zone, we remove it from the old zone first.
				currentZone.RemoveCard(this);
				currentZone = value;
			}
		}
	}

	private void OnEnable() {
		Debug.Assert(nullImage != null);
	}

	public bool HasCardScript() {
		if (CardScript != null) return true;
		else return false;
	}

	/// <summary>
	/// If the object doesn't contain cardData it logs that and returns. Otherwise it sets all of the values from cardData to its own UI.
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

		if (CardScript.GetTraits(out List<Trait> traitsList)) {
			string traits = string.Empty;
			foreach (Trait trait in traitsList) {
				//Converts the keyword to a string and adds it to this string, adds a comma and space at the end.
				traits += trait.ToString() + ", ";
			}

			//Removes any trailing commas or spaces
			this.traits.text = traits.TrimEnd(',', ' ');
		}
		else {
			//If the cardData does not contain any keywords the field is left empty.
			traits.text = string.Empty;
		}

		if (CardScript.GetCardEffect != null) {
			cardEffect.text = CardScript.GetCardEffect;
		}
		else { cardEffect.text = nA; }
	}
}