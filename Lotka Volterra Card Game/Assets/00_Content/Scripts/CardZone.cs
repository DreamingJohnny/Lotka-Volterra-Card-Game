/*
 * CardZone.cs
 * Handles the movement and behavior of cards within their areas,
 * Where the card should move,
 * If it is allowed in this zone,
 * If the cards are able to be interacted with at all
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour {

	[SerializeField] private List<CardType> approvedCardTypes = new();

	[SerializeField] private List<Transform> cardSlots = new();

	public int MaxCardSlots { get { return cardSlots.Count; } }

	public bool IsFull { get { if (Cards.Count >= MaxCardSlots) return true; return false; } }

	public readonly List<CardObject> Cards = new();

	public bool IsCardAllowed(CardObject cardObject) {
		if (cardObject == null) return false;
		else if (IsFull) return false;
		else {
			foreach (CardType cardType in approvedCardTypes) {
				if (cardType == cardObject.CardScript.GetCardType) return true;
			}
			return false;
		}
	}

	private void OnEnable() {

		SortCardSlots();
	}

	/// <summary>
	/// Clears the cardslots, then repopulates the list with all its current children transforms.
	/// Then Sorts the transforms so that the one furthest to the left, that is, with the lowest x value, is first in the index.
	/// </summary>
	private void SortCardSlots() {
		cardSlots.Clear();

		Transform[] temp = gameObject.GetComponentsInChildren<Transform>();

		foreach (Transform transform in temp) cardSlots.Add(transform);

		//Sorts the transforms so that the one furthest to the left, that is, with the lowest x value, is first in the index.
		cardSlots.Sort((x, y) => x.position.x.CompareTo(y.position.x));
	}

	public void AddCard(CardObject newCard) {

		if (!IsCardAllowed(newCard)) {
			Debug.Log($"{name} cannot receive the new card.");
			return;
		}
		else {

			//Will want to add an if else that checks if the card is already in the zone here as well I suppose.

			//So, here we basically say... look at how many cards we have, then take the card and give it to the spot with an index that is one higher.
			//Take that transform and send it back from here.
			//We actually don't want to remove one from number of Cards.Count here, seeing as we want the first free one, right?

			cardSlots[Cards.Count].transform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
			newCard.transform.SetPositionAndRotation(position, rotation);
			Cards.Add(newCard);

			//Remember that we need some way of reshuffling cards also, so that they have the correct position.
			//And this must then be done before the card adds itself to the list then? Otherwise the card will never take the first spot.

			//So, I think this is where I'd want to deal with the movement,
			//so I should have this script return a transform for where I want this card to go.
			//So, either the zone... the zone has a certain amount of child spots then. But those aren't the parent then? No, we should use the new movement system.
			//So this one should send a Vector3 back in that case? And a true of false?


			//newCard.transform.SetParent(gameObject.transform, false);

			//This feels like a bizzarre and unsafe way to handle this, might want to have more of a method for this somewhere maybe?
			PlayerCursor.SelectedCard = null;
		}
	}

	public CardObject GetCard(int cardSlot) {
		CardObject[] cardObjects = GetComponentsInChildren<CardObject>();

		if (cardObjects.Length == 0 || cardObjects.Length >= cardSlot) {
			return null;
		}
		else {
			return cardObjects[cardSlot];
		}
	}
}