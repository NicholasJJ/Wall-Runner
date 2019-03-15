using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public float speed;

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Debug.Log ("pressed fire");
			GameObject Instance;
			Instance = PhotonNetwork.Instantiate ("sball", transform.position + transform.forward + transform.forward, transform.rotation ,0);
			Instance.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed);
			Instance.GetComponent<PhotonView>().RPC("SetName",PhotonTargets.All,PhotonNetwork.playerName);
		}
}
}