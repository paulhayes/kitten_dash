using UnityEngine;
using System.Collections;

public class FallWhenTouched : MonoBehaviour {

	Rigidbody2D body;
	
	void Start () {
		body = GetComponent<Rigidbody2D>();
		body.isKinematic = true;
	}
	
	void OnCollision2D(Collision2D collision){
		Debug.Log("Collision");
		if( collision.collider.tag == "Player" ){
			body.isKinematic = false;
			SendMessage("Fall",SendMessageOptions.DontRequireReceiver);	
		}
	}

}
