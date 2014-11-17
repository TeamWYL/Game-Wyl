using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x - speed;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x + speed;
			this.transform.position = position;
		}

	
	}

//	void FixedUpdate()
//	{
//		float moveHorizontal = Input.GetAxis("Vertical");
//		float moveVertical = Input.GetAxis("Horizontal");
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//		rigidbody.AddForce(movement * speed * Time.deltaTime);
//	}

}
