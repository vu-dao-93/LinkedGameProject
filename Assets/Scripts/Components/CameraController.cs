using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	[SerializeField]
	BoxCollider2D selectedBackgroundCol;
	[SerializeField]
	GameObject followedPlayer;

	float minX;
	float maxX;

	void Awake()
	{
		minX = selectedBackgroundCol.bounds.min.x + gameObject.GetComponent<Camera> ().orthographicSize / 2;
		maxX = selectedBackgroundCol.bounds.max.x - gameObject.GetComponent<Camera> ().orthographicSize / 2;
	}

	void Update()
	{
		//Follow the player
		gameObject.transform.position = new Vector3 (followedPlayer.transform.position.x, transform.position.y, transform.position.z);
		//gameObject.transform.position = new Vector3 (Mathf.Clamp(gameObject.transform.position.x, minX, maxX), gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
