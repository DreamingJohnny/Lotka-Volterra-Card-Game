using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[SerializeField] private OutpostCard testCard;
	[SerializeField] private SO_OutpostCard test_SO_OutpostCard;

	void Start() {
		testCard.SetSO(test_SO_OutpostCard);

	}

	void Update() {

	}
}
