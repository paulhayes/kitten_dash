using UnityEngine;
using System.Collections;

public class ChangingObstacle : MonoBehaviour {

	public Sprite obstacleSpriteAfterCollision;

	void OnTriggerEnter2D(Collider2D collider){
		
		OnHitPlayer();
		
	}
	
	void OnHitPlayer(){
		GetComponent<SpriteRenderer>().sprite = obstacleSpriteAfterCollision;
		gameObject.AddComponent<Rigidbody2D>();
		Destroy(this);
	}
}
