using UnityEngine;
using System.Collections;

public class RunAndJump : MonoBehaviour {

	public float startDelay = 1;
	public float acceleration = 5;
	public float runningSpeed = 7;
	public float jumpForce = 9;
	public Bounds groundDetectionBox = new Bounds(new Vector2(0,-0.41f),new Vector2(1.12f,0.12f));
	[Header("Stuck Settings")]
	public float maximumStuckSpeed = 0.2f;
	public float stuckJumpAngle = 30;

	
	
	bool isTouchingGround;
	bool running;
	Rigidbody2D body;	
	
	IEnumerator Start(){
		body = GetComponent<Rigidbody2D>();
		
		yield return new WaitForSeconds(startDelay);
		
		running = true;
		GetComponent<Animator>().SetTrigger("Run");
	}
	
	void Update(){
	
		int notCatLayers = ~(1<<gameObject.layer);
		Bounds box = GetFloorTestBox();
		
		isTouchingGround = Physics2D.OverlapArea( box.min, box.max, notCatLayers ) != null;
		
		if( running && Input.GetButtonDown("Jump") && isTouchingGround ){
			Jump();
		}
		
		if( running && isTouchingGround ){
			float differenceInSpeed = acceleration * Mathf.Max( runningSpeed - body.velocity.x, 0 );
			body.AddForce(Vector2.right * differenceInSpeed );
		}	
	}
	
	void OnGameOver(){
		Destroy(this);
	}
	
	void OnDrawGizmosSelected(){
		Bounds box = GetFloorTestBox();
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(box.center,box.size);					
	}
	
	void Jump(){
		Vector2 jumpDirection = Vector2.up;
		if( IsStuck() ){
			jumpDirection = Quaternion.Euler(0,0,stuckJumpAngle) * Vector3.up;
		}
		GetComponent<Rigidbody2D>().AddForce(jumpDirection*jumpForce,ForceMode2D.Impulse);
	}
	
	Bounds GetFloorTestBox(){
		Bounds ground = groundDetectionBox; 
		ground.center += transform.position;
		return ground;
	}
	
	bool IsStuck(){
		return Mathf.Abs( body.velocity.x ) <= maximumStuckSpeed;
	}
}
