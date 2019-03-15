using UnityEngine;
using System.Collections;

public class giveGun : MonoBehaviour {

	public string gun;
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
			SwitchGun(col.gameObject);
			gameObject.transform.position = gameObject.transform.position + new Vector3(0,-1000f,0);
			isWaiting = true;
		}
	}

	void SwitchGun(GameObject player){
		GameObject head = player.transform.Find("head").gameObject;
		int childCount = head.transform.childCount;
		for(int i = 0; i < childCount; i++){
			
			if(head.transform.GetChild(i).tag == "gun"){
//				GameObject.Destroy(head.transform.GetChild(i).gameObject);
				PhotonNetwork.Destroy(head.transform.GetChild(i).gameObject);

			}
		}
//		GameObject.Instantiate(gun,head.transform.position,head.transform.rotation,head.transform);
		GameObject thegun;
		thegun = PhotonNetwork.Instantiate(gun,head.transform.position,head.transform.rotation,0);
		thegun.transform.SetParent(head.transform);
		if(gun == "Chaingun"){
			thegun.GetComponentInChildren<rotateOnClick>().enabled = true;
		} 
		else if(gun == "Shotgun"){
			thegun.GetComponentInChildren<shotgunReload>().enabled = true;
		}
	}

}
