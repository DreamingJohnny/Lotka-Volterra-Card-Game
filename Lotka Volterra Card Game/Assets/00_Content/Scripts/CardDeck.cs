/*
 * CardDeck.cs
 * Acts as a deck of SO_CardData, keeps track of what order they are in,
 * Is also able to be reshuffled, have card added to the top or bottom.
 * Can search for a specific SO_CardData, and can either retrieve it or leave it.
 */

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDeck : MonoBehaviour {

	private Queue<SO_CardData> cardDatas = new();

	/// <summary>
	/// Returns true and amount of cardDatas in the deck, or false and amount 0 if there are no carddatas in the deck.
	/// </summary>
	/// <param name="amount"></param>
	/// <returns></returns>
	public bool GetCardAmount(out int amount) {

		if (cardDatas.Count > 0) {
			amount = cardDatas.Count;
			return true;
		}
		else {
			amount = 0;
			return false;
		}
	}

	/// <summary>
	/// Set the received list of cards to be the queue of cards in the deck. Does NOT shuffle them.
	/// </summary>
	/// <param name="newDeck"></param>
	public void SetNewDeck(List<SO_CardData> newDeck) {
		cardDatas = new Queue<SO_CardData>(newDeck);
	}

	/// <summary>
	/// Shuffles the current queue of cards in the deck.
	/// </summary>
	public void ShuffleDeck() {
		if (!GetCardAmount(out _)) return;

		cardDatas = new Queue<SO_CardData>(ShuffleDeck(cardDatas.ToList()));
	}

	/// <summary>
	/// Shuffles the parameter list of cards and then returns it.
	/// </summary>
	/// <param name="newDeck"></param>
	/// <returns></returns>
	private List<SO_CardData> ShuffleDeck(List<SO_CardData> newDeck) {

		System.Random random = new();

		for (int n = newDeck.Count - 1; n > 0; --n) {
			int k = random.Next(n + 1);
			(newDeck[k], newDeck[n]) = (newDeck[n], newDeck[k]);
		}

		return newDeck;
	}

	public Queue<SO_CardData> GetTopCards(int amount) {

		Queue<SO_CardData> topCards = new();

		for (int i = 0; i < amount && cardDatas.Count > 0; i++) {
			topCards.Enqueue(cardDatas.Dequeue());
		}

		if (topCards.Count < amount) Debug.LogWarning($"CardDeck tried to get {amount} cards, but there were not enough cards in the deck.");

		return topCards;
	}

	public void PutOnTop(Queue<SO_CardData> newCards) {
		if (newCards == null || newCards.Count == 0) return;

		cardDatas = new(newCards.Concat(cardDatas));
	}

	public void PutOnBottom(Queue<SO_CardData> newCards) {
		if (newCards == null || newCards.Count == 0) return;
		foreach (SO_CardData card in newCards) cardDatas.Enqueue(card);
	}
}
