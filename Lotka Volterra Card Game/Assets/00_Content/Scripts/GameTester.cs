using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTester : MonoBehaviour {

	[SerializeField] private CardZone mainCardZone;
	[SerializeField] private CardZone secondaryCardZone;
	[SerializeField] private CardZone triaryCardZone;
	[SerializeField] private CardObject cardObject;
	[SerializeField] private CardPool cardPool;

	//[SerializeField] private SO_OutpostCardData outpostCardData;
	[SerializeField] private List<SO_CardData> cardDatas;


	private int testInt = 0;
	private CardZone sending;
	private CardZone receiving;

	void Start() {
		while (testInt < 10) {
			//Debug.Log($"TestInt is {testInt}");
			if (testInt % 2 == 0) {
				sending = mainCardZone;
				testInt++;
				//Debug.Log("Using mainCardZone.");
			}
			else {
				//Debug.Log("Using secondaryCardZone.");
				sending = secondaryCardZone;
				testInt++;
			}
			bool status = sending.TryAddCard(cardPool.GetCardObject(cardDatas[testInt]));

			//Debug.Log($"Card added: {status}");
			//Debug.Log($"Card zone now has {sending.Cards.Count} cards.");
			if (sending.Cards.Count > 0) {
				//Debug.Log($"First card in zone: {sending.Cards[0].CardScript.GetCardName}");
			}
			else {
				Debug.Log("No cards in zone.");
			}
		}
		sending = secondaryCardZone;
		receiving = triaryCardZone;
	}

	void Update() {
		//if (Input.GetKeyDown(KeyCode.Space)) {
		//Debug.Log("Trying to add card to zone...");
		//if (testInt % 2 == 0) {
		//	designated = mainCardZone;
		//	testInt++;
		//	Debug.Log("Using mainCardZone.");
		//} else {
		//	Debug.Log("Using secondaryCardZone.");
		//	designated = secondaryCardZone;
		//	testInt++;
		//}
		//bool status = designated.TryAddCard(cardPool.GetCardObject(outpostCardData));

		//Debug.Log($"Card added: {status}");
		//Debug.Log($"Card zone now has {designated.Cards.Count} cards.");
		//if (mainCardZone.Cards.Count > 0) {
		//	Debug.Log($"First card in zone: {designated.Cards[0].CardScript.GetCardName}");
		//} else {
		//	Debug.Log("No cards in zone.");
		//}

		if (Input.GetKeyDown(KeyCode.Space)) {
			//Get a card from a zone and and it to another zone.
			if (sending.Cards.Count > 0) {
				int randomIndex = UnityEngine.Random.Range(0, sending.Cards.Count);
				Debug.Log($"Sending zone has {sending.Cards.Count} cards.");
				Debug.Log($"Randomly selected card index: {randomIndex}");
				Debug.Log($"Card to move: {sending.Cards[randomIndex].CardScript.GetCardName}");
				CardObject cardToMove = sending.Cards[randomIndex];
				Debug.Log($"Card to move: {cardToMove.CardScript.GetCardName}");
				//Note, check over this, pretty sure it shouldn't be done from here, but instead from within the cardobject itself. Also, should only be done if card successfully moved, surely?

				if (receiving.TryAddCard(cardToMove)) {
					sending.RemoveCard(cardToMove);
					Debug.Log($"Moved card {cardToMove.CardScript.GetCardName} from {sending.name} to {receiving.name}.");
				}
				else {
					Debug.Log($"Failed to move card {cardToMove.CardScript.GetCardName} from {sending.name} to {receiving.name}.");
				}
			}
			else {
				sending = triaryCardZone;
				receiving = secondaryCardZone;

				Debug.Log("No cards to move, switching sender and receiver.");
			}
		}
	}
}