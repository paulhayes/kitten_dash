using UnityEngine;
using System.Collections;

public class SaveSpot : MonoBehaviour {

	public static Vector3 position = Vector3.zero;

	void Awake(){
		if( position != Vector3.zero ){
			transform.position = position;			
		}
	}

	void OnTriggerEnter2D(Collider2D collider){ 
		if(collider.gameObject.tag == "Respawn"){
			Debug.Log("Respawn point "+collider.transform.position);
			position = collider.transform.position;			
			collider.gameObject.GetComponentInChildren<ParticleSystem>().Play();
		}
	}
}
