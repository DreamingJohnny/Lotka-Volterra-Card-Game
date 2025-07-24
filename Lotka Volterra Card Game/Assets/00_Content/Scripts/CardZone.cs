/*
 * CardZone.cs
 * Handles the movement of cardObjects to and within their areas,
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

	public readonly List<CardObject> Cards = new();

	public int MaxCardSlots { get { return cardSlots.Count; } }

	public bool IsFull { get { if (Cards.Count < cardSlots.Count) return false; return true; } }

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

		Debug.Log($"{name} has sorted its card slots, their positions are now:");
		foreach (Transform slot in cardSlots) {
			slot.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
			Debug.Log($"Position: {position}, Rotation: {rotation}");
		}
	}

	private void ReAlignCards() { 
		for (int i = 0; i < Cards.Count; i++) {
			if (i < cardSlots.Count) {
				//As long as there are enough slots for the cards, we align them to the slots. Going from left to right.
				Cards[i].transform.SetPositionAndRotation(cardSlots[i].position, cardSlots[i].rotation);
			}
			else {
				//If there are more cards than slots, we log a warning.
				Debug.LogWarning($"{name} has more cards than slots, card {Cards[i].name} will not be aligned.");
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
		else {

			//TODO: Might need check for, if code is already inside the zone, esp so that it doesn't update its placement then.

			cardSlots[Cards.Count].transform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
			newCard.transform.SetPositionAndRotation(position, rotation);

			Debug.Log($"{name} received a new card and given it the position {position} with rotation {rotation}.");
			Cards.Add(newCard);

			foreach (CardObject card in Cards) {
				Debug.Log($"{card.name} is now in position {card.transform.position}.");
			}

			return true;
			//This feels like a bizzarre and unsafe way to handle this, might want to have more of a method for this somewhere maybe?
			//PlayerCursor.SelectedCard = null;
		}
	}

	public CardObject GetCard(int cardSlot) {
		//TODO: Look into if this method needs to be completely reworked, I think we'd want to use a different way of asking for cards.
		CardObject[] cardObjects = GetComponentsInChildren<CardObject>();

		if (cardObjects.Length == 0 || cardObjects.Length >= cardSlot) {
			return null;
		}
		else {
			return cardObjects[cardSlot];
		}
	}

	internal void RemoveCard(CardObject cardObject) {
		if(Cards.Contains(cardObject)) {
			Cards.Remove(cardObject);
			Debug.Log($"{name} removed {cardObject.name} from its list of cards.");
			// Realigns the remaining cards to their slots.
			ReAlignCards();
		}
		else {
			Debug.LogWarning($"{name} tried to remove {cardObject.name} but it was not in its list of cards.");
		}
	}
}