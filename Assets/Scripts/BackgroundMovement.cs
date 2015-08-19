using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	public float speed;
	public Material backgroundMaterial;
	
	void Update(){
		backgroundMaterial.SetTextureOffset("_MainTex",new Vector2(transform.position.x*speed,0) );
	}
}
