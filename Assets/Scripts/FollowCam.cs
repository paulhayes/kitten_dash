using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform target;
	public float maxHeight;
	public float minHeight;
	public float easeAmount;

	void Start () {
		
	}
	
	void Update () {
		Vector3 targetPos = target.position;
		Vector3 currentPos = transform.position;
		
		targetPos.y = Mathf.Clamp( targetPos.y, minHeight, maxHeight );
		
		transform.Translate( easeAmount*(targetPos.x-currentPos.x),easeAmount*(targetPos.y-currentPos.y),0 );
		
	}
}
