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
	[Header("Sounds")]
	public AudioSource jumpSound;
	
	public bool hasDoubleJump;
	public int jumpCounter;
	
	
	public bool isTouchingGround;
	bool running;
	Rigidbody2D body;	
	Collider2D[] overlappingColliders;
	
	IEnumerator Start(){
	
		overlappingColliders = new Collider2D[8];
		body = GetComponent<Rigidbody2D>();
		
		yield return new WaitForSeconds(startDelay);
		
		running = true;
		GetComponent<Animator>().SetTrigger("Run");
	}
	
	void Update(){
		
		bool canJump = isTouchingGround || ( hasDoubleJump && jumpCounter == 0 ); 
		if( running && Input.GetButtonDown("Jump") && canJump ){
			if( ! isTouchingGround ) jumpCounter++;
			else jumpCounter=0;
			Jump();
		}
		
		if( running && isTouchingGround ){
			//float differenceInSpeed = acceleration * Mathf.Max( runningSpeed - body.velocity.x, 0 );
			//body.AddForce(Vector2.right * differenceInSpeed );
			Vector2 velocity = body.velocity;
			velocity.x = runningSpeed;
			body.velocity = velocity;
		}
	}
	
	void FixedUpdate(){
		Bounds box = GetFloorTestBox();
		int numColliders = Physics2D.OverlapAreaNonAlloc( box.min, box.max, overlappingColliders );
		isTouchingGround = false;
		
		for( int i=0; i<numColliders; i++ ){
			if( overlappingColliders[i].gameObject != gameObject ){
				isTouchingGround = true;
				break;
			}
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
		if( jumpSound != null ) jumpSound.Play();
		if( IsStuck() ){
			jumpDirection = Quaternion.Euler(0,0,stuckJumpAngle) * Vector3.up;
		}
		GetComponent<Rigidbody2D>().AddForce(jumpDirection*jumpForce,ForceMode2D.Impulse);
	}
	
	void EnableDoubleJump(){
		hasDoubleJump = true;
	}
	
	void DisableDoubleJump(){
		hasDoubleJump = false;
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
