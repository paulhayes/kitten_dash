using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SineMovement : MonoBehaviour {

	public float height;
	public float speed;
	public float centerPosition;
	public float timeOffset;
	
	Rigidbody2D rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.isKinematic = true;
	}
	
	void Update () {
		Vector3 position = transform.position;
		position.y = centerPosition + height/2f * Mathf.Sin( speed * ( Time.time + timeOffset ) / 2f*Mathf.PI );
		rigidbody.MovePosition( position );		
	}
	
	void Fall(){
		rigidbody.isKinematic = false;
		Destroy( this );
	}
	
	void OnDrawGizmosSelected(){
		Vector3 position = transform.position;
		position.y = centerPosition + height/2f * Mathf.Sin( speed * timeOffset / 2f*Mathf.PI );
		
		transform.position = position;
	}
}
