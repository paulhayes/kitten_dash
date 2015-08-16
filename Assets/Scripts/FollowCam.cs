using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform target;
	public float maxHeight;
	public float minHeight;
	public float easeAmount;

	void Start () {
		
	}
	
	void LateUpdate () {
		Vector3 targetPos = target.position;
		
		targetPos.y = Mathf.Clamp( targetPos.y, minHeight, maxHeight );
		
		transform.Translate( targetPos.x - transform.position.x, targetPos.y - transform.position.y, 0 );
		
	}
}
