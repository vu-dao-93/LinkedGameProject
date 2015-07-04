using UnityEngine;
using System.Collections;

public class ItemNotPickable : MonoBehaviour{
	public string itemName;
	public Sprite itemUsed;
	public string itemDescription;

	bool isClicked = false;
	[SerializeField]
	GameObject selectedItemIcon;

	void OnMouseDown()
	{
		isClicked = true;
	}

	void OnTriggerStay2D()
	{
		if (isClicked)
		{
			for (int i = 0; i < ItemDatabase.instance.itemList.Count; i++)
			{
				if (selectedItemIcon.name == ItemDatabase.instance.itemList[i].itemName)
				{
					for (int x = 0; x < ItemDatabase.instance.itemList[i].useableItem.Length; x++)
					{
						if (gameObject.name == ItemDatabase.instance.itemList[i].useableItem[x])
						{
							GetComponent<SpriteRenderer>().sprite = itemUsed;
						}
					}
				}
			}
		}
	}
}
