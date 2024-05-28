using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour {
	/*
	 * So, this will need to handle all the various parts that needs to get their values updated, so, should it then get called whenever those are updated?
	 * Yeah, so there is a bunch of functions here that listens then?
	 */
	public event Action OnNextButtonPressed;
	

	[Header("Turn")]
	[SerializeField] private TextMeshProUGUI turnCounter;
	[SerializeField] private TextMeshProUGUI turnSegment;

	[Header("Outpost")]
	[SerializeField] private TextMeshProUGUI outpostLevel;
	[SerializeField] private TextMeshProUGUI upkeep;
	[SerializeField] private TextMeshProUGUI resources;

	[Header("Surface")]
	[SerializeField] private TextMeshProUGUI threatLevel;
	[SerializeField] private TextMeshProUGUI sporeCounter;

	private void OnEnable() {
		GameStats.OnTurnCounterChanged += HandleOnTurnChanged;
		GameStats.OnTurnSegmentChanged += HandleOnTurnSequenceChanged;
		GameStats.OnThreatLevelChanged += HandleOnThreatLevelChanged;
		GameStats.OnSporeCountChanged += HandleOnSporeCountChanged;

		Outpost.OnLevelChanged += HandleOnOutpostLevelChanged;
		Outpost.OnUpkeepChanged += HandleOnUpkeepChanged;
		Outpost.OnResourcesChanged += HandleOnResourcesChanged;
		Outpost.OnDevelopmentChanged += HandleOnDevelopmentChanged;
	}

	private void OnDisable() {
		GameStats.OnTurnCounterChanged -= HandleOnTurnChanged;
		GameStats.OnTurnSegmentChanged -= HandleOnTurnSequenceChanged;
		GameStats.OnThreatLevelChanged -= HandleOnThreatLevelChanged;
		GameStats.OnSporeCountChanged -= HandleOnSporeCountChanged;

		Outpost.OnLevelChanged -= HandleOnOutpostLevelChanged;
		Outpost.OnUpkeepChanged -= HandleOnUpkeepChanged;
		Outpost.OnResourcesChanged -= HandleOnResourcesChanged;
		Outpost.OnDevelopmentChanged -= HandleOnDevelopmentChanged;
	}

	private void HandleOnTurnChanged(int turn) { 
	turnCounter.text = turn.ToString();
	}

	private void HandleOnTurnSequenceChanged(TurnSegment _turnSegment) { 
		turnSegment.text = _turnSegment.ToString();
	}

	private void HandleOnSporeCountChanged(int count) { 
	sporeCounter.text = count.ToString();
	}

	private void HandleOnThreatLevelChanged(int level) {
	threatLevel.text = level.ToString();
	}
	private void HandleOnOutpostLevelChanged(int level) { 
	outpostLevel.text = level.ToString();
	}
	private void HandleOnUpkeepChanged(int _upkeep) {
	upkeep.text = _upkeep.ToString();
	}

	private void HandleOnResourcesChanged(int _resources) {
	resources.text = _resources.ToString();
	}
	private void HandleOnDevelopmentChanged(int obj) {
		Debug.Log("There isn't yet a way for the UI handler to display the amount of development the Outpost has");
	}

	public void NextButtonPressed() {

		OnNextButtonPressed?.Invoke();
	}
}
