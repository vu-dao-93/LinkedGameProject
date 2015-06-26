using UnityEngine;
using System.Collections;

public class TopPlayerControlOnClick : MonoBehaviour {

	public float moveSpeed;
	[HideInInspector]
	public Vector3 mousePosition;
	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			StartCoroutine(MovePlayer(mousePosition));
		}
	}

	IEnumerator MovePlayer (Vector3 endPosition)
	{
		Vector3 targetPosition = new Vector3 (endPosition.x, player.transform.position.y, player.transform.position.z);
		while (Vector3.Distance(player.transform.position, targetPosition) > 0.05f)
		{
			player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, Time.deltaTime * moveSpeed);
			yield return null;
		}
	}
}
