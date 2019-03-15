using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour {
	public GameObject Explosion;
	public float deathTime;
	[SerializeField] private float saftyTime;
	[SerializeField] private float timer;
	// Use this fr initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if (timer >= deathTime) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider colider){

		if(timer >= saftyTime || colider.gameObject.tag != "Player"){
			GameObject myExplosion = (GameObject) Instantiate(Explosion, transform.position, Quaternion.identity);
			myExplosion.GetComponent<nameHolder>().name = gameObject.GetComponent<nameSetter>().name;
			Destroy (gameObject);
		}
	}
}
