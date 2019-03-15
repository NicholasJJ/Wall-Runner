using UnityEngine;
using System.Collections;

public class giveHealth : MonoBehaviour {

	public float HpGiven;
	[SerializeField] private float waitTime;
	[SerializeField] private float timer;
	[SerializeField] private bool isWaiting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isWaiting){
			timer = timer + Time.deltaTime;
			if(timer >= waitTime){
				gameObject.transform.position = gameObject.transform.position + new Vector3(0,1000,0);
				timer = 0;
				isWaiting = false;
			}
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			GiveHp(col.gameObject);
			gameObject.transform.position = gameObject.transform.position + new Vector3(0,-1000f,0);
			isWaiting = true;
		}
	}
	void GiveHp(GameObject Player){
		Player.GetComponent<HealthAndRespawn>().Hp = Player.GetComponent<HealthAndRespawn>().Hp + HpGiven;
	}
}
