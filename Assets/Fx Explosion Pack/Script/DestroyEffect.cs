using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	public float t;
	void Start (){
		Invoke("die",t);
	}


	void die(){
		Destroy(gameObject);
	}
}
