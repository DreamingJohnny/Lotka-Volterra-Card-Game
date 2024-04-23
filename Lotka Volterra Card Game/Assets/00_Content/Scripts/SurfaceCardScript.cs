using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class SurfaceCardScript : CardScript {

	public override SO_CardData CardData => m_SO_SurfaceCardData;

	private SO_SurfaceCardData m_SO_SurfaceCardData;

	public SurfaceCardScript(SO_CardData cardData) : base(cardData) {
		m_SO_SurfaceCardData = cardData as SO_SurfaceCardData;
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
		if (m_SO_SurfaceCardData == null || m_SO_SurfaceCardData.ScavengingValue < 0) {
			scavengingValue = -1;
			return false;
		}
		else {
			scavengingValue = GetModifiedValue(m_SO_SurfaceCardData.ScavengingValue, scavengingValueAddition, scavengingValueMultiplier);
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
		if (m_SO_SurfaceCardData == null || m_SO_SurfaceCardData.ThreatLevel < 0) {
			threatLevel = -1;
			return false;
		}
		else {
			threatLevel = GetModifiedValue(m_SO_SurfaceCardData.ThreatLevel, threatLevelAddition, threatLevelMultiplier);
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
		if (m_SO_SurfaceCardData == null || m_SO_SurfaceCardData.AlertnessValue < 0) {
			alertnessValue = -1;
			return false;
		}
		else {
			alertnessValue = GetModifiedValue(m_SO_SurfaceCardData.AlertnessValue, alertnessValueAddition, alertnessValueMultiplier);
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
		if (m_SO_SurfaceCardData == null || m_SO_SurfaceCardData.ToughnessValue < 0) {
			toughnessValue = -1;
			return false;
		}
		else {
			toughnessValue = GetModifiedValue(m_SO_SurfaceCardData.ToughnessValue, toughnessValueAddition, toughnessValueMultiplier);
			return true;
		}
	}
	#endregion
}