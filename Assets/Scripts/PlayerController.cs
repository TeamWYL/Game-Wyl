using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	void Update()
	{
//		float moveHorizontal = Input.GetAxis("Vertical");
		float moveVertical = Input.GetAxisRaw("Horizontal");

//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//rigidbody.AddForce(movement * speed * Time.deltaTime);
		//Vector3 jump = Vector3.zero;
		float jump = 7;
		if (Input.GetKeyDown("space")) {
			rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);

				}
		transform.position += new Vector3 (moveVertical,0,0)*speed;



	}

}
