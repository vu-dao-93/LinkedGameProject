using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slots : MonoBehaviour {
	
	bool isClicked;
	public GameObject selectedItemIcon;

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
		selectedItemIcon.transform.position = new Vector3 (mousePosition.x, mousePosition.y, 0f);
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
	/*
	public void ChangeColor()
	{
		GetComponent<Image> ().color = Color.gray;
	}
	*/
}