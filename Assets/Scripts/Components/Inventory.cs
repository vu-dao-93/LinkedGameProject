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
			slots[i].GetComponent<Image>().sprite = null;
		}
	}

	public void AddToInventory (string itemName)
	{
		Sprite itemIcon = null;

		for (int i = 0; i < ItemDatabase.instance.itemList.Count; i++)
		{
			if (ItemDatabase.instance.itemList[i].itemName == itemName)
			{
				itemIcon = ItemDatabase.instance.itemList[i].itemIcon;
			}
		}

		for (int i = 0; i < slots.Count; i++)
		{
			if (slots[i].GetComponent<Image>().sprite == null)
			{
				slots[i].GetComponent<Image>().sprite = itemIcon;
				break;
			}
		}
	}

	/*
	void OnMouseUp()
	{
		PlayerControlOnClick.uiClicked = false;
	}
	*/
}