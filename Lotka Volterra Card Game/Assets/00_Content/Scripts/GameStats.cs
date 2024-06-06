using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats {

	public static event Action<int> OnTurnCounterChanged;
	public static event Action<TurnSegment> OnTurnSegmentChanged;
	public static event Action<int> OnThreatLevelChanged;
	public static event Action<int> OnSporeCountChanged;

	#region"Turn"
	private static int turn;
	public static int Turn {
		get { return turn; }
		private set {
			turn = value;
			OnTurnCounterChanged?.Invoke(Turn);
		}
	}
	#endregion

	#region"TurnSegment"
	private static TurnSegment turnSegment;
	public static TurnSegment TurnSegment {
		get => turnSegment;
		private set {
			if(turnSegment == value) return;
			turnSegment = value;
			OnTurnSegmentChanged?.Invoke(TurnSegment);
		}
	}

	public static void IncreaseTurnSegment() {
		if (TurnSegment == TurnSegment.Upkeep) TurnSegment = TurnSegment.Initiative;
		else TurnSegment++;
		Debug.Log("Does the turn go up?");
		//Like here, is there a reason why this shouldn't be placed inside the private setter above instead?
		//OnTurnSegmentChanged?.Invoke(TurnSegment);
	}

	public static void SetTurnSegmentTo(TurnSegment _turnSegment) {
		TurnSegment = _turnSegment;
		//And here?
		//OnTurnSegmentChanged?.Invoke(TurnSegment);
	}
	#endregion

	#region"ThreatLevel"
	private static int threatLevel;
	public static int ThreatLevel {
		get {
			return threatLevel;
		}
		private set {
			threatLevel = value;
			if (threatLevel < 1) threatLevel = 1;
			OnThreatLevelChanged?.Invoke(ThreatLevel);
		}
	}
	#endregion

	#region"SporeCount"
	private static int sporeCount;
	public static int SporeCount {
		get { return sporeCount; }
		private set {
			sporeCount = value; if (sporeCount < 0) sporeCount = 0;
			OnSporeCountChanged?.Invoke(SporeCount);
		}
	}

	public static void IncreaseSporeCount(int amount) {
		
		const int sporePerThreatLevel = 10;

		if (amount <= 0) return;

		sporeCount += amount;

		ThreatLevel += sporeCount / sporePerThreatLevel;

		sporeCount %= sporePerThreatLevel;
		
		OnSporeCountChanged?.Invoke(SporeCount);
	}
	#endregion

	public static void InitGame() {
		Turn = 1;
		TurnSegment = TurnSegment.Initiative;
		ThreatLevel = 1;
		SporeCount = 0;
	}

	public static void HandleOnCardUnintervened() {
		//This is mostly as a reminder to myself, that I think I'll want to handle a lot of events like this.
		//Pretty sure that for this to work I'll need to add more "using" maybe?
		//Basically this should have SporeCount increase by one...
	}
}