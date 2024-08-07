using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;

public class CardDeck : MonoBehaviour {

	/*To look for a specific SO in the queue.
	 * Oh, and it needs to be able to look at them and then put them back... hm...
	 * This one might actually need to be handled by someone else instead.
	*/

	private Queue<SO_CardData> cards = new();

	/// <summary>
	/// Returns true and amount of cards in the deck, or false and amount 0 if there are not cards in the deck.
	/// </summary>
	/// <param name="amount"></param>
	/// <returns></returns>
	public bool GetCardAmount(out int amount) {

		if (cards.Count > 0) {
			amount = cards.Count;
			return true;
		}
		else {
			amount = 0;
			return false;
		}
	}

	/// <summary>
	/// Set the received list of cards to be the queue of cards in the deck after shuffling them.
	/// </summary>
	/// <param name="newDeck"></param>
	public void SetNewDeck(List<SO_CardData> newDeck) {
		Debug.Log("New deck of cards added");
		cards = new Queue<SO_CardData>(ShuffleDeck(newDeck));
	}

	/// <summary>
	/// Adds the listed cards to the deck before shuffling the whole deck.
	/// </summary>
	/// <param name="additionalCards"></param>
	public void AddToDeck(List<SO_CardData> additionalCards) {

		foreach (SO_CardData card in additionalCards) cards.Enqueue(card);

		cards = new Queue<SO_CardData>(ShuffleDeck(cards.ToList()));
	}

	/// <summary>
	/// Shuffles the current queue of cards in the deck.
	/// </summary>
	public void ShuffleDeck() {
		if (!GetCardAmount(out _)) return;

		cards = new Queue<SO_CardData>(ShuffleDeck(cards.ToList()));
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

	/// <summary>
	/// If it can find any CardDatas in the queue it returns "true" and a cardScript with that data that has then been dequeued from the list.
	/// Otherwise it returns a null object and "false".
	/// </summary>
	/// <param name="cardScript"></param>
	/// <returns></returns>
	public bool GetTopCard(out CardScript cardScript) {

		if (cards.TryPeek(out SO_CardData result)) {
			if(result is SO_OutpostCardData) {
				cardScript = new OutpostCardScript(cards.Dequeue());
				return true;
			} else if (result is SO_SurfaceCardData) {
				cardScript = new SurfaceCardScript(cards.Dequeue());
				return true;
			} else {
				cardScript = null;
				return false;
			}
		}
		else {
			cardScript = null;
			return false;
		}
	}

	/// <summary>
	/// If it can find any SO_OutpostCards in the queue it returns "true" and the string of the top one. Does not dequeue. Otherwise an empty string and "false".
	/// </summary>
	/// <param name="cardName"></param>
	/// <returns></returns>
	public bool GetTopCardName(out string cardName) {

		if (cards.TryPeek(out SO_CardData result)) {
			cardName = result.CardName;
			return true;
		}
		else {
			Debug.Log("Could not find any card!");
			cardName = string.Empty;
			return false;
		}
	}

	/// <summary>
	/// Reverses, Enqueues and Reverses the queue again so that the received card is on the top of the queue.
	/// </summary>
	/// <param name="cardScript"></param>
	public void PutOnTop(CardScript cardScript) {

		cards = new Queue<SO_CardData>(cards.Reverse());
		
		//cards.Enqueue(cardScript.CardData);
		cards = new Queue<SO_CardData>(cards.Reverse());
	}
}
