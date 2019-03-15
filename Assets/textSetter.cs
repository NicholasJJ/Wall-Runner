using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textSetter : MonoBehaviour {

	[SerializeField] private float timer;
	[SerializeField] private float timeTillDissapear;

	// Use this for initialization
	void Start () {
		int currentDeathTexts = GameObject.FindGameObjectsWithTag("DeathText").Length;
		float xsize = 620f / 2f;
		float ysize = 30f / 2f;
		transform.localPosition = new Vector2(Screen.width - xsize,Screen.height /*- ysize*/ - (currentDeathTexts *30f));
		transform.SetParent(GameObject.Find("Canvas").transform);
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if(timer >= timeTillDissapear){
//			for(int i = 0;i <= GameObject.FindGameObjectsWithTag("DeathText").Length; i++){
//				GameObject.FindGameObjectsWithTag("DeathText")[i].BroadcastMessage("DTextGone");
//			}
			GameObject[] dTexts;
			dTexts = GameObject.FindGameObjectsWithTag("DeathText");
			foreach(GameObject dtext in dTexts){
				dtext.BroadcastMessage("DTextGone");
			}
			Destroy(gameObject);
		}
	}

	void DTextGone(){
		transform.localPosition = new Vector2(transform.localPosition.x,transform.localPosition.y + 30f);
	}

	[PunRPC]
	void SetText(string text){
		gameObject.GetComponent<Text>().text = text;
	}
}
