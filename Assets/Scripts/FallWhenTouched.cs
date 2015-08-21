using UnityEngine;
using System.Collections;

public class FallWhenTouched : MonoBehaviour {

	Rigidbody2D rigidbody;
	
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.isKinematic = true;
	}
	
	void OnHitPlayer () {
		rigidbody.isKinematic = false;
	}
}
