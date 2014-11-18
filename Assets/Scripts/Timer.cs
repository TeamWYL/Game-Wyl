using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Attach in MainCamera
public class Timer : MonoBehaviour {
	public Slider slider;
	public GameObject player;
	public Image fill;

	// Use this for initialization
	void Awake (){
		slider.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		//uncomment which one you want to try
		//magnit
//		if (player.GetComponent<PMovePull> ().MagnetAbility) {
//			fill.GetComponent<Image>().color = Color.green;
//			slider.gameObject.SetActive (true);
//			slider.value = player.GetComponent<PMovePull> ().timeLeftGreen;
//		}
		//indestr
		if (player.GetComponent<Indestructibility> ().isIndestr) {
			fill.GetComponent<Image>().color = Color.red;
			slider.gameObject.SetActive (true);
			slider.value = player.GetComponent<Indestructibility> ().timeLeftRed;
		}
		else {
			slider.gameObject.SetActive (false);
				}
	}
}
