using UnityEngine;
using System.Collections;

public class rotateOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			transform.Rotate (0, 0, 10);
		}
	}
}
