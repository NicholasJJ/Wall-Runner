using UnityEngine;
using System.Collections;

public class ChaingunKnockbackController : MonoBehaviour {
	GameObject player;

	// Use this for initialiation
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.transform.Translate (0, 0, 10f);
		Rigidbody playerRB = player.GetComponent<Rigidbody>();
		playerRB.AddExplosionForce (350, transform.position, 20);
		StartCoroutine (DestroyAfterTick ());

	}
		
	IEnumerator DestroyAfterTick(){
		gameObject.transform.Rotate (90, 0, 0);
		yield return new WaitForFixedUpdate ();
		Destroy (gameObject);
	}
}
