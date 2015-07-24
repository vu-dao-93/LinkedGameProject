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

	void TakeItem ()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GameManager.GMInstance.selectedItemIcon.transform.position = new Vector3 (mousePosition.x + 0.4f, mousePosition.y - 0.4f, 0f);
	}

	public void ChangeSprite ()
	{
		GameManager.GMInstance.selectedItemIcon.GetComponent<SpriteRenderer> ().sprite = gameObject.GetComponent<Image> ().sprite;
		GameManager.GMInstance.selectedItemIcon.name = gameObject.GetComponent<Image> ().sprite.name;
	}

	public void ItemClicked()
	{
		isClicked = true;
	}

	public void ShowDesscription()
	{
		for (int i = 0; i < ItemDatabase.IDInstance.itemList.Count; i++)
		{
			if (ItemDatabase.IDInstance.itemList[i].itemName == GameManager.GMInstance.selectedItemIcon.name)
			{
				GameManager.GMInstance.mainText.text = ItemDatabase.IDInstance.itemList[i].itemDescription;
				break;
			}
			else
			{
				GameManager.GMInstance.mainText.text = null;
			}
		}
	}
	/*
	public void ChangeColor()
	{
		GetComponent<Image> ().color = Color.gray;
	}
	*/
}