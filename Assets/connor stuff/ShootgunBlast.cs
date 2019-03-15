using UnityEngine;
using System.Collections;

public class ShootgunBlast : MonoBehaviour {
	public float damage;
	GameObject player;

	// Use this for initialiation
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.transform.Translate (0, 0, 4.5f);
		gameObject.transform.Rotate (90, 0, 0);
		StartCoroutine (DestroyAfterTick ());
		Rigidbody playerRB = player.GetComponent<Rigidbody>();
		playerRB.AddExplosionForce (2000, transform.position, 10);
	}
		
	IEnumerator DestroyAfterTick(){
		yield return new WaitForFixedUpdate ();
		Destroy (gameObject);
	}
}
