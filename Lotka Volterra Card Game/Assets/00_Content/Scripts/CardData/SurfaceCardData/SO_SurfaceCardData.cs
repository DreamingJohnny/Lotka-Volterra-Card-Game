using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SurfaceCard", menuName = "ScriptableObjects/SO_SurfaceCard")]
public sealed class SO_SurfaceCardData : SO_CardData {

	[SerializeField] private int scavengingValue;

	[SerializeField] private int threatLevel;

	[SerializeField] private int alertnessValue;

	[SerializeField] private int toughnessValue;

	public int ScavengingValue { get { return scavengingValue; } }
	public int ThreatLevel { get { return threatLevel; } }
	public int AlertnessValue { get {  return alertnessValue; } }
	public int ToughnessValue { get { return toughnessValue; } }
}
