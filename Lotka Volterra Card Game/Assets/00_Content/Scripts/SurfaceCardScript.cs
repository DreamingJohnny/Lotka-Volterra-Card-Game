using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceCardScript : CardScript {
	public SO_SurfaceCardData SurfaceCardData;

	public SurfaceCardScript(SO_CardData cardData) : base(cardData) {
		SurfaceCardData = cardData as SO_SurfaceCardData;
	}

	#region"ScavengingValue"
	private int scavengingValueAddition = 0;
	public int ScavengingValueAddition { get { return scavengingValueAddition; } set { scavengingValueAddition = value; } }

	private float scavengingValueMultiplier = 1;
	public float ScavengingValueMultiplier {
		get { return scavengingValueMultiplier; }
		set {
			scavengingValueMultiplier = value;
			if (scavengingValueMultiplier < 0) scavengingValueMultiplier = 0;
		}
	}
	public bool GetScavengingValue(out int scavengingValue) {
		if (SurfaceCardData == null || SurfaceCardData.ScavengingValue < 0) {
			scavengingValue = -1;
			return false;
		}
		else {
			scavengingValue = GetModifiedValue(SurfaceCardData.ScavengingValue, scavengingValueAddition, scavengingValueMultiplier);
			return true;
		}
	}
	#endregion

	#region"ThreatLevel"
	private int threatLevelAddition = 0;
	public int ThreatLevelAddition { get { return threatLevelAddition; } set { threatLevelAddition = value; } }

	private float threatLevelMultiplier = 1;
	public float ThreatLevelMultiplier {
		get { return threatLevelMultiplier; }
		set {
			threatLevelMultiplier = value;
			if (threatLevelMultiplier < 0) threatLevelMultiplier = 0;
		}
	}
	public bool GetThreatLevel(out int threatLevel) {
		if (SurfaceCardData == null || SurfaceCardData.ThreatLevel < 0) {
			threatLevel = -1;
			return false;
		}
		else {
			threatLevel = GetModifiedValue(SurfaceCardData.ThreatLevel, threatLevelAddition, threatLevelMultiplier);
			return true;
		}
	}
	#endregion

	#region"AlertnessValue"
	private int alertnessValueAddition = 0;
	public int AlertnessValueAddition { get { return alertnessValueAddition; } set { alertnessValueAddition = value; } }

	private float alertnessValueMultiplier = 1;
	public float AlertnessValueMultiplier {
		get { return alertnessValueMultiplier; }
		set {
			alertnessValueMultiplier = value;
			if (alertnessValueMultiplier < 0) alertnessValueMultiplier = 0;
		}
	}
	public bool GetAlertnessValue(out int alertnessValue) {
		if (SurfaceCardData == null || SurfaceCardData.AlertnessValue < 0) {
			alertnessValue = -1;
			return false;
		}
		else {
			alertnessValue = GetModifiedValue(SurfaceCardData.AlertnessValue, alertnessValueAddition, alertnessValueMultiplier);
			return true;
		}
	}
	#endregion

	#region"ToughnessValue"
	private int toughnessValueAddition = 0;
	public int ToughnessValueAddition { get { return toughnessValueAddition; } set { toughnessValueAddition = value; } }

	private float toughnessValueMultiplier = 1;
	public float ToughnessValueMultiplier {
		get { return toughnessValueMultiplier; }
		set {
			toughnessValueMultiplier = value;
			if (toughnessValueMultiplier < 0) toughnessValueMultiplier = 0;
		}
	}
	public bool GetToughnessValue(out int toughnessValue) {
		if (SurfaceCardData == null || SurfaceCardData.ToughnessValue < 0) {
			toughnessValue = -1;
			return false;
		}
		else {
			toughnessValue = GetModifiedValue(SurfaceCardData.ToughnessValue, toughnessValueAddition, toughnessValueMultiplier);
			return true;
		}
	}
	#endregion
}