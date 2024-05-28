using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[Header("Player")]
	[SerializeField] private CardDeck outpostDeck;
	[SerializeField] private DiscardPile outpostDiscardPile;
	[SerializeField] private CardZone playerHand;
	[SerializeField] private CardZone personalityZone;
	[SerializeField] private CardZone outpostZone;
	[SerializeField] private CardZone developmentZone;
	[SerializeField] private OutpostCardObject outpostCardObject;
	private Queue<OutpostCardObject> outpostCards;
	[SerializeField] private SO_OutpostData outpostData;

	[SerializeField] private int startingHandSize = 2;

	[Header("Surface")]
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private DiscardPile surfaceDiscardPile;
	[SerializeField] private CardZone surfaceZone;
	private Queue<SurfaceCardObject> surfaceCards;

	[Header("General")]
	[SerializeField] private List<SO_CardData> sO_SurfaceCardDatas;
	[SerializeField] private List<SO_CardData> sO_OutpostCardDatas;

	[Header("Interactions")]
	private CardObject selectedCard;

	[Header("UI")]
	[SerializeField] private UIHandler uiHandler;

	void Start() {
		
		//This should be removed as soon as I've added back objectpooling into the game.
		outpostCards = new Queue<OutpostCardObject>();

		selectedCard = null;

		SetUpFirstGame();

	}

	private void Update() {

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
		if (!playerHand.IsFull) {
			if (outpostDeck.GetTopCard(out CardScript cardScript)) {
				CardObject temp = GetCardObject(cardScript as OutpostCardScript);
				temp.transform.SetParent(playerHand.transform, false);
				temp.gameObject.SetActive(true);
				Debug.Log("Card created!");
			}
		}
	}

	private void SetUpFirstGame() {
		GameStats.InitGame();
		Outpost.SetOutpostData(outpostData);
		Outpost.InitGame();

		SubscribeToZones();

		uiHandler.OnNextButtonPressed += HandleOnNextButtonPressed;

		Debug.Log("Setting up outpostDeck...");
		outpostDeck.SetNewDeck(sO_OutpostCardDatas);

		Debug.Log("Setting up surfaceDeck...");
		surfaceDeck.SetNewDeck(sO_SurfaceCardDatas);

		SetupFirstOutpostCardHand();

	}

	private void HandleOnNextButtonPressed() {
		GameStats.IncreaseTurnSegment();

		DoNextTurnPhase();
	}

	private void SubscribeToZones() {
		playerHand.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		personalityZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		outpostZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		developmentZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
	}

	private void SetupFirstOutpostCardHand() {
		Debug.Log("Setting up the players initial card hand...");
		//Give the player their cards,
		for (int i = 0; i < startingHandSize; i++) {

			if (outpostDeck.GetTopCard(out CardScript cardScript)) {
				CardObject temp = GetCardObject(cardScript as OutpostCardScript);
				temp.transform.SetParent(playerHand.transform, false);
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
			temp.transform.SetParent(playerHand.transform, false);
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
			outpostCard.GetComponent<CardSelection>().OnCardSelected += HandleOnCardSelected;
			return outpostCard;
		}
		else {
			OutpostCardObject outpostCard = outpostCards.Dequeue();
			outpostCard.SetCardScript(outpostCardScript);
			outpostCard.gameObject.SetActive(true);
			return outpostCard;
		}
	}

	private void HandleOnCardSelected(CardSelection card) {

		if (card.TryGetComponent(out CardObject cardObject)) {
			selectedCard = cardObject;
		}
		else {
			Debug.Log("The GM just registered an event for a object that doesn't seem to be a CardObject");
		}
	}

	private void HandleOnZoneSelected(ZoneSelection zone) {

		if (selectedCard == null) {
			Debug.Log("SelectedCard was null");
			return;
		}
		else {
			if (zone.TryGetComponent(out CardZone cardZone)) {
				if (cardZone.IsCardAllowed(selectedCard)) {
					//Later on, I want to have a think here, where I send the card of to a function, and I get it back if it isn't acceptable, what would that be like?
					selectedCard.transform.SetParent(zone.transform, false);
					selectedCard = null;
				}
			}
			else if (zone.TryGetComponent(out DiscardPile discardPile)) {
				discardPile.RecieveCard(selectedCard);
			}
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
			surfaceCard.GetComponent<CardSelection>().OnCardSelected += HandleOnCardSelected;
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
