using UnityEngine;
using System.Collections;

public class ChangingObstacle : MonoBehaviour {

	public Sprite obstacleSpriteAfterCollision;

	void OnTriggerEnter2D(Collider2D collider){
		if( collider.tag == "Player" ){
			SendMessage("OnHitPlayer");		
		}
	}
	
	void OnCollision2D(Collision2D collision){
		if( collision.collider.tag == "Player" ){
			SendMessage("OnHitPlayer");		
		}
	}
	
	void OnHitPlayer(){
		GetComponent<SpriteRenderer>().sprite = obstacleSpriteAfterCollision;
		Destroy(this);
		GetComponent<Collider2D>().enabled = false;
	}
}
