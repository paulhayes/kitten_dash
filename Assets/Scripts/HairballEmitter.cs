using UnityEngine;
using System.Collections;

public class HairballEmitter : MonoBehaviour {

	public GameObject hairballPrefab;
	public Transform spawnPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject hairball = Instantiate (hairballPrefab);
		hairball.transform.position = spawnPosition.position;

	}
}
