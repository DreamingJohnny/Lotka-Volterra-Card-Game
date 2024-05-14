using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[Header("Player")]
	[SerializeField] private CardDeck outpostDeck;
	[SerializeField] private DiscardPile outpostDiscardPile;
	[SerializeField] private CardHand playerHand;
	[SerializeField] private CardZone personalityZone;
	[SerializeField] private CardZone outpostZone;
	[SerializeField] private OutpostCardObject outpostCardObject;
	private Queue<OutpostCardObject> outpostCards;

	[Header("Surface")]
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private DiscardPile surfaceDiscardPile;
	[SerializeField] private CardZone surfaceZone;
	private Queue<SurfaceCardObject> surfaceCards;

	[Header("General")]
	[SerializeField] private List<SO_SurfaceCardData> sO_SurfaceCardDatas;
	[SerializeField] private List<SO_OutpostCardData> sO_OutpostCardDatas;

	[Header("Ugly Testing")]
	[SerializeField] private SO_CardData testCardData;
	[SerializeField] private OutpostCardObject testCard;

	[SerializeField] private ObjectPool objectPooler;

	void Start() {

		outpostCards = new Queue<OutpostCardObject>();
		//surfaceCards = new Queue<SurfaceCardObject>();

		//BruteTestingObjectPooling();

		BruteTestingPersonalityZone(GetCardObject(new OutpostCardScript(sO_OutpostCardDatas[0])));

		BruteTestingOutpostZone();

		//BruteTestingDiscardPile(new OutpostCardScript(sO_OutpostCardDatas[1]));
	}

	private void BruteTestingOutpostZone() {
		Debug.Log("Adding a first outpostcard to the outpostZone");
		outpostZone.AddCard(GetCardObject(new OutpostCardScript(sO_OutpostCardDatas[1])));
		Debug.Log("Adding a second outpostcard to the outpostZone");
		outpostZone.AddCard(GetCardObject(new OutpostCardScript(sO_OutpostCardDatas[2])));
	}

	private void BruteTestingObjectPooling() {
		Debug.Log(objectPooler.ObjectPoolAmount);

		GameObject test = objectPooler.GetObject();
		test.SetActive(true);
		test.transform.position = Vector3.zero;
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
		if(outpostCards.Count <= 0) {
			Debug.Log("Creating a new outpostcard object");
			OutpostCardObject outpostCard = Instantiate(outpostCardObject);
			outpostCard.SetCardScript(outpostCardScript);
			return outpostCard;
		} else {
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
			return surfaceCard;
		} else {
			SurfaceCardObject surfaceCard = surfaceCards.Dequeue();
			surfaceCard.SetCardScript(surfaceCardScript);
			surfaceCard.gameObject.SetActive(true);
			return surfaceCard ;
		}
	}
	
	private void BruteTestingDiscardPile(CardScript cardScript) {
		outpostDiscardPile.SendToDiscard(cardScript);		
	}

	private void BruteTestingPersonalityZone(OutpostCardObject outpostCardObject) {
		personalityZone.AddCard(outpostCardObject);
	}
}
