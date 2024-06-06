using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CardSelector {

	public static event Action<CardObject> OnCardSelected;

	private static CardObject selectedCard;

	public static CardObject SelectedCard { get { return selectedCard; } set {
			//So, here we will want to think about what the rules should be for trying to click on a card.
			//Like, if the card is of the wrong kind or whatever,


			selectedCard = value;
			OnCardSelected?.Invoke(selectedCard);
		} }

	//As well as being deselected.


	private static void DeSelectCard() {
		selectedCard = null;
		OnCardSelected?.Invoke(null); //Must check if this is allowed or super not allowed.
	}
}
