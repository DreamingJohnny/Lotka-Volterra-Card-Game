/*
 * Handles cards being attached and detached from this card, handling positioning and sorting order.
 * Also contains list of cards currently attached so that they can be queried later.
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CardSlotter : MonoBehaviour {

	//TODO: Both when cards are attached and detached, the CardScript on the parent card will need to be notified so that it can update its values.
	//TODO: Card positioning and sorting will need to be updated when a card is removed.

	private readonly int sortingLayerOffset = -1;
	private Vector3 positionOffset = new(0, -1.4f, 0);

	private List<CardObject> slottedCards = new();
	public List<CardObject> SlottedCards => slottedCards;

	public bool TryAttachCard(CardObject cardToSlot) {

		Debug.Log($"{name} was asked to attach {cardToSlot.name}.");

		if (cardToSlot == null) {
			Debug.LogWarning($"Was asked to attach a card that was null, and so cannot do it.");
			return false;
		}
		else if (slottedCards.Contains(cardToSlot)) {
			Debug.LogWarning($"{name} was asked to attach {cardToSlot.name}, but it is already attached.");
			return false;
		}
		else if (GetComponent<CardObject>().CardScript.GetCardType == CardType.Unit && cardToSlot.CardScript.GetCardType == CardType.Equipment) {
			slottedCards.Add(cardToSlot);

			// Set parent, position and sorting order.
			cardToSlot.transform.SetParent(transform);
			cardToSlot.transform.SetLocalPositionAndRotation(positionOffset * slottedCards.Count, Quaternion.identity);
			cardToSlot.GetComponent<SortingGroup>().sortingOrder = GetComponent<SortingGroup>().sortingOrder + slottedCards.Count * sortingLayerOffset;
			
			// Alert the CardScript on the parent card that a new card has been attached, so that it can update its values.
			GetComponent<CardObject>().UpdateAllFields();
			
			Debug.Log($"{name} successfully attached {cardToSlot.name}, and should've updated all of the values by now.");
			
			return true;
		}
		else {
			return false;
		}
	}

	public bool TryDetachCard(CardObject cardToDetach) {
		if (slottedCards.Remove(cardToDetach)) {
			cardToDetach.transform.SetParent(null);
			cardToDetach.GetComponent<SortingGroup>().sortingOrder = 0;
			GetComponent<CardObject>().UpdateAllFields();
			return true;
		}
		else {
			Debug.LogWarning($"{name} was asked to detach {cardToDetach.name}, but it was not found in the list of slotted cards.");
			return false;
		}
	}
}
