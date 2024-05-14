using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	private List<GameObject> objectPool = new();
	
	[SerializeField] private GameObject objectToPool;

	public int ObjectPoolAmount {  get { return objectPool.Count; } }

	private void Awake() {
		objectPool.Clear();
	}

	public void AddToPool(GameObject objectToPool) {
		//So, here we might want to add the stuff that resets values and stuff?
		//Or maybe that stuff that reactivates it?

		objectPool.Add(objectToPool);
		Debug.Log($"The objectpool now contains {objectPool.Count}");
	}

	public GameObject GetObject() {
		if(objectPool.Count > 0) {
			return objectPool.First();
		} else {
			return Instantiate(objectToPool);
		}
	}

	/*
	 * So, we need a function that recieves a gameObject.
	 * tells it to deactivate maybe?
	 * adds it to the list then.
	 */

	/*
	 * Then we want a function that returns a card, if there is one in the list it should return that one,
	 * otherwise it should create one and return that one.
	 */

}
