using UnityEngine;
using System.Collections;

public class RunAndJump : MonoBehaviour {

	public float speed;
	public float delay;
	public float jumpForce;
	public Bounds groundDetectionBox;
	public bool isTouchingGround;
	
	public bool running;
	Rigidbody2D body;	
	
	IEnumerator Start(){
		body = GetComponent<Rigidbody2D>();
		
		yield return new WaitForSeconds(delay);
		
		running = true;
		GetComponent<Animator>().SetTrigger("Run");
	}
	
	void Update(){
	
		int notCatLayers = ~(1<<gameObject.layer);
		Bounds box = GetFloorTestBox();
		
		isTouchingGround = Physics2D.OverlapArea( box.min, box.max, notCatLayers ) != null;
		
		
	
		if( running && Input.GetButtonDown("Jump") && isTouchingGround ){
			GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
		}
		
		if( running && isTouchingGround ){
			float differenceInSpeed = speed - body.velocity.x;
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
	
	Bounds GetFloorTestBox(){
		Bounds ground = groundDetectionBox; 
		ground.center += transform.position;
		return ground;
	}
}
