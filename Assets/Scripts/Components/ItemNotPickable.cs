using UnityEngine;
using System.Collections;

public class ItemNotPickable : MonoBehaviour{
	public string itemName;
	public Sprite itemUsed;
	public string itemDescription;

	public static ItemNotPickable itemClicked = null;
	[SerializeField]
	GameObject selectedItemIcon;

	void OnMouseOver()
	{
		GameManager.GMInstance.mainText.text = itemDescription;
	}

	void OnMouseExit()
	{
		GameManager.GMInstance.mainText.text = null;
	}

	void OnMouseDown()
	{
		itemClicked = this;
	}

	void OnTriggerStay2D()
	{
		if (itemClicked == this)
		{
			for (int i = 0; i < ItemDatabase.IDInstance.itemList.Count; i++)
			{
				if (selectedItemIcon.name == ItemDatabase.IDInstance.itemList[i].itemName)
				{
					for (int x = 0; x < ItemDatabase.IDInstance.itemList[i].useableItem.Length; x++)
					{
						if (gameObject.name == ItemDatabase.IDInstance.itemList[i].useableItem[x])
						{
							GetComponent<SpriteRenderer>().sprite = itemUsed;
							break;
						}
					}
				}
			}
			selectedItemIcon.GetComponent<SpriteRenderer> ().sprite = null;
		}
	}
}
