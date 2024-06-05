using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CardSelector
{

	private static CardObject selectedCard;

	public static void SetSelectedCard(CardObject cardObject) {
		//So, here we will want to think about what the rules would be for trying to click on a card.
	selectedCard = cardObject; 
		//If a card is selected here, then we want an event to fire that the other zones subscribes to.
		//So that they can decide if they should light up or not.
	}


	//So, this one should contain the card that there should be a reference to, and then events for the card being selected,
	//As well as being deselected.

	//Then I need to put into Zones that they react differently depending on what card it is that is selected,
	//and what zones it is,
	//and what phase in the turn

	//Then I want to have the card react differently upon being selected as well, but that should be part of the "card selected script

	public static void DeSelectCard() { selectedCard = null; }
}
