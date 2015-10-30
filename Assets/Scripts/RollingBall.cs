using UnityEngine;
using System.Collections;

public class RollingBall : MonoBehaviour {

	public Vector2 force;

	Rigidbody2D body;

	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		body.AddForce( force );
	}
}
