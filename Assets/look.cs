using UnityEngine;
using System.Collections;

public class look : MonoBehaviour {

	public Vector3 p;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		RaycastHit hrit;
		Ray h = new Ray(gameObject.transform.position,gameObject.transform.forward);
		if(Physics.Raycast(h, out hrit)){
			p = hrit.point;
		}
		else {
			p = Vector3.zero;
		}
	}
}