using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outpost {

	private SO_OutpostData sO_OutpostData;
	public void SetOutpostData(SO_OutpostData outpostData) { sO_OutpostData = outpostData; }
	public bool HasOutpostData() { if (sO_OutpostData == null) return false; return true; }

	#region"Level"
	private int level;

	public int Level {
		get {
			return level;
		}
		set {
			if (value < 1) value = 1; level = value;
		}
	}
	#endregion

	#region"Upkeep"
	public bool GetUpkeep(out int upkeep) {
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
	private int resources;

	public int Resources {
		get {
			return resources;
		}
		set {
			resources = value;
			if (resources < 0) resources = 0;
		}
	}

	public bool PayResources(int cost) {
		if (cost > 0 && cost < Resources) {
			Resources -= cost;
			return true;
		}
		else { return false; }
	}
	#endregion

	#region"Development"   
	private int development;

	public int Development {
		get {
			return development;
		}
		set {
			development = value;
			if (development < 0) development = 0;

			if (sO_OutpostData == null) {
				Debug.Log($"{this} lacks an sO_OutpostData, and so cannot judge if the outpostlevel should increase.");
				return;
			}

			while (development >= sO_OutpostData.CostPerLevel * Level) {
				development -= sO_OutpostData.CostPerLevel * Level;
				Level++;
			}
		}
	}
	#endregion

	
}
