using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour {

	public float boostSpeed;
	public float duration;
	
	bool boosting;

	IEnumerator OnCollisionEnter2D(Collision2D collision){
	
		if( collision.gameObject.tag == "SpeedBoost" ){
			Debug.Log(collision.gameObject.tag);
			if( boosting ) yield break;
			boosting = true;
			GetComponentInChildren<ParticleSystem>().Play();
			RunAndJump runScript = GetComponent<RunAndJump>();
			float originalSpeed = runScript.runningSpeed;
			runScript.runningSpeed = boostSpeed;
			yield return new WaitForSeconds(duration);
			runScript.runningSpeed = originalSpeed;
			GetComponentInChildren<ParticleSystem>().Stop();
			boosting = false;
		}
	}

}
