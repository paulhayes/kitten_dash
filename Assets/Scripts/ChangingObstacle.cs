using UnityEngine;
using System.Collections;

public class ChangingObstacle : MonoBehaviour {

	public Sprite obstacleSpriteAfterCollision;
	public Animator animator;
	public AudioSource sound;

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
		if( animator != null ) animator.SetTrigger("OnHitPlayer");
		if( sound != null ) sound.Play();
		GetComponent<SpriteRenderer>().sprite = obstacleSpriteAfterCollision;
		Destroy(this);
		GetComponent<Collider2D>().enabled = false;
	}
}
