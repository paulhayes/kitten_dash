using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour {

	public bool startFromThisPoint;

	void Awake () {
		if( startFromThisPoint ){
			SaveSpot.position = transform.position;
		}
	}
	

}
