using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

	public float sballspeed; 

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.TransformDirection (Vector3.forward * sballspeed);
	}

	// Update is called once per frame
	void Update () {

	}
}
