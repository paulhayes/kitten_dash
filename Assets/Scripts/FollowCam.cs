using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform target;
	public float maxHeight = 3;
	public float minHeight = 0;
	public float easeAmount = 0.1f;

	void Start () {
		
	}
	
	void LateUpdate () {
		Vector3 targetPos = target.position;
		
		targetPos.y = Mathf.Clamp( targetPos.y, minHeight, maxHeight );
		
		transform.Translate( targetPos.x - transform.position.x, targetPos.y - transform.position.y, 0 );
		
	}
}
