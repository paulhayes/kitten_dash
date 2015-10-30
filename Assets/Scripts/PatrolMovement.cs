using UnityEngine;
using System.Collections;

public class PatrolMovement : MonoBehaviour {

	public float leftPosition;
	public float rightPosition;
	public float speed;
	Rigidbody2D body;
	bool movingRight = true;
	
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		if( movingRight ){
			MoveRight();
		}
		else {
			MoveLeft();
		}
		
    }
    
    void MoveRight(){
		if( body.position.x >= rightPosition ){
    		movingRight = false;
			body.velocity = Vector2.zero;
			transform.localScale = new Vector3(-1,1,1);
        }
		else body.velocity = speed * Vector2.right;
    }
    
    void MoveLeft(){
		if( body.position.x <= leftPosition ){
			movingRight = true;
			body.velocity = Vector2.zero;
			transform.localScale = new Vector3(1,1,1);
        }
		else body.velocity = speed * Vector2.left;
    }
}
