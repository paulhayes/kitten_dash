using UnityEngine;
using System.Collections;

public class NinjaCat : MonoBehaviour {

	public float duration;
	public bool hasAbility;
	public KeyCode key;
	public SpriteRenderer symbol;
	
	private float elapsedTime;
	private bool activated;

	void Start () {
	
	}
	
	void Update () {
		if( Input.GetKeyDown( key ) && hasAbility ){
			SendMessage("EnableDoubleJump");
			activated = true;
			hasAbility = false;
			elapsedTime = 0;
		}
		
		if( activated ){
			elapsedTime += Time.deltaTime;
		}
		
		if( activated && elapsedTime >= duration ){
			activated = false;
			SendMessage("DisableDoubleJump");
			symbol.enabled = false;
		}
		
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if( collider.tag == "NinjaCatPowerUp" ){
			hasAbility = true;
			symbol.enabled = true;
		}
	}
	
	
	
	
	
}
