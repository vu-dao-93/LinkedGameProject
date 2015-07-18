using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager GMInstance;

	public Text mainText;

	void Awake()
	{
		GMInstance = this;
	}
}
