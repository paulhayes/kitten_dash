using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour {

	public float height;
	public float speed;
	
	Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
	}
	
	void Update () {
		Vector3 position = startPosition;
		position.y += height/2f * Mathf.Sin( speed * Time.time / 2f*Mathf.PI );
		transform.position = position;
	}
}
