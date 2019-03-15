using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class mouseMoveY : MonoBehaviour {

	private float mouseSensitivityY;

	// Use this for initialization
	void Start () {
		mouseSensitivityY = 2;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * mouseSensitivityY);
	}
}
