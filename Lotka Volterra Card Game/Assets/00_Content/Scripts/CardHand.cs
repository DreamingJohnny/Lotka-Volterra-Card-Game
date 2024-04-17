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

	[SerializeField] private List<OutpostCardObject> outpostCards;

	[SerializeField] private int maxHandSize;

	public int MaxHandSize { get { return maxHandSize; } }

	public int HandSize {
		get {
			int temp = 0;
			foreach (var card in outpostCards) {
				if (card.HasOutpostCardInfo()) temp++;
			}

			return temp;
		}
	}

	void Start() {

	}


	void Update() {

	}

	public void TakeACard(POCO_OutpostCard cardInfo) {
		foreach (var card in outpostCards) {
			if (!card.HasOutpostCardInfo()) {
				card.SetOutpostCardInfo(cardInfo);
				return;
			}
		}

		//add function here for if there was no room among the cards, maybe draw a new card?
	}
}
