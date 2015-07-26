using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerControlOnClick : MonoBehaviour {
	public static PlayerControlOnClick PCInstance;

	//public GameObject inventory;
	public float moveSpeed;

	[HideInInspector]
	public Vector3 mousePosition;

	[SerializeField]
	GameObject topPlayer;

	[SerializeField]
	GameObject botPlayer;

	[HideInInspector]
	public GameObject selectedPlayer;

	void Awake()
	{
		PCInstance = this;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				// Choose player and move
				if ((Input.mousePosition.y - Screen.height/2) > 0)
				{
					selectedPlayer = topPlayer;
				}
				else
				{
					selectedPlayer = botPlayer;
				}
				StopCoroutine("MovePlayer");
				StartCoroutine("MovePlayer", mousePosition);

				RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
				// Cancel previous item click
				if (hit.transform.gameObject.GetComponent<ItemInformation> () == null) {
					ItemInformation.itemClicked = null;
				}
				if (hit.transform.gameObject.GetComponent<ItemNotPickable> () == null) {
					ItemNotPickable.itemClicked = null;
				}
			}
		}
	}

	IEnumerator MovePlayer (Vector3 endPosition)
	{
		Vector3 targetPosition = new Vector3 (endPosition.x, selectedPlayer.transform.position.y, selectedPlayer.transform.position.z);
		while (Vector3.Distance(selectedPlayer.transform.position, targetPosition) > 0.05f)
		{
			selectedPlayer.transform.position = Vector3.MoveTowards(selectedPlayer.transform.position, targetPosition, Time.deltaTime * moveSpeed);
			yield return null;
		}
	}	
}