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
	public static int Turn { get { return turn; } private set { turn = value; } }
	#endregion

	#region"TurnSegment"
	private static TurnSegment turnSegment;
	public static TurnSegment TurnSegment { get { return turnSegment; } private set { turnSegment = value; } }

	public static void IncreaseTurnSegment() {
		if (TurnSegment == TurnSegment.Upkeep) TurnSegment = TurnSegment.Initiative;
		else TurnSegment++;
		//Like here, is there a reason why this shouldn't be placed inside the private setter above instead?
		OnTurnSegmentChanged?.Invoke(TurnSegment);
	}

	public static void SetTurnSegmentTo(TurnSegment _turnSegment) {
		TurnSegment = _turnSegment;
		//And here?
		OnTurnSegmentChanged?.Invoke(TurnSegment);
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
			if (threatLevel < 0) threatLevel = 0;
			OnThreatLevelChanged?.Invoke(ThreatLevel);
		}
	}
	#endregion

	#region"SporeCount"
	private static int sporeCount;
	public static int SporeCount { get { return sporeCount; } private set { } }

	public static void IncreaseSporeCount(int amount) {
		if (amount <= 0) return;

		sporeCount += amount;
		while (sporeCount >= 10) {
			ThreatLevel++;
			sporeCount -= 10;
		}
		OnSporeCountChanged?.Invoke(SporeCount);
	}
	#endregion

	public static void HandleOnCardUnintervened() {
		//This is mostly as a reminder to myself, that I think I'll want to handle a lot of events like this.
		//Pretty sure that for this to work I'll need to add more "using" maybe?
		//Basically this should have SporeCount increase by one...
	}
}