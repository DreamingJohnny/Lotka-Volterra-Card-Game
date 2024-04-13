using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[SerializeField] private CardDeck outpostDeck;
	[SerializeField] private CardHand playerHand;
	
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private SurfaceZone surfaceZone;
	[SerializeField] private SO_OutpostCard outpostCardData;


	void Start() {
		//TestingPOCO(outpostCardData);
		
		//BruteTestPlayerCardHand();

		//BruteTestSurfaceZone();
	}

	private void TestingPOCO(SO_OutpostCard outpostCardData) {
		POCO_OutpostCard pOCO_OutpostCard = new(outpostCardData);

		Debug.Log(pOCO_OutpostCard.GetCardName);
		pOCO_OutpostCard.GetDevelopmentCost(out int temp);
		Debug.Log(temp);

		pOCO_OutpostCard.DevelopmentCostAddition = temp;
		pOCO_OutpostCard.GetDevelopmentCost(out temp);
		Debug.Log(temp);

		pOCO_OutpostCard.DevelopmentCostAddition = -2;
		pOCO_OutpostCard.GetDevelopmentCost(out temp);
		Debug.Log(temp);

		pOCO_OutpostCard.DevelopmentCostAddition = 0;
		pOCO_OutpostCard.GetDevelopmentCost(out temp);
		Debug.Log(temp);

		pOCO_OutpostCard.DevelopmentCostMultiplier = 0.5f;
		pOCO_OutpostCard.GetDevelopmentCost(out temp);
		Debug.Log(temp);

		pOCO_OutpostCard.DevelopmentCostMultiplier = 0f;
		pOCO_OutpostCard.GetDevelopmentCost(out temp);
		Debug.Log(temp);
	}

	private void BruteTestSurfaceZone() {
		//Pull top card from surface deck, give to surfaceZone,
		//SurfaceZone then needs to create a card, set the values, and then move it to the correct spot.
		ScriptableObject scriptableObject = surfaceDeck.GetTopCard();

		surfaceZone.NewSurfaceCard(scriptableObject as SO_SurfaceCard);
	}

	private void BruteTestPlayerCardHand() {
		//Time to test the cardhand then
		while (playerHand.HandSize <= playerHand.MaxHandSize) {

			ScriptableObject scriptableObject = outpostDeck.GetTopCard();

			playerHand.TakeACard(scriptableObject as SO_OutpostCard);
		}
	}

	void Update() {

	}
}
