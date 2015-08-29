using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemNotPickable : MonoBehaviour{
	public string itemName;
	public Sprite itemUsed;
	public string itemDescription;

	public static ItemNotPickable itemClicked = null;

	void OnMouseOver()
	{
		GameManager.GMInstance.itemOver = true;
		GameManager.GMInstance.description = itemDescription;
	}

	void OnMouseExit()
	{
		GameManager.GMInstance.itemOver = false;
		GameManager.GMInstance.description = null;
	}

	void OnMouseDown()
	{
		if (GameManager.GMInstance.selectedItemIcon.GetComponent<SpriteRenderer>().sprite != null)
			itemClicked = this;
	}

	void OnTriggerStay2D()
	{
		if (itemClicked == this)
		{
			for (int i = 0; i < ItemDatabase.IDInstance.itemList.Count; i++)
			{
				if (GameManager.GMInstance.selectedItemIcon.name == ItemDatabase.IDInstance.itemList[i].itemName)
				{
					for (int x = 0; x < ItemDatabase.IDInstance.itemList[i].useableItem.Length; x++)
					{
						if (gameObject.name == ItemDatabase.IDInstance.itemList[i].useableItem[x])
						{
							GetComponent<SpriteRenderer>().sprite = itemUsed;
							GameManager.GMInstance.selectedSlot.GetComponent<Image>().sprite = null;
							break;
						}
					}
				}
			}
			itemClicked = null;
			GameManager.GMInstance.selectedItemIcon.GetComponent<SpriteRenderer> ().sprite = null;
		}
	}
}
