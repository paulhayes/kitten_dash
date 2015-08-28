using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SineMovement : MonoBehaviour {

	public float height;
	public float speed;
	public float centerPosition;
	public float timeOffset;
	
	Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D>();
		body.isKinematic = true;
	}
	
	void Update () {
		Vector3 position = transform.position;
		position.y = centerPosition + height/2f * Mathf.Sin( speed * ( Time.time + timeOffset ) / 2f*Mathf.PI );
		body.MovePosition( position );		
	}
	
	void Fall(){
		body.isKinematic = false;
		Destroy( this );
	}
	
	void OnDrawGizmosSelected(){
		Vector3 position = transform.position;
		position.y = centerPosition + height/2f * Mathf.Sin( speed * timeOffset / 2f*Mathf.PI );
		
		transform.position = position;
	}
}
