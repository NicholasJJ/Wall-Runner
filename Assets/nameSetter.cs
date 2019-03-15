using UnityEngine;
using System.Collections;

public class nameSetter : MonoBehaviour {

	public string name;

	[PunRPC]
	void SetName(string newName){
		name = newName;
	}
}
