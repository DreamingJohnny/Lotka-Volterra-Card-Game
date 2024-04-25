using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardScript {

	public CardScript(SO_CardData _cardData) {
		CardData = _cardData;
	}
	protected virtual SO_CardData CardData { get; private set; }

	public string GetCardID { get { return CardData != null ? CardData.CardID : null; } }
	public string GetCardName { get { return CardData != null ? CardData.CardName : null; } }

	public Sprite GetIllustration { get { return CardData.Illustration != null ? CardData.Illustration : null; } }
	
	public CardType GetCardType { get { return CardData.CardType; } }

	public bool GetTraits(out List<Trait> traits) {
		if (CardData.Traits == null || CardData.Traits.Count <= 0) {
			traits = new List<Trait>();
			return false;
		}
		else {
			traits = CardData.Traits;
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