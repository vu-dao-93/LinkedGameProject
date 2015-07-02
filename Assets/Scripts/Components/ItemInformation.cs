using UnityEngine;
using System.Collections;

public class ItemInformation : MonoBehaviour {
	public string itemName;
	public Sprite itemIcon;
	public string itemDescription;

	bool isClicked = false;

	[SerializeField]
	private GameObject inventory;

	void OnMouseDown()
	{
		isClicked = true;
	}

	void OnTriggerStay2D()
	{
		if (isClicked == true)
		{
			isClicked = false;
			inventory.GetComponent<Inventory>().AddToInventory(itemName, itemIcon);
			Destroy(gameObject);
		}
	}
}
