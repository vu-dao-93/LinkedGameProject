using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slots : MonoBehaviour {

	[SerializeField]
	Text text;
	bool isClicked;
	public GameObject selectedItemIcon;

	void Update ()
	{
		if (isClicked)
		{
			TakeItem();
			ShowDescription();
		}
	}

	void TakeItem ()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		selectedItemIcon.transform.position = new Vector3 (mousePosition.x + 0.4f, mousePosition.y - 0.4f, 0f);
	}

	public void ChangeSprite ()
	{
		selectedItemIcon.GetComponent<SpriteRenderer> ().sprite = gameObject.GetComponent<Image> ().sprite;
		selectedItemIcon.name = gameObject.GetComponent<Image> ().sprite.name;
	}

	public void ItemClicked()
	{
		isClicked = true;
	}

	public void ShowDescription()
	{
		for (int i = 0; i < ItemDatabase.instance.itemList.Count; i++)
		{
			if (selectedItemIcon.GetComponent<SpriteRenderer> ().sprite != null)
			{
				if (selectedItemIcon.GetComponent<SpriteRenderer> ().sprite.name == ItemDatabase.instance.itemList[i].itemName)
				{
					text.text = ItemDatabase.instance.itemList[i].itemDescription;
				}
			}
			else
			{
				text.text = null;
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