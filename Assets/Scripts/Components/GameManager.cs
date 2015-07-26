using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager GMInstance;

	Vector3 positionBeCheck;	//A varible refer to mouse position in the world used to be checked.
	[HideInInspector]
	public GameObject selectedSlot;
	public GameObject selectedItemIcon;
	public Text mainText;
	[HideInInspector]
	public string description;
	[HideInInspector]
	public bool itemOver;

	void Awake()
	{
		GMInstance = this;
	}

	void Update()
	{
		DescriptionControl ();
		TakeMousePosition ();
		EmptySprite ();
	}

	void EmptySprite()
	{
		if (Vector3.Distance (PlayerControlOnClick.PCInstance.selectedPlayer.transform.position, positionBeCheck) < 0.05f)
			selectedItemIcon.GetComponent<SpriteRenderer> ().sprite = null;
	}

	void TakeMousePosition()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown (0))
		{
			positionBeCheck = new Vector3 (mousePosition.x, PlayerControlOnClick.PCInstance.selectedPlayer.transform.position.y, PlayerControlOnClick.PCInstance.selectedPlayer.transform.position.z);
		}
	}

	void DescriptionControl()
	{
		if (itemOver == false && selectedItemIcon.GetComponent<SpriteRenderer> ().sprite != null)
		{
			for (int i = 0; i < ItemDatabase.IDInstance.itemList.Count; i++)
			{
				if (ItemDatabase.IDInstance.itemList [i].itemName == selectedItemIcon.GetComponent<SpriteRenderer> ().sprite.name)
				{
					description = ItemDatabase.IDInstance.itemList [i].itemDescription;
					ShowDescription ();
					break;
				}
			}
		}
		else if (itemOver == false && selectedItemIcon.GetComponent<SpriteRenderer> ().sprite == null)
		{
			description = null;
			ShowDescription();
		}
		else
		{
			ShowDescription();
		}
	}

	public void ShowDescription()
	{
		mainText.text = description;
	}
}
