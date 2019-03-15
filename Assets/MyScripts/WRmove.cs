using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

//[RequireComponent(typeof (CharacterController))]
public class WRmove : MonoBehaviour {

	//Camera Stuff
	public float mouseSensitivityX = 2;
	public float mouseSensitivityY = 2;
	Transform cameraTransform;
	//	private Camera m_Camera;
	float verticalLookRotation;
	private Vector3 m_OriginalCameraPosition;
	private Transform camTrans;

	//Walking Stuff
	public bool isWalking;
	public bool isRunning;
	public float walkSpeed;
	public float runSpeed;
	public float currentSpeed;
	[SerializeField] private Vector3 moveInp;

	//Jumping Stuff
	public float gravity;
	[SerializeField] private bool isJumping;
	public int jumps;
	public int maxJumps;
	public float jumpForce;

	//Wall Running Stuff
	public Vector3 targetNormal;
	public Vector3 currentNormal;
	public Vector3 localUp;
	public Vector3 myPos;
	public Vector3 colPos;
	public float normalChangeSpeed;
	public Vector3 targetPoint;
	public float distTillJump;

	//hookshot stuff
//	public bool isHookTraveling;
//	[SerializeField] private float hookCountDown;
//	public float hookCountTime;
//	public Vector3 hookTarg;
//	public float hookTravelSpeed;
//	public float maxWorpDist;
//	[SerializeField] private Vector3 worpSpot;
//	public float jumpmod;



	// Use this for initialization
	void Start () {
//		isHookTraveling = false;
		Cursor.lockState = CursorLockMode.Locked;
		isRunning = false;
		isWalking = true;
		currentSpeed = walkSpeed;
		jumps = 0;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.J)){
			Cursor.lockState = CursorLockMode.None;
		} 
		else if (Input.GetKeyDown(KeyCode.K)){
			Cursor.lockState = CursorLockMode.Locked;
		}
//		hookCountDown = hookCountDown +Time.deltaTime;
//		if(hookCountDown >= hookTravelSpeed){
//			isHookTraveling = false;
//		}
		if(jumps <= maxJumps && Input.GetButtonDown("Jump")){
//			GetComponent<Rigidbody>().velocity = new Vector3 (GetComponent<Rigidbody>().velocity.x,0,GetComponent<Rigidbody>().velocity.z);
			GetComponent<Rigidbody> ().AddForce(currentNormal * jumpForce);
			isJumping = true;
			jumps++;
		}
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
//		checkMoveState();
		moveInp = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
		GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + transform.TransformDirection(moveInp) * currentSpeed * Time.deltaTime);
	
		RaycastHit rit;
		myPos = gameObject.transform.position;
		colPos = targetPoint;
		Ray r = new Ray(myPos, colPos - myPos);
		if(Physics.Raycast(r, out rit)){
			targetNormal = rit.normal/*rit.transform.TransformDirection(rit.normal)*/;
//			Debug.Log("normal is " + rit.normal);
		}

		if(isJumping == false && Vector3.Distance(gameObject.transform.position,rit.point) <= distTillJump){
			currentNormal = Vector3.Lerp(currentNormal,targetNormal,normalChangeSpeed * Time.deltaTime);
			}
		localUp = GetComponent<Rigidbody> ().transform.up;
		GetComponent<Rigidbody> ().AddForce(currentNormal * -gravity);
		GetComponent<Rigidbody> ().rotation = Quaternion.FromToRotation(localUp,currentNormal) * GetComponent<Rigidbody>().rotation;
	}

	void OnCollisionEnter(Collision col){
//		Debug.Log("colliding with " + col.gameObject.name);
		isJumping = false;
		jumps = 0;
		currentNormal = Vector3.Lerp(currentNormal,targetNormal,normalChangeSpeed * Time.deltaTime);
//		isHookTraveling = false;
//		hookCountDown = 0;
//		currentWall = col.gameObject;
	}

	void OnCollisionStay(Collision col){
//		Debug.Log("colliding with " + col.gameObject.name);
//		targetNormal = col.contacts[0].normal;
		targetPoint = col.contacts[0].point;

	}


//	void checkMoveState(){
//		if (Input.GetKey (KeyCode.LeftShift)) {
//			isWalking = false;
//			isRunning = true;
//			currentSpeed = runSpeed;
//		} else {
//			isRunning = false;
//			isWalking = true;
//			currentSpeed = walkSpeed;
//		}
//	}
}
