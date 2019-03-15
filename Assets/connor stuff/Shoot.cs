using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour {
	public string Projectile;
	public float fireRate;
	public bool mouseDown;
	public AudioClip fireSound;
	private float timer;
	public float maxAmmo;
	public float currentAmmo;
	public bool useRaycast;
/*	public float raycastDistance;
	public float damage;
	public float knockBackForce; */

	private PhotonView namePhotonView;

	// Use thi for iniialization
	void Start () {
		timer = 0;
		currentAmmo = maxAmmo;
		//StartCoroutine (TestForShoot ());
	}

	 //Update is called one per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if (Input.GetMouseButton (0) && timer > fireRate && currentAmmo > 0) {
			mouseDown = true;
//			Instantiate (Projectile, transform.position, transform.parent.rotation);
			GameObject myBullet = (GameObject) PhotonNetwork.Instantiate(Projectile, transform.position, transform.parent.rotation,0);
			myBullet.GetComponent<PhotonView>().RPC("SetName",PhotonTargets.All,PhotonNetwork.playerName);
//			if (useRaycast){
//				transform.Rotate (0, 0, 10);
//			} 
//			currentAmmo = currentAmmo - 1;
			timer = 0;
//			AudioSource.PlayClipAtPoint (fireSound, transform.position);
		} else {
			mouseDown = false;
		}
	}
}
