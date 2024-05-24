using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Outpost {

	public static event Action<int> OnLevelChanged;
	public static event Action<int> OnUpkeepChanged;
	public static event Action<int> OnResourcesChanged;
	public static event Action<int> OnDevelopmentChanged;

	private static SO_OutpostData sO_OutpostData;
	public static void SetOutpostData(SO_OutpostData outpostData) { sO_OutpostData = outpostData; }
	public static bool HasOutpostData() { if (sO_OutpostData == null) return false; return true; }

	#region"Level"
	private static int level;

	public static int Level {
		get {
			return level;
		}
		set {
			if (value < 1) value = 1; level = value;
		}
	}
	#endregion

	#region"Upkeep"
	public static bool GetUpkeep(out int upkeep) {
		if (sO_OutpostData != null) {
			upkeep = Level * sO_OutpostData.UpkeepPerLevel;
			return true;
		}
		else {
			upkeep = 0;
			return false;
		}
	}
	#endregion

	#region"Resources"
	private static int resources;

	public static int Resources {
		get {
			return resources;
		}
		set {
			resources = value;
			if (resources < 0) resources = 0;
		}
	}

	public static bool PayResources(int cost) {
		if (cost > 0 && cost < Resources) {
			Resources -= cost;
			return true;
		}
		else { return false; }
	}
	#endregion

	#region"Development"   
	private static int development;

	public static int Development {
		get {
			return development;
		}
		set {
			development = value;
			if (development < 0) development = 0;

			if (sO_OutpostData == null) {
				Debug.Log($"Outpost lacks an sO_OutpostData, and so cannot judge if the outpostlevel should increase.");
				return;
			}

			while (development >= sO_OutpostData.CostPerLevel * Level) {
				development -= sO_OutpostData.CostPerLevel * Level;
				Level++;
			}
		}
	}
	#endregion

	#region"Recouperation"
	public static int RecouperationSlots {	get {	return sO_OutpostData.RecouperationPerLevel * Level; }	}
	#endregion

	#region"DevelopmentSlots"
	public static int DevelopmentSlots { get { return sO_OutpostData.DevelopmentSlotsPerLevel * Level; } }
	#endregion
}