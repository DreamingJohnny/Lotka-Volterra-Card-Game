using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTester : MonoBehaviour {

	[SerializeField] private CardZone toBeDevelopedSlot;
	[SerializeField] private CardZone underDevelopmentZone;
		
	[SerializeField] private CardPool cardPool;

	[SerializeField] private List<SO_CardData> cardDatas;

	private int alternateIndex = 0;

	void Start() {

	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			toBeDevelopedSlot.TryAddCard(cardPool.GetCardObject(cardDatas[alternateIndex]));
			alternateIndex++;
			underDevelopmentZone.TryAddCard(cardPool.GetCardObject(cardDatas[alternateIndex]));
			alternateIndex++;
			underDevelopmentZone.TryAddCard(cardPool.GetCardObject(cardDatas[alternateIndex]));
			alternateIndex++;
			underDevelopmentZone.TryAddCard(cardPool.GetCardObject(cardDatas[alternateIndex]));

			//Next we need to look at updating the values based on the aggregate from the cards in the zone.
			//This actually needs to be handled in two different ways, the enemy cards will look at if it is possible or not, while for these we will want it to accumulate.
			//Very annoying to have run into another of these cases where I then need to add two kinds of functionality.
			//So, looking at simplest possible, I can have some manager that gets values from some, and compares it to others
			//If I want simplest, a component that handles both of them perhaps? A manager that handles all fields on the board? Yeah, asking some and comparing it to others.
			//And then telling those other boards to update their values?
			//Add it to the slot then, and have it have a reference, and so it can hold the value that is needed?
		}

	}
}