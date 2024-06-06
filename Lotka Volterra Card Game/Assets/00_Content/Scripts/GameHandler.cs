using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[Header("Player 1")]
	[SerializeField] private int startingHandSize = 2;
	[SerializeField] private CardDeck outpostDeck_1;
	[SerializeField] private DiscardPile outpostDiscardPile_1;
	[SerializeField] private CardHand playerHand_1;

	[Header("Player 2")]
	[SerializeField] private CardDeck outpostDeck_2;
	[SerializeField] private DiscardPile outpostDiscardPile_2;
	[SerializeField] private CardHand playerHand_2;

	[Header("Outpost")]
	[SerializeField] private CardZone personalityZone;
	[SerializeField] private CardZone outpostZone;
	[SerializeField] private CardZone underDevelopmentZone;
	[SerializeField] private CardZone technologyZone;
	[SerializeField] private CardZone equipmentZone;
	[SerializeField] private OutpostCardObject outpostCardObject;
	[SerializeField] private SO_OutpostData outpostData;
	private Queue<OutpostCardObject> outpostCards;


	[Header("Surface")]
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private DiscardPile surfaceDiscardPile;
	[SerializeField] private CardZone surfaceZone;
	private Queue<SurfaceCardObject> surfaceCards;

	[Header("General")]
	[SerializeField] private List<SO_CardData> sO_SurfaceCardDatas;
	[SerializeField] private List<SO_CardData> sO_OutpostCardDatas;

	[Header("UI")]
	[SerializeField] private UIHandler uiHandler;

	void Start() {

		//This should be removed as soon as I've added back objectpooling into the game.
		outpostCards = new Queue<OutpostCardObject>();

		SetUpFirstGame();

	}

	private void Update() {
		if(Input.GetMouseButtonDown(1)) PlayerCursor.DeSelectCard();
	}

	private void DoNextTurnPhase() {

		switch (GameStats.TurnSegment) {
			case TurnSegment.Initiative:
				InitiativeStepSurfaceCards();

				break;
			case TurnSegment.Planning:
				Debug.Log("Here we will want button so that the play can go to the next step...");

				break;
			case TurnSegment.Day:
				Debug.Log("Zones are selectable, and cards and movable.");
				break;
			case TurnSegment.Night:
				Debug.Log("Zones are selectable, and cards and movable.");
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

	private void DoUpkeepPhase() {

		//So, Gamestats produces...
		if (Outpost.GetIncome(out int income)) Outpost.Resources += income;

		//Later on, this one will need to be turned into something bigger where you look for all upkeep from current cards etc...
		if (Outpost.GetUpkeep(out int upkeep)) Outpost.Resources -= upkeep;

		GameStats.IncreaseSporeCount(1);
	}

	private void DoDevelopmentPhase() {

		//Player draws one card here...
		if (!playerHand_1.IsFull) {
			if (outpostDeck_1.GetTopCard(out CardScript cardScript)) {
				CardObject temp = GetCardObject(cardScript as OutpostCardScript);
				temp.transform.SetParent(playerHand_1.transform, false);
				temp.gameObject.SetActive(true);
				Debug.Log("Card created!");
			}
		}
	}

	private void SetUpFirstGame() {
		GameStats.InitGame();
		Outpost.SetOutpostData(outpostData);
		Outpost.InitGame();

		uiHandler.OnNextButtonPressed += HandleOnNextButtonPressed;

		Debug.Log("Setting up outpostDeck...");
		outpostDeck_1.SetNewDeck(sO_OutpostCardDatas);

		Debug.Log("Setting up surfaceDeck...");
		surfaceDeck.SetNewDeck(sO_SurfaceCardDatas);

		SetupFirstOutpostCardHand();

	}

	private void HandleOnNextButtonPressed() {
		GameStats.IncreaseTurnSegment();

		DoNextTurnPhase();
	}

	private void SetupFirstOutpostCardHand() {
		Debug.Log("Setting up the players initial card hand...");
		//Give the player their cards,
		for (int i = 0; i < startingHandSize; i++) {

			if (outpostDeck_1.GetTopCard(out CardScript cardScript)) {
				CardObject temp = GetCardObject(cardScript as OutpostCardScript);
				temp.transform.SetParent(playerHand_1.transform, false);
				temp.gameObject.SetActive(true);
				Debug.Log("Card created!");
			}
		}

		//Later on, work on mulligan here
		//Show button signifying, that they are happy and wants to go to the next stage...
	}

	//Initiative
	private void InitiativeStepSurfaceCards() {
		//Send threat level to surfacedeck?
		int tempThreat = GameStats.ThreatLevel;

		for (int i = 0; i < tempThreat; i++) {
			if (surfaceDeck.GetTopCard(out CardScript cardScript)) {

				if (cardScript is SurfaceCardScript surfaceScript) {
					surfaceZone.AddCard(GetCardObject(surfaceScript));
				}
				else if (cardScript is OutpostCardScript outpostScript) {
					surfaceZone.AddCard(GetCardObject(outpostScript));
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

	private void FirstTestOfSelections() {

		foreach (SO_OutpostCardData cardData in sO_OutpostCardDatas) {
			CardObject temp = GetCardObject(new OutpostCardScript(cardData));
			temp.transform.SetParent(playerHand_1.transform, false);
			temp.gameObject.SetActive(true);
			Debug.Log("Card created!");
		}
	}

	/// <summary>
	/// Adds the card to the queue of cards and sets the gameobject to inactive
	/// </summary>
	/// <param name="outpostCardObject"></param>
	private void AddUnusedCard(OutpostCardObject outpostCardObject) {
		outpostCards.Enqueue(outpostCardObject);
		outpostCardObject.gameObject.SetActive(false);
	}

	/// <summary>
	/// Adds the card to the queue of cards and sets the gameobject to inactive
	/// </summary>
	/// <param name="surfaceCardObject"></param>
	private void AddUnusedCard(SurfaceCardObject surfaceCardObject) {
		surfaceCards.Enqueue(surfaceCardObject);
		surfaceCardObject.gameObject.SetActive(false);
	}

	/// <summary>
	/// Returns an activated gameobject outpostCardObject populated with the script. Reuses gameobject when possible.
	/// </summary>
	/// <param name="outpostCardScript"></param>
	/// <returns></returns>
	private OutpostCardObject GetCardObject(OutpostCardScript outpostCardScript) {
		if (outpostCards.Count <= 0) {
			Debug.Log("Creating a new outpostcard object");
			OutpostCardObject outpostCard = Instantiate(outpostCardObject);
			outpostCard.SetCardScript(outpostCardScript);
			//outpostCard.GetComponent<CardSelection>().OnCardSelected += HandleOnCardSelected;
			return outpostCard;
		}
		else {
			OutpostCardObject outpostCard = outpostCards.Dequeue();
			outpostCard.SetCardScript(outpostCardScript);
			outpostCard.gameObject.SetActive(true);
			return outpostCard;
		}
	}

	/// <summary>
	/// Returns an activated surfaceCardObject-gameobject populated with the script. Reuses gameobject when possible.
	/// </summary>
	/// <param name="surfaceCardScript"></param>
	/// <returns></returns>
	private SurfaceCardObject GetCardObject(SurfaceCardScript surfaceCardScript) {
		if (surfaceCards.Count <= 0) {
			SurfaceCardObject surfaceCard = new();
			surfaceCard.SetCardScript(surfaceCardScript);
			//surfaceCard.GetComponent<CardSelection>().OnCardSelected += HandleOnCardSelected;
			return surfaceCard;
		}
		else {
			SurfaceCardObject surfaceCard = surfaceCards.Dequeue();
			surfaceCard.SetCardScript(surfaceCardScript);
			surfaceCard.gameObject.SetActive(true);
			return surfaceCard;
		}
	}
}
