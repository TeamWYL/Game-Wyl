using UnityEngine;
using System.Collections;

public class Indestructibility : MonoBehaviour {
	public GameObject player;
	GameObject[] blades;
	public GameObject flame;
	public bool isIndestr;
	public float timeLeftRed;

	// Use this for initialization
	void Awake(){
		player.GetComponentInChildren<CapsuleCollider> ().enabled = false;
	}
	void Start () {
		blades = GameObject.FindGameObjectsWithTag("Blades");
		//childFlame.SetActive (true);
		player.GetComponentInChildren<ParticleSystem> ().enableEmission = false;
		//isIndestr = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (isIndestr) {

			timeLeftRed -= Time.deltaTime;
			if (timeLeftRed<=0) {
				player.GetComponentInChildren<ParticleSystem> ().enableEmission = false;
				isIndestr = false;
				foreach (var blade in blades) {
					blade.GetComponent<BoxCollider>().enabled = true;
				}


			}
				}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "IndestructibilityPill") {
			timeLeftRed = 5f;

			//Destroy(col.gameObject);
			foreach (var blade in blades) {
				blade.GetComponent<BoxCollider>().enabled = false;
			}
			//col.GetComponent<ParticleSystem>().startColor = Color.Lerp(Color.red,Color.cyan,3);
			isIndestr = true;
			col.GetComponent<CapsuleCollider>().enabled = false;

			player.GetComponentInChildren<ParticleSystem> ().enableEmission = true;
			col.GetComponent<ParticleSystem>().enableEmission = false;
				}
		if (col.gameObject.tag == "Blades") {
			//implement health loss
			Destroy(gameObject);
				}

	}
}
