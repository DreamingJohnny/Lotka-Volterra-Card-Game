using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour {
	//Should receive enemy cards and place them in their spots, should move them along when a new one comes in.

	//Need way to handle if there are too many cards

	//Can communicate about what enemy card that gets intervened, and what card gets destroyed, but also send up their effects.

	//Actually also needs to receive data about cards, and then use that data to fill up a card.
	//Needs to be able to instantiate cards and then fill them up then?

	//So, function for receiving a data. Then creates a card, then moves the other cards.

	[SerializeField] private List<RectTransform> cardSlots;

	[SerializeField] private CardObject cardObject;

	public void NewSurfaceCard(CardScript cardScript) {

		Instantiate(cardObject, cardSlots[0]);
		cardObject.SetCardScript(cardScript);

		Debug.Log("Just instatiated a card, can I see it?");

		//We need a function here that moves all of the other cards, and then gives the first slot to this one.
		//Let's begin by just having it move to the first slot?
	}


}
