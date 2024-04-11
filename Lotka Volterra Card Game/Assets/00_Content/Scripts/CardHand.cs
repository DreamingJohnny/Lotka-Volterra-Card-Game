using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour {

	//So, this one will handle the cards.
	//It will be in charge of moving them,
	//creating them
	//destroying them
	//giving them their values
	//This will most likely be a problem, figuring out how to move them, and who then tells them their values?
	//But also sending them on.
	//Also needs to know how many cards it has, and it max size, and if they are empty.

	[SerializeField] private List<OutpostCard> outpostCards;

	[SerializeField] private int maxHandSize;

	public int MaxHandSize { get { return maxHandSize; } }

	public int HandSize {
		get {
			int temp = 0;
			foreach (var card in outpostCards) {
				if (card.HasSO()) temp++;
			}

			return temp;
		}
	}

	void Start() {

	}


	void Update() {

	}

	public void TakeACard(SO_OutpostCard SO_cardData) {
		foreach (var card in outpostCards) {
			if (!card.HasSO()) {
				card.SetSO(SO_cardData);
				return;
			}
		}

		//add function here for if there was no room among the cards, maybe draw a new card?
	}
}
