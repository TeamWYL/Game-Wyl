using UnityEngine;
using System.Collections;

public class Indestructibility : MonoBehaviour {
	public GameObject blades;
	public GameObject indestr;
	public bool isIndestr;
	public float timeLeftRed;
	// Use this for initialization
	void Start () {
		blades.GetComponent<BoxCollider>().isTrigger = true;
		timeLeftRed = 5f;
		isIndestr = false;
		indestr.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		if (isIndestr) {
			timeLeftRed -= Time.deltaTime;
			if (timeLeftRed<=0) {
				isIndestr = false;
				blades.GetComponent<BoxCollider>().isTrigger = true;

			}
				}
	}
	void OnColliderEnter (){
		}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "IndestructibilityPill") {
			Destroy(col.gameObject);
			blades.GetComponent<BoxCollider>().isTrigger = false;
			isIndestr = true;
				}
		else {
			//implemet health loss
			Destroy (gameObject);
				}

	}
}
