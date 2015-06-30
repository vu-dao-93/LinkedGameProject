using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<GameObject> slots = new List<GameObject>();

	public static Inventory instance;

	void Start ()
	{
		instance = this;
		// Clear out all the sprite
		for (int i = 0; i < slots.Count; i++)
		{
			slots[i].GetComponent<RawImage>().texture = null;
		}
	}

	public void AddToInventory (string item, Texture2D icon)
	{
		for (int i = 0; i < slots.Count; i++)
		{
			if (slots[i].GetComponent<RawImage>().texture == null)
			{
				slots[i].GetComponent<RawImage>().texture = icon;
				break;
			}
		}
	}
}
