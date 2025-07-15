/*
 * CardHand.cs
 * Handles the behavior of a player's hand of cards, such as how they look, where they should be placed, and how they should move,
 * Also tells the cards when they are allowed to be interacted with.
 * Also handles general information about the hand of cards, such as max size, number of cards etc.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour {

	private List<OutpostCardObject> outpostCards = new();

	public int MaxHandSize { get; private set; }

	public int HandSize { get {	return outpostCards.Count; } }

	public bool IsFull { get { if (HandSize < MaxHandSize) return false; return true; } }

}