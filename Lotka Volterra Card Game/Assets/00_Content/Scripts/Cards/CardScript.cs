using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardScript {

	public CardScript(SO_CardData _cardData) {
		CardData = _cardData;
	}
	public virtual SO_CardData CardData { get; set; }

	public string GetCardID { get { return CardData != null ? CardData.CardID : null; } }
	public string GetCardName { get { return CardData != null ? CardData.CardName : null; } }

	public Sprite GetIllustration { get { return CardData.Illustration != null ? CardData.Illustration : null; } }
	
	//TODO: This one will need to be extended to deal with a more general card type.
	public OutpostCardType GetCardType { get { return CardData.CardType; } }

	public bool GetKeywords(out List<Trait> keywords) {
		if (CardData.Keywords == null || CardData.Keywords.Count <= 0) {
			keywords = new List<Trait>();
			return false;
		}
		else {
			keywords = CardData.Keywords;
			return true;
		}
	}

	public string GetCardEffect { get { return CardData.CardEffect ?? null; } }

	/// Carries out the calculations based on the modifier before returning the resulting value.
	/// Rounds down to closest integer before returning.
	/// </summary>
	/// <param name="sO_value"></param>
	/// <param name="addition"></param>
	/// <param name="multiplier"></param>
	/// <returns></returns>
	protected int GetModifiedValue(int sO_value, int addition, float multiplier) {
		float temp = (sO_value + addition) * multiplier;
		//Ensures the value isn't below 0
		temp = (temp < 0) ? 0 : temp;
		//Convert value to an int (rounded down).
		temp = Mathf.FloorToInt(temp);
		return (int)temp;
	}

}
