using UnityEngine;
using System.Collections;

public class ItemInformation : MonoBehaviour {

	public static ItemInformation itemClicked = null;

	[SerializeField]
	private GameObject inventory;

	void OnMouseOver()
	{
		for (int i = 0; i < ItemDatabase.IDInstance.itemList.Count; i++)
		{
			if (ItemDatabase.IDInstance.itemList[i].itemName == gameObject.name)
			{
				GameManager.GMInstance.mainText.text = ItemDatabase.IDInstance.itemList[i].itemDescription;
			}
		}
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
			inventory.GetComponent<Inventory>().AddToInventory(gameObject.name);
			Destroy(gameObject);
		}
	}
}