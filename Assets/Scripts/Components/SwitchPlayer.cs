using UnityEngine;
using System.Collections;

public class SwitchPlayer : MonoBehaviour {

	public GameObject topPlayer;
	public GameObject botPlayer;

	void Start ()
	{
		topPlayer.GetComponent<PlayerControlOnClick> ().enabled = true;
		botPlayer.GetComponent<PlayerControlOnClick> ().enabled = false;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (1))
		{
			if (topPlayer.GetComponent<PlayerControlOnClick> ().enabled == true)
			{
				topPlayer.GetComponent<PlayerControlOnClick> ().enabled = false;
				botPlayer.GetComponent<PlayerControlOnClick> ().enabled = true;
			}
			else
			{
				topPlayer.GetComponent<PlayerControlOnClick> ().enabled = true;
				botPlayer.GetComponent<PlayerControlOnClick> ().enabled = false;
			}
		}
	}
}
