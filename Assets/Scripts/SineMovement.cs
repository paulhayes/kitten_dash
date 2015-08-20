using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour {

	public float height;
	public float speed;
	
	Vector3 startPosition;
	Rigidbody2D rigidbody;

	void Start () {
		startPosition = transform.position;
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		Vector3 position = startPosition;
		position.y += height/2f * Mathf.Sin( speed * Time.time / 2f*Mathf.PI );
		rigidbody.MovePosition( position );
		
	}
}
