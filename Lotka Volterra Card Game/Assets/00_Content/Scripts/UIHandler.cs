using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
	/*
	 * So, this will need to handle all the various parts that needs to get their values updated, so, should it then get called whenever those are updated?
	 * Yeah, so there is a bunch of functions here that listens then?
	 */
	public event Action OnNextButtonPressed;
	public event Action<bool> OnDayNightToggled;

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

	[Header("Day & Night Cycle")]
	[SerializeField] private Button dayNightButton;
	private bool isDay = true;
	readonly string dayText = "day";
	readonly string nightText = "night";

	private void UpdateDayNightButton() { dayNightButton.GetComponentInChildren<TextMeshProUGUI>().text = isDay ? dayText : nightText; }

	private void OnEnable() {
		GameStats.OnTurnCounterChanged += HandleOnTurnChanged;
		GameStats.OnTurnSegmentChanged += HandleOnTurnSequenceChanged;
		GameStats.OnThreatLevelChanged += HandleOnThreatLevelChanged;
		GameStats.OnSporeCountChanged += HandleOnSporeCountChanged;
		OnDayNightToggled += GameStats.HandleOnDayNightToggled;

		Outpost.OnLevelChanged += HandleOnOutpostLevelChanged;
		Outpost.OnUpkeepChanged += HandleOnUpkeepChanged;
		Outpost.OnResourcesChanged += HandleOnResourcesChanged;
		Outpost.OnDevelopmentChanged += HandleOnDevelopmentChanged;

		ActivateDayNightToggle(false);
	}

	private void OnDisable() {
		GameStats.OnTurnCounterChanged -= HandleOnTurnChanged;
		GameStats.OnTurnSegmentChanged -= HandleOnTurnSequenceChanged;
		GameStats.OnThreatLevelChanged -= HandleOnThreatLevelChanged;
		GameStats.OnSporeCountChanged -= HandleOnSporeCountChanged;
		OnDayNightToggled -= GameStats.HandleOnDayNightToggled;

		Outpost.OnLevelChanged -= HandleOnOutpostLevelChanged;
		Outpost.OnUpkeepChanged -= HandleOnUpkeepChanged;
		Outpost.OnResourcesChanged -= HandleOnResourcesChanged;
		Outpost.OnDevelopmentChanged -= HandleOnDevelopmentChanged;
	}

	public void ActivateDayNightToggle(bool state) {
		if (state) dayNightButton.gameObject.SetActive(false);
		else {
			dayNightButton.gameObject.SetActive(true);
			if(GameStats.PlayByDay) { isDay = true; } else { isDay = false; }
			UpdateDayNightButton();
		}
	}

	public void OnDayNightButtonClicked() {
		if (isDay) isDay = false;
		else isDay = true;

		OnDayNightToggled?.Invoke(isDay);

		UpdateDayNightButton();
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
