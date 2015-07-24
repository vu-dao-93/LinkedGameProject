using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager GMInstance;

	public GameObject selectedItemIcon;
	public Text mainText;
	public string description;
	public bool itemOver;

	void Awake()
	{
		GMInstance = this;
	}

	void Update()
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
