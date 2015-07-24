using UnityEngine;
using System.Collections;

public class ItemInformation : MonoBehaviour {

	public static ItemInformation itemClicked = null;

	[SerializeField]
	private GameObject inventory;

	void OnMouseOver()
	{
		GameManager.GMInstance.itemOver = true;
		for (int i = 0; i < ItemDatabase.IDInstance.itemList.Count; i++)
		{
			if (ItemDatabase.IDInstance.itemList[i].itemName == gameObject.name)
			{
				GameManager.GMInstance.description = ItemDatabase.IDInstance.itemList[i].itemDescription;
			}
		}
	}

	void OnMouseExit()
	{
		GameManager.GMInstance.itemOver = false;
		GameManager.GMInstance.description = null;
	}

	void OnMouseDown()
	{
		itemClicked = this;
	}

	void OnTriggerStay2D()
	{
		if (itemClicked == this)
		{
			inventory.GetComponent<Inventory>().AddToInventory(gameObject.name);
			Destroy(gameObject);
		}
	}
}