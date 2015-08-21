using UnityEngine;
using System.Collections;

public class PatrolMovement : MonoBehaviour {

	public float leftPosition;
	public float rightPosition;
	public float speed;
	Rigidbody2D rigidbody;
	bool movingRight = true;
	
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if( movingRight ){
			MoveRight();
		}
		else {
			MoveLeft();
		}
		
    }
    
    void MoveRight(){
    	if( rigidbody.position.x >= rightPosition ){
    		movingRight = false;
			rigidbody.velocity = Vector2.zero;
			transform.localScale = new Vector3(-1,1,1);
        }
		else rigidbody.velocity = speed * Vector2.right;
    }
    
    void MoveLeft(){
		if( rigidbody.position.x <= leftPosition ){
			movingRight = true;
			rigidbody.velocity = Vector2.zero;
			transform.localScale = new Vector3(1,1,1);
        }
        else rigidbody.velocity = speed * Vector2.left;
    }
}
