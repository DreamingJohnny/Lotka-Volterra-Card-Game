using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public static class PlayerCursor {

	//Time to think about how to handle the selected card remaining clear...
	//I could wait with that until when I improve the cards, adding the extra slots etc.

	public static event Action<CardObject> OnCardSelected;

	private static CardObject selectedCard;

	public static CardObject SelectedCard {
		get { return selectedCard; }
		set {
			if (selectedCard == value) return;
			else if (selectedCard != null) {

			}
				//So, here we will want to think about what the rules should be for trying to click on a card.
				//Like, if the card is of the wrong kind or whatever,


				selectedCard = value;
			OnCardSelected?.Invoke(selectedCard);
		}
	}

	//As well as being deselected.
	public static void DeSelectCard() {
		selectedCard = null;
		OnCardSelected?.Invoke(null); //Must check if this is allowed or super not allowed.
	}
}
