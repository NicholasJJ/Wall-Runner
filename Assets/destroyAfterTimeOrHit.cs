using UnityEngine;
using System.Collections;

public class destroyAfterTimeOrHit : MonoBehaviour {

	public float time;
	void Start () {
		Invoke ("death", time);
	}

	IEnumerator wat(){
		yield return new WaitForSeconds (0.1f);
	}

	void OnCollisionEnter (Collision col) {
		StartCoroutine ("wat");
		Destroy (gameObject);
	}
	void death () {
//		PhotonNetwork.Destroy(gameObject);
		Destroy(gameObject);
	}
}
