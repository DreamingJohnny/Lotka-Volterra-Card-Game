using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTester : MonoBehaviour {

	[SerializeField] private CardPool cardPool;

	[SerializeField] private List<SO_CardData> cardDatas;

	private CardObject cardUnit;
	private CardObject cardToEquip;
	private CardObject cardToAlsoEquip;

	private int index = 0;

	void Start() {

	}

	void Update() {

		//Next step now is to, get this to work with cards from a card pool.
		//Then, get it to work with three cards, one card equipping another card, and then being equipped by a third card, and moving correctly.
		//Then, get it to work with unequipping cards.
		//Then, get it to work with cards being moved while equipped, and see if that causes any issues.
		//Then, make sure they update the values correctly when equipped. This needs to handle both traits, values and multiplied values.
		//Then make sure that the values work correctly with multiple cards being equipped to one card.
		//Then, make sure that they update the values correctly when unequipped.
		//Then, get it to work with cards being destroyed while equipped, and see if that causes any issues.
		//Then, overload in children to make sure that only suitable cards can be equipped, based on their own cardtype, or type of card attached.
		//Then, ensure the same behavior can then be used with Enemy cards as well, in attacks.


		if (Input.GetKeyDown(KeyCode.Space)) {
			if(index == 0) {
				cardUnit = cardPool.GetCardObject(cardDatas[index]);
				cardUnit.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
				Debug.Log(cardUnit.CardScript.GetCardName);
				index++;
				cardToEquip = cardPool.GetCardObject(cardDatas[index]);
				cardToEquip.transform.SetPositionAndRotation(new Vector3(8, 0, 0), Quaternion.identity);
				Debug.Log(cardToEquip.CardScript.GetCardName);
				index++;
				cardToAlsoEquip = cardPool.GetCardObject(cardDatas[index]);
				cardToAlsoEquip.transform.SetPositionAndRotation(new Vector3(16, 0, 0), Quaternion.identity);
				Debug.Log(cardToAlsoEquip.CardScript.GetCardName);
				index++;
			} else if(index == 3) {
				cardUnit.GetComponent<CardSlotter>().TryAttachCard(cardToEquip);
				cardUnit.GetComponent<CardSlotter>().TryAttachCard(cardToAlsoEquip);
				index++;
			} else if(index == 4) {
				cardUnit.transform.SetPositionAndRotation(new Vector3(0, 5, 0), Quaternion.identity);
				Debug.Log("Cards were moved.");
				index++;
			} else if(index == 5){

				//Here we will want to test if the values are updating correctly.
				index++;
			} else if (index == 6) {
				index++;
			} else if (index == 7) {
				cardUnit.GetComponent<CardSlotter>().TryDetachCard(cardToAlsoEquip);
				cardToAlsoEquip.transform.SetPositionAndRotation(new Vector3(0, -8, 0), Quaternion.identity);
				index++;
			}
			
		}

	}
}