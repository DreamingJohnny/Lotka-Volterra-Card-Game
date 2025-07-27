/*
 * Central script that handles setup, teardown, and also calls on other functions to run when it is their turn-order.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[Header("Player shared")]
	[SerializeField] private int startingHandSize = 2;

	[Header("Player 1")]
	[SerializeField] private CardDeck outpostDeck_1;
	[SerializeField] private DiscardPile outpostDiscardPile_1;
	[SerializeField] private CardZone playerHand_1;

	[Header("Player 2")]
	[SerializeField] private CardDeck outpostDeck_2;
	[SerializeField] private DiscardPile outpostDiscardPile_2;
	[SerializeField] private CardZone playerHand_2;

	[Header("Outpost")]
	[SerializeField] private CardZone personalityZone;
	[SerializeField] private CardZone outpostZone;
	[SerializeField] private CardZone underDevelopmentZone;
	[SerializeField] private CardZone technologyZone;
	[SerializeField] private CardZone equipmentZone;
	//I wonder if I could remove both of these actually...?
	[SerializeField] private OutpostCardObject outpostCardObject;
	[SerializeField] private SO_OutpostData outpostData;

	[Header("Surface")]
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private DiscardPile surfaceDiscardPile;
	[SerializeField] private CardZone surfaceZone;

	[Header("General")]
	[SerializeField] private List<SO_CardData> sO_SurfaceCardDatas;
	[SerializeField] private List<SO_CardData> sO_OutpostCardDatas;

	[Header("UI")]
	[SerializeField] private UIHandler uiHandler;

	void Start() {
		SetUpFirstGame();
		DoNextTurnPhase();

		//DoTestingCardDeck();
	}

	private void DoTestingCardDeck() {
		Debug.Log("Testing CardDeck...");
		Debug.Log(surfaceDeck.GetCardAmount(out int amount));
		if (amount > 0) {
			Debug.Log($"There are {amount} cards in the surfaceDeck");
			if (surfaceDeck.GetTopCard(out SO_CardData surfaceCardData)) {
				Debug.Log($"The top card is {surfaceCardData.name}");
			}
			else {
				Debug.Log("There was no top card in the surfaceDeck");
			}
		}
		else {
			Debug.Log("There are no cards in the surfaceDeck");
		}

		for (int i = 0; i < 10; i++) {
			Debug.Log("Shuffling surfaceDeck...");
			surfaceDeck.ShuffleDeck();
			Debug.Log("Topcard after shuffling:");
			if (surfaceDeck.GetTopCardName(out string cardname)) {
				Debug.Log(cardname);
			}
			else {
				Debug.Log("There was no top card in the surfaceDeck");
			}
		}
	}

	private void Update() {
		if (Input.GetMouseButtonDown(1)) PlayerCursor.DeSelectCard();
	}

	private void DoNextTurnPhase() {

		switch (GameStats.TurnSegment) {
			case TurnSegment.AtStartOfTurn:
				GameStats.IncreaseTurnSegment();
				break;
			case TurnSegment.AfterStartOfTurn:
				GameStats.IncreaseTurnSegment();
				break;
			case TurnSegment.InitiativePhaseStart:
				
				break;
			case TurnSegment.AfterInitiativePhaseStart:
				break;
			case TurnSegment.BeforePlayerOrderSelected:
				Debug.Log("For now I think it will be fine if we just decide that player one goes first.");
				break;
			case TurnSegment.WhenPlayerOrderSelected:
				break;
			case TurnSegment.AfterPlayerOrderSelected:
				break;
			case TurnSegment.BeforeSurfaceCardIsDrawn:
				break;
			case TurnSegment.WhenSurfaceCardIsDrawn:
				DoDrawSurfaceCards();
				break;
			case TurnSegment.AfterSurfaceCardIsDrawn:
				break;
			case TurnSegment.BeforeSelectDayCycle:
				uiHandler.ActivateDayNightToggle(true);
				break;
			case TurnSegment.WhenSelectDayCycle:
				break;
			case TurnSegment.AfterSelectDayCycle:
				uiHandler.ActivateDayNightToggle(false);
				break;
			case TurnSegment.WhenPlanningPhaseStarts:
				break;
			case TurnSegment.AfterPlanningPhaseStarts:
				break;
			case TurnSegment.PlayCard:
				//So here we need to have a button that says, first player is done then?
				//So, activate first players areas and cards
				//And the button for skipping.
				break;
			case TurnSegment.WhenDayPhaseStarts:
				break;
			case TurnSegment.AfterDayPhaseStarts:
				break;
			case TurnSegment.Initiative:
				break;
			case TurnSegment.Planning:
				break;
			case TurnSegment.Day:
				break;
			case TurnSegment.Night:
				break;
			case TurnSegment.Resolution:
				DoDevelopmentPhase();
				break;
			case TurnSegment.Upkeep:
				DoUpkeepPhase();
				break;
			default:
				break;
		}
	}

	private void DoDrawSurfaceCards() {

		for (int i = 0; i < GameStats.ThreatLevel; i++) {
			if (surfaceDeck.GetTopCard(out SO_CardData cardData)) {
				if (cardData is SO_SurfaceCardData surfaceCardData) surfaceZone.TryAddCard(CardPool.Instance.GetCardObject(surfaceCardData));

				else if (cardData is SO_OutpostCardData outpostCardData) surfaceZone.TryAddCard(CardPool.Instance.GetCardObject(outpostCardData));

				else Debug.Log($"{name} retrieved a scriptable card data from {surfaceDeck.name} that it couldn't cast to either SO_surfaceCardData or SO_outpostCardData, instead it's name was {cardData.name}.");
			}
			else Debug.Log($"{name} asked for a card from {surfaceDeck.name} but received false back");
		}
	}
	private void DoUpkeepPhase() {

		//So, Gamestats produces...
		if (Outpost.GetIncome(out int income)) Outpost.Resources += income;

		//Later on, this one will need to be turned into something bigger where you look for all upkeep from current cards etc...
		if (Outpost.GetUpkeep(out int upkeep)) Outpost.Resources -= upkeep;

		GameStats.IncreaseSporeCount(1);
	}

	private void DoDevelopmentPhase() {

		PlayerOneHandDrawsOneCard();
		PlayerTwoHandDrawsOneCard();
	}

	private void SetUpFirstGame() {
		GameStats.InitGame();
		
		Outpost.SetOutpostData(outpostData);
		Outpost.InitGame();

		uiHandler.OnNextButtonPressed += HandleOnNextButtonPressed;

		Debug.Log("Setting up outpostDeck...");
		outpostDeck_1.SetNewDeck(sO_OutpostCardDatas);
		outpostDeck_2.SetNewDeck(sO_OutpostCardDatas);

		Debug.Log("Setting up surfaceDeck...");
		surfaceDeck.SetNewDeck(sO_SurfaceCardDatas);

		SetupFirstOutpostCardHand();
	}

	private void HandleOnNextButtonPressed() {
		GoToNextTurnStage();
	}

	private void GoToNextTurnStage() {
		GameStats.IncreaseTurnSegment();

		DoNextTurnPhase();
	}

	private void PlayerOneHandDrawsOneCard() {
		if(outpostDeck_1.GetTopCard(out SO_CardData cardData)) {
			//OutpostCardScript outpostCardScript = cardData as OutpostCardScript;
			//TODO: I'll eiter need to change this to a more generic method, dealing or receiving cards, or I will have an explicit cast here or something.
			OutpostCardObject temp = (OutpostCardObject)CardPool.Instance.GetCardObject(cardData);
			//This line below, it is actually probably in this method we want to check if they should receive the card.
			playerHand_1.TryAddCard(temp);
			temp.gameObject.SetActive(true);
			Debug.Log("One card created!");
		}
	}

	private void PlayerTwoHandDrawsOneCard() {
		if (outpostDeck_2.GetTopCard(out SO_CardData cardData)) {
			SO_OutpostCardData outpostCardData = cardData as SO_OutpostCardData;
			OutpostCardObject temp = (OutpostCardObject)CardPool.Instance.GetCardObject(outpostCardData);
			playerHand_2.TryAddCard(temp);
			temp.gameObject.SetActive(true);
			Debug.Log("One card created!");
		}
	}


	private void SetupFirstOutpostCardHand() {
		//Give the player their cards,
		for (int i = 0; i < startingHandSize; i++) {
			PlayerOneHandDrawsOneCard();
			PlayerTwoHandDrawsOneCard();
		}

		//Later on, work on mulligan here
		//Show button signifying, that they are happy and wants to go to the next stage...
	}

	//Initiative
	private void InitiativeStepSurfaceCards() {

		//Send threat level to surfacedeck?
		for (int i = 0; i < GameStats.ThreatLevel; i++) {
			if (surfaceDeck.GetTopCard(out SO_CardData cardData)) {

				if (cardData is SO_SurfaceCardData surfaceCardData) {

					surfaceZone.TryAddCard(CardPool.Instance.GetCardObject(surfaceCardData));
				}
				else if (cardData is SO_OutpostCardData outpostCardData) {
					surfaceZone.TryAddCard(CardPool.Instance.GetCardObject(outpostCardData));
				}
				else {
					Debug.Log($"{name} retrieved a script from {surfaceDeck.name} that it couldn't cast it as either SurfaceCardScript or OutpostCardScript");
				}
			}
			else {
				Debug.Log($"{name} asked for a card from the surfaceDeck {surfaceDeck.name} but received false back");
			}
		}
	}
}
