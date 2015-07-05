using UnityEngine;
using System.Collections;

public class ItemInformation : MonoBehaviour {

	[SerializeField]
	private GameObject inventory;

	void OnMouseDown()
	{
		PlayerControlOnClick.itemClicked = this;
	}

	void OnTriggerStay2D()
	{
		if (PlayerControlOnClick.itemClicked == this)
		{
			inventory.GetComponent<Inventory>().AddToInventory(gameObject.name);
			Destroy(gameObject);
		}
	}
}