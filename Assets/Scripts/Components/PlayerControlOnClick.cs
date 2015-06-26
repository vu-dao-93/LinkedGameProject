using UnityEngine;
using System.Collections;

public class PlayerControlOnClick : MonoBehaviour {

	public GameObject inventory;
	bool isMoving = false;
	public float moveSpeed;
	[HideInInspector]
	public Vector3 mousePosition;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			StopCoroutine("MovePlayer");
			StartCoroutine("MovePlayer", mousePosition);
		}
	}

	IEnumerator MovePlayer (Vector3 endPosition)
	{
		Vector3 targetPosition = new Vector3 (endPosition.x, gameObject.transform.position.y, gameObject.transform.position.z);
		//while (isMoving == false)
		//{
			while (Vector3.Distance(gameObject.transform.position, targetPosition) > 0.05f)
			{
				isMoving = true;
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, Time.deltaTime * moveSpeed);
				yield return null;
			}
		//}
		isMoving = false;
	}

	void OnTriggerEnter2D (Collider2D item)
	{
		inventory.GetComponent<Inventory> ().AddToInventory (item);
		Destroy (item.gameObject);
	}
}
