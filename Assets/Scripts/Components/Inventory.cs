using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<GameObject> slots = new List<GameObject>();

	void Start ()
	{
		// Clear out all the sprite
		for (int i = 0; i < slots.Count; i++)
		{
			slots[i].GetComponent<RawImage>().texture = null;
		}
	}

	public void AddToInventory (Collider2D item)
	{
		for (int i = 0; i < slots.Count; i++)
		{
			if (slots[i].GetComponent<RawImage>().texture == null)
			{
				slots[i].GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Item Icons/" + item.name + " Icon");
				break;
			}
		}
	}
}
