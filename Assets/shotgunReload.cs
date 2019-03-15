using UnityEngine;
using System.Collections;

public class shotgunReload : MonoBehaviour {

	public Vector3 rot;
	[SerializeField] private float timer;
	[SerializeField] private bool animating;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if(timer > 1.5f && animating == true){
			transform.Rotate(-rot);
			animating = false;
		}
		else if(Input.GetMouseButton (0) && timer > 1.5f){
			transform.Rotate(rot);
			animating = true;
			timer = 0;
		}
	}
}
