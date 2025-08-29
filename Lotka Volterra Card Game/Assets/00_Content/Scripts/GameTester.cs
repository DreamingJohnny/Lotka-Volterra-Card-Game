using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTester : MonoBehaviour {

	[SerializeField] private CardPool cardPool;

	[SerializeField] private List<SO_CardData> cardDatas;

	[SerializeField] private CardObject cardObject;
	[SerializeField] private CardObject cardToEquip;
	[SerializeField] private CardObject cardToEquipCardWithEquipment;

	private int index = 0;

	void Start() {

	}

	void Update() {

		//Next step now is to, get this to work with cards from a card pool.
		//Then, get it to work with three cards, one card equipping another card, and then being equipped by a third card, and moving correctly.
		//Then, get it to work with unequipping cards.
		//Then, get it to work with cards being moved while equipped, and see if that causes any issues.
		//Then, make sure they update the values correctly when equipped. This needs to handle both traits, values and multiplied values.
		//Then make sure that can work with multiple cards being equipped to one card.
		//Then, make sure that they update the values correctly when unequipped.
		//Then, get it to work with cards being destroyed while equipped, and see if that causes any issues.
		//Then, overload in children to make sure that only suitable cards can be equipped, based on their own cardtype, or type of card attached.
		//Then, ensure the same behavior can then be used with Enemy cards as well, in attacks.


		if (Input.GetKeyDown(KeyCode.Space)) {
			if(index == 0) {
				cardObject = cardPool.GetCardObject(cardDatas[index]);
				cardObject.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
				Debug.Log(cardObject.CardScript.GetCardName);
				index++;
			} else if(index == 1) {
				cardToEquip = cardPool.GetCardObject(cardDatas[index]);
				cardToEquip.transform.SetPositionAndRotation(new Vector3(8, 0, 0), Quaternion.identity);
				Debug.Log(cardToEquip.CardScript.GetCardName);
				index++;
			} else if(index == 2) {
				cardToEquipCardWithEquipment = cardPool.GetCardObject(cardDatas[index]);
				cardToEquipCardWithEquipment.transform.SetPositionAndRotation(new Vector3(16, 0, 0), Quaternion.identity);
				Debug.Log(cardToEquipCardWithEquipment.CardScript.GetCardName);
				index++;
			} else if(index == 3){
				cardObject.TryAttachCard(cardToEquip);
				index++;
			} else if (index == 4) {
				cardToEquipCardWithEquipment.TryAttachCard(cardObject);
				index++;
			} else if (index == 5) {
				cardToEquipCardWithEquipment.TryDetachCard(out CardObject unAttachedCard);
				unAttachedCard.transform.SetPositionAndRotation(new Vector3(0, -5, 0), Quaternion.identity);
				index++;
			}
			
		}

	}
}