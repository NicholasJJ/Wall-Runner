using UnityEngine;
using System.Collections;

public class networkCharacter : Photon.MonoBehaviour {

	Vector3 realPos = Vector3.zero;
	Quaternion realRot = Quaternion.identity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(photonView.isMine){
			// do nothing
		}
		else {
			transform.position = Vector3.Lerp(transform.position,realPos,0.4f);
			transform.rotation = Quaternion.Lerp(transform.rotation,realRot,0.4f);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		Debug.Log("network character being run");

		if(stream.isWriting){
			// Our character, send data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else {
			// Not our character, gather data
			realPos = (Vector3)stream.ReceiveNext();
			realRot = (Quaternion)stream.ReceiveNext();
		}
	}
}
