using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public abstract class SO_CardEffect : ScriptableObject {

	public abstract void Apply(GameContext context);

}