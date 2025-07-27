/*
 * CardZone.cs
 * Handles the movement of cardObjects to and within their areas,
 * Decides where the cards should move, as in to what slot, within the zone,
 * If the cardObject is allowed in this zone,
 * If the cards are able to be interacted with at all
 * Also returns the cards in this zone that match a given predicate.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardZone : MonoBehaviour {

	[SerializeField] private List<CardType> approvedCardTypes = new();

	[SerializeField] private List<Transform> cardSlots = new();

	private readonly List<CardObject> cards = new();

	public int MaxCardSlots { get { return cardSlots.Count; } }

	public int CurrentCardCount { get { return cards.Count; } }

	public bool IsFull { get { if (cards.Count < cardSlots.Count) return false; return true; } }

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

		//Populates the cardSlots list with all the immediate children transforms of this transform.
		foreach (Transform child in transform) cardSlots.Add(child);

		//Sorts the transforms so that the one furthest to the left, that is, with the lowest x value, is first in the index.
		cardSlots.Sort((x, y) => x.position.x.CompareTo(y.position.x));
	}

	/// <summary>
	/// Re-aligns all cards in this zone to their respective slots.
	/// </summary>
	private void ReAlignCards() {
		for (int i = 0; i < cards.Count; i++) {
			if (i < cardSlots.Count) {
				//As long as there are enough slots for the cards, we align them to the slots. Going from left to right.
				cards[i].transform.SetPositionAndRotation(cardSlots[i].position, cardSlots[i].rotation);
			}
			else {
				Debug.LogWarning($"{name} has more cards than slots, card {cards[i].name} will not be aligned.");
			}

		}
	}

	/// <summary>
	/// Receives a CardObject and checks if it is allowed in this zone. If so, it sets the position of the card to the first free slot in the zone,
	/// </summary>
	/// <param name="newCard"></param>
	/// <returns></returns>
	public bool TryAddCard(CardObject newCard) {

		if (!IsCardAllowed(newCard)) {
			Debug.Log($"{name} cannot receive the new card.");
			return false;
		}
		else if (cards.Contains(newCard)) {
			Debug.LogWarning($"{name} already contains the card {newCard.name}, so it will not be added again.");
			return false;
		}
		else {
			cardSlots[cards.Count].transform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
			newCard.transform.SetPositionAndRotation(position, rotation);

			cards.Add(newCard);
			newCard.CurrentZone = this;

			Debug.Log("Number of cards in zone: " + cards.Count);
			return true;
		}
	}

	public void RemoveCard(CardObject cardObject) {

		if (cards.Contains(cardObject)) {
			cards.Remove(cardObject);
			Debug.Log("Number of cards in zone: " + cards.Count);
			ReAlignCards();
		}
		else {
			Debug.LogWarning($"{name} tried to remove {cardObject.name} but it was not in its list of cards.");
		}
	}

	public List<CardObject> GetCardsMatching(Func<CardObject, bool> predicate) {
		return cards.Where(predicate).ToList();
	}
}