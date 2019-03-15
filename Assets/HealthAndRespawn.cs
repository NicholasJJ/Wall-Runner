using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthAndRespawn : MonoBehaviour {

	public float Hp;
	public float testDamage;
	[SerializeField] private float maxHp;
	[SerializeField] private int deathCounter;
	public float distTillDeath;

	public string lastHitBy;
	public int currentDeathTexts;

	GameObject[] spot;

	// Use this for initialization
	void Start () {
		Hp = maxHp;
		spot = GameObject.FindGameObjectsWithTag("spawnSpot");
	}

	void Update() {
		GameObject.FindGameObjectWithTag("hpslide").GetComponent<Slider>().value = Hp/maxHp;
		if (Hp > maxHp){
			Hp = maxHp;
		}
		if(Input.GetKeyDown(KeyCode.U)){
			Hp = Hp - testDamage;
			if (Hp <= 0f){
				lastHitBy = "themself";
				Respawn();
			}
		}
		if(Vector3.Distance(gameObject.transform.position,Vector3.zero) >= distTillDeath){
			lastHitBy = "the void";
			Respawn();
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "bullet"){
			Hp = Hp - col.gameObject.GetComponent<damage>().dam;
			if (Hp <= 0f){
				lastHitBy = col.gameObject.GetComponent<nameSetter>().name;
				Respawn();
			}
		}
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "boom"){
			Hp = Hp - ((coll.gameObject.GetComponent<damage>().dam)/(Vector3.Distance(coll.transform.position,gameObject.transform.position)));
			if (Hp <= 0f){
				lastHitBy = coll.gameObject.GetComponent<nameHolder>().name;
				Respawn();
			}
		}
		if(coll.gameObject.tag == "bullet"){
			Hp = Hp - coll.gameObject.GetComponent<damage>().dam;
			if (Hp <= 0f){
				lastHitBy = coll.gameObject.GetComponent<nameSetter>().name;
				Respawn();
			}
		}
	}
	void Respawn(){
		deathCounter++;

		string myName = gameObject.GetComponent<nameHolder>().name;
		string deathTextSays = myName + " was killed by " + lastHitBy;
		GameObject myDeathText = (GameObject) PhotonNetwork.Instantiate("Dtext",Vector3.zero,Quaternion.identity,0);
		myDeathText.GetComponent<PhotonView>().RPC("SetText",PhotonTargets.All,deathTextSays);

		GameObject mySpawnSpot = spot [Random.Range(0,spot.Length)];
		gameObject.transform.position = mySpawnSpot.transform.position;
		gameObject.transform.rotation = mySpawnSpot.transform.rotation;
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		Hp = maxHp;
		Debug.Log("respawning");
	}
}
