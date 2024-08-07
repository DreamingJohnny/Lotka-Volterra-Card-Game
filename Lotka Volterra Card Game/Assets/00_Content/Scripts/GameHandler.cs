using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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
			if (surfaceDeck.GetTopCard(out CardScript cardScript)) {
				if (cardScript is SurfaceCardScript surfaceScript) surfaceZone.AddCard(CardPool.Instance.GetCardObject(surfaceScript));

				else if (cardScript is OutpostCardScript outpostScript) surfaceZone.AddCard(CardPool.Instance.GetCardObject(outpostScript));

				else Debug.Log($"{name} retrieved a script from {surfaceDeck.name} that it couldn't cast to either surfaceScript or CardScript");
			}
			else Debug.Log($"{name} asked for a card from the surfaceDeck {surfaceDeck.name} but received false back");
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
		if(outpostDeck_1.GetTopCard(out CardScript cardScript)) {
			OutpostCardScript outpostCardScript = cardScript as OutpostCardScript;
			OutpostCardObject temp = CardPool.Instance.GetCardObject(outpostCardScript);
			//This line below, it is actually probably in this method we want to check if they should receive the card.
			playerHand_1.AddCard(temp);
			temp.gameObject.SetActive(true);
			Debug.Log("One card created!");
		}
	}

	private void PlayerTwoHandDrawsOneCard() {
		if (outpostDeck_2.GetTopCard(out CardScript cardScript)) {
			OutpostCardScript outpostCardScript = cardScript as OutpostCardScript;
			OutpostCardObject temp = CardPool.Instance.GetCardObject(outpostCardScript);
			playerHand_2.AddCard(temp);
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
			if (surfaceDeck.GetTopCard(out CardScript cardScript)) {

				if (cardScript is SurfaceCardScript surfaceScript) {

					surfaceZone.AddCard(CardPool.Instance.GetCardObject(surfaceScript));
				}
				else if (cardScript is OutpostCardScript outpostScript) {
					surfaceZone.AddCard(CardPool.Instance.GetCardObject(outpostScript));
				}
				else {
					Debug.Log($"{name} retrieved a script from {surfaceDeck.name} that it couldn't cast to either surfaceScript or CardScript");
				}
			}
			else {
				Debug.Log($"{name} asked for a card from the surfaceDeck {surfaceDeck.name} but received false back");
			}
		}
	}
}
