using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Slots : MonoBehaviour {
	
	bool isClicked;

	void Update ()
	{
		if (isClicked)
		{
			TakeItem();
		}
	}

	//selectedItemIcon follow mouse
	void TakeItem ()
	{
		Vector3 mousePosition;
		if ((Input.mousePosition.y - Screen.height/2) > 0)
		{
			mousePosition = PlayerControlOnClick.PCInstance.camList[0].ScreenToWorldPoint(Input.mousePosition);
		}
		else
		{
			mousePosition = PlayerControlOnClick.PCInstance.camList[1].ScreenToWorldPoint(Input.mousePosition);
		}
		GameManager.GMInstance.selectedItemIcon.transform.position = new Vector3 (mousePosition.x + 0.4f, mousePosition.y - 0.4f, 0f);
	}

	//Change the sprite on selectedItemIcon that show the item clicked
	public void ChangeSprite ()
	{
		GameManager.GMInstance.selectedItemIcon.GetComponent<SpriteRenderer> ().sprite = gameObject.GetComponent<Image> ().sprite;
		GameManager.GMInstance.selectedItemIcon.name = gameObject.GetComponent<Image> ().sprite.name;
	}

	//Set isClicked = true
	public void ItemClicked()
	{
		isClicked = true;
	}

	//Make this slot the selectedSlot
	public void SelectedSlot()
	{
		GameManager.GMInstance.selectedSlot = gameObject;
	}
}