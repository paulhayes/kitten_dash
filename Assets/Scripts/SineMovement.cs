using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour 
{

	public float height;
	public float width;
	public float speed;
	public Vector2 centerPosition;
	public float timeOffset;
	
	Rigidbody2D body;

	void Start () 
	{
		body = GetComponent<Rigidbody2D>();
		body.isKinematic = true;
		centerPosition = transform.position;
	}
	
	void Update () 
	{
		SetPosition();
	}
	
	void Fall() 
	{
		body.isKinematic = false;
		Destroy( this );
	}
	
	void SetPosition() 
	{
		Vector3 position = body.position;
		position.y = centerPosition.y + height/2f * Mathf.Sin( speed * ( Time.time + timeOffset ) / 2f*Mathf.PI );
		position.x = centerPosition.x + width/2f * Mathf.Cos ( speed * ( Time.time + timeOffset ) / 2f*Mathf.PI );
		transform.position = position;
		body.MovePosition( position );
	}
	
	void OnDrawGizmosSelected() 
	{
	/*
		Vector3 position = transform.position;
		position.y = centerPosition.x + height/2f * Mathf.Sin( speed * timeOffset / 2f*Mathf.PI );
		position.x = centerPosition.y
		transform.position = position;
		*/
	}
}
