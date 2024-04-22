using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[SerializeField] private CardDeck outpostDeck;
	[SerializeField] private CardHand playerHand;

	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private SurfaceZone surfaceZone;
	[SerializeField] private SO_OutpostCardData outpostCardData;

	[SerializeField] private OutpostCardObject outpostCardObject;

	[SerializeField] private List<OutpostCardObject> outpostCardObjects;

	[SerializeField] private List<SO_OutpostCardData> SO_OutpostCards;

	[SerializeField] private Discard discard;

	[SerializeField] private CardDeck cardDeck;

	void Start() {

		//TestingCardDeck();

		//TestingDiscard();

		//TestingCardObject();

		//TestingPOCO(outpostCardData);

		//BruteTestPlayerCardHand();

		//BruteTestSurfaceZone();
	}

	//private void TestingCardDeck() {
	//	if (cardDeck == null) return;

	//	cardDeck.SetNewDeck(SO_OutpostCards);

	//	cardDeck.GetTopCardName(out string name);
	//	Debug.Log($"Topcard Name: {name}");

	//	cardDeck.GetTopCard(out POCO_OutpostCard pOCO);
	//	name = pOCO.GetCardName;
	//	Debug.Log($"having gotten the top card its name is: {name}");

	//	cardDeck.PutOnTop(pOCO);
	//	cardDeck.GetTopCardName(out name);
	//	Debug.Log($"Topcard Name: {name} after I put it back");
	//}

	private void TestingDiscard() {

		for (int i = 0; i < outpostCardObjects.Count; i++) {
			if (discard != null && outpostCardObjects[i] != null && SO_OutpostCards[i] != null) {

				//outpostCardObjects[i].SetOutpostCardInfo(new POCO_OutpostCard(SO_OutpostCards[i]));

				discard.SendToDiscard(outpostCardObjects[i]);
				Debug.Log("Sent on card " + i);
			}
		}
	}

	//private void TestingCardObject() {
	//	//POCO_OutpostCard pOCO_OutpostCard = new(outpostCardData);

	//	outpostCardObject.SetOutpostCardInfo(pOCO_OutpostCard);
	//	Debug.Log("Sent info to CardObject");


	//}

	//private void TestingPOCO(SO_OutpostCard outpostCardData) {
	//	POCO_OutpostCard pOCO_OutpostCard = new(outpostCardData);

	//	Debug.Log(pOCO_OutpostCard.GetCardName);
	//	pOCO_OutpostCard.GetDevelopmentCost(out int temp);
	//	Debug.Log(temp);

	//	pOCO_OutpostCard.DevelopmentCostAddition = temp;
	//	pOCO_OutpostCard.GetDevelopmentCost(out temp);
	//	Debug.Log(temp);

	//	pOCO_OutpostCard.DevelopmentCostAddition = -2;
	//	pOCO_OutpostCard.GetDevelopmentCost(out temp);
	//	Debug.Log(temp);

	//	pOCO_OutpostCard.DevelopmentCostAddition = 0;
	//	pOCO_OutpostCard.GetDevelopmentCost(out temp);
	//	Debug.Log(temp);

	//	pOCO_OutpostCard.DevelopmentCostMultiplier = 0.5f;
	//	pOCO_OutpostCard.GetDevelopmentCost(out temp);
	//	Debug.Log(temp);

	//	pOCO_OutpostCard.DevelopmentCostMultiplier = 0f;
	//	pOCO_OutpostCard.GetDevelopmentCost(out temp);
	//	Debug.Log(temp);
	//}

	//private void BruteTestSurfaceZone() {
	//	//Pull top card from surface deck, give to surfaceZone,
	//	//SurfaceZone then needs to create a card, set the values, and then move it to the correct spot.
	//	if (surfaceDeck.GetTopCard(out POCO_OutpostCard outpostCardInfo)) {
	//		surfaceZone.NewSurfaceCard(outpostCardInfo);
	//	}
	//}

	//private void BruteTestPlayerCardHand() {
	//	//Time to test the cardhand then
	//	while (playerHand.HandSize <= playerHand.MaxHandSize) {

	//		if (outpostDeck.GetTopCard(out POCO_OutpostCard outpostCardInfo)) {
	//			playerHand.TakeACard(outpostCardInfo);
	//		}
	//	}
	//}

	void Update() {

	}
}
