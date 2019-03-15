using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PUNetworkManager : MonoBehaviour {

	public Camera MenuCamera;

	GameObject[] spot;

	// Use this for initialization
	void Start () {
		spot = GameObject.FindGameObjectsWithTag("spawnSpot");
//		Connect(); 
	}

	void Online(){
		PhotonNetwork.ConnectUsingSettings("WR v0.1.0");
	}

	void Offline(){
		PhotonNetwork.offlineMode = true;
		OnJoinedLobby();
	}

//	void Connect(){
//		PhotonNetwork.ConnectUsingSettings("WR v0.0.7");
//	}

	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log("failed to join a room");
		PhotonNetwork.CreateRoom( null );
	}

	void OnJoinedRoom(){
		Debug.Log("joined room");
		SpawnMyPlayer();
	}

	void SpawnMyPlayer(){
		string name = GameObject.FindGameObjectWithTag("name").GetComponent<Text>().text;

		GameObject.Find("Start UI").SetActive(false);
		GameObject.Find("Health UI").transform.position = new Vector2(60f,63.132f);

		GameObject mySpawnSpot = spot [Random.Range(0,spot.Length)];

		GameObject myPlayerGO = (GameObject) PhotonNetwork.Instantiate("WRMan", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation ,0);
		MenuCamera.enabled = false;
		myPlayerGO.GetComponent<WRmove>().enabled = true;
		myPlayerGO.GetComponent<HealthAndRespawn>().enabled = true;
		myPlayerGO.GetComponent<CapsuleCollider>().enabled = true;
		myPlayerGO.transform.Find("head").gameObject.SetActive(true);
		myPlayerGO.transform.Find("wrkarren").gameObject.SetActive(false);
		myPlayerGO.GetComponent<nameHolder>().name = name;
		PhotonNetwork.playerName = name;
	}
}
