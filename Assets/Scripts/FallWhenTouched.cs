using UnityEngine;
using System.Collections;

public class FallWhenTouched : MonoBehaviour {

	Rigidbody2D body;
	
	void Start () {
		body = GetComponent<Rigidbody2D>();
		body.isKinematic = true;
	}
	
	void OnHitPlayer () {
		body.isKinematic = false;
	}
}
