using UnityEngine;
using System.Collections;

public class FallThrough : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		//stops the player from moving
		player.GetComponent<PlayerController> ().enabled = false;
		//makes the player fall down
		player.GetComponent<SphereCollider> ().enabled = false;
	}
}
