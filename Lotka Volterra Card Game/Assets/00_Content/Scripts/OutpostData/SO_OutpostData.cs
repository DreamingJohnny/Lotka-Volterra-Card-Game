using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OutpostData", menuName = "ScriptableObjects/SO_OutpostData")]
public class SO_OutpostData : ScriptableObject {

	[SerializeField] private int costPerLevel;
	[SerializeField] private int upkeepPerLevel;
	[SerializeField] private int developmentSlotsPerLevel;
	[SerializeField] private int recouperationPerLevel;

	public int CostPerLevel { get { return costPerLevel; } }
	public int UpkeepPerLevel { get { return upkeepPerLevel; } }
	public int DevelopmentSlotsPerLevel { get {return developmentSlotsPerLevel; } }
	public int RecouperationPerLevel { get { return recouperationPerLevel; } }
}
