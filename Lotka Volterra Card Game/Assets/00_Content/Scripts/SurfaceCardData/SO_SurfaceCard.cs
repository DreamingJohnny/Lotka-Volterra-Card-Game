using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SurfaceCard", menuName = "ScriptableObjects/SO_SurfaceCard")]

public class SO_SurfaceCard : SO_CardData {

	[SerializeField] private int threatLevel;

	[SerializeField] private int alertness;

	[SerializeField] private int toughness;

	public int ThreatLevel { get { return threatLevel; } }
	public int Alertness { get {  return alertness; } }
	public int Toughness { get { return toughness; } }
}
