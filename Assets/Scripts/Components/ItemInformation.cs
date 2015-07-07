using UnityEngine;
using System.Collections;

public class ItemInformation : MonoBehaviour {

	public static ItemInformation itemClicked = null;

	[SerializeField]
	private GameObject inventory;

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