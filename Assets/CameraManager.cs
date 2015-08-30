using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static CameraManager CMInstance;
	
	public Camera topCamera;
	
	public Camera botCamera;

	// Use this for initialization
	void Awake () {
		CMInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
