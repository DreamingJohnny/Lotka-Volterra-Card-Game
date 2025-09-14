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

		//Then, get it to work with cards being destroyed while equipped, and see if that causes any issues.
		//Add so that CardSlotter checks type of own card, and of card being asked to slot, and rejects.
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
				cardUnit.GetComponent<CardSlotter>().TryDetachCard(cardToAlsoEquip);
				cardToAlsoEquip.transform.SetPositionAndRotation(new Vector3(0, -8, 0), Quaternion.identity);
				index++;
			} else if (index == 6) {
				index++;
			} else if (index == 7) {
			}
			
		}

	}
}