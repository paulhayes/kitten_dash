using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float force;
	public float groundDistance;
	
	bool isTouchingGround = false;

	void Start(){
		
	}

	void Update () {
				
		if( Input.GetButtonDown("Jump") && isTouchingGround ){
			GetComponent<Rigidbody2D>().AddForce(Vector2.up*force,ForceMode2D.Impulse);
		}
		
		isTouchingGround = false;
	}
	
	void OnCollisionStay2D(Collision2D collision){
		isTouchingGround = isTouchingGround || collision.collider.transform.position.y < transform.position.y;
	}

	void OnGameOver(){
		Destroy(this);
    }
}
