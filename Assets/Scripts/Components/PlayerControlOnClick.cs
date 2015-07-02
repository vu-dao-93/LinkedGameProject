using UnityEngine;
using System.Collections;

public class PlayerControlOnClick : MonoBehaviour {
	
	//public GameObject inventory;
	public float moveSpeed;
	[HideInInspector]
	public Vector3 mousePosition;
	[SerializeField]
	GameObject topPlayer;
	[SerializeField]
	GameObject botPlayer;
	GameObject selectedPlayer;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if ((Input.mousePosition.y - Screen.height/2) > 0)
			{
				selectedPlayer = topPlayer;
				StopCoroutine("MovePlayer");
				StartCoroutine("MovePlayer", mousePosition);
			}
			else
			{
				selectedPlayer = botPlayer;
				StopCoroutine("MovePlayer");
				StartCoroutine("MovePlayer", mousePosition);
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