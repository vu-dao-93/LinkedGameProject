using UnityEngine;
using System.Collections;

public class ItemInformation : MonoBehaviour {

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
			inventory.GetComponent<Inventory>().AddToInventory(gameObject.name);
			Destroy(gameObject);
		}
	}
}