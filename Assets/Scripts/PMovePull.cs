using UnityEngine;
using System.Collections;

public class PMovePull : MonoBehaviour
{

	//public Transform PlayerStartPoint;
	public GameObject Player;
	public GameObject Magnet;

	public float speed;

	public float timeLeftGreen;

	public bool MClickOver;
	public bool MagnetAbility;
	
	private string GreenCapsule;

	public Rigidbody otherBody;

	public Material GreenMaterial;
	public Material WhiteMaterial;

	public float distance;
	public float distanceAbility;

	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		//Magnet = GameObject.FindGameObjectWithTag("Magnet");

		GreenCapsule = "GreenCapsule";

		speed = 5f;
		distanceAbility = 7f;

		MClickOver = false;
		MagnetAbility = false;
	}
	void Update()
	{		
		
		if(MagnetAbility)	
		{
			timeLeftGreen -= Time.deltaTime;

			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("Pressed left click.");
				CastRay();
			}

			if (MClickOver)
			{
				MagnitUpdate();
			}


			if ( timeLeftGreen < 0 )
			{
				DeactivateMagnetAbility();
			}
		}
		
	}

	void DeactivateMagnetAbility()
	{
		MagnetAbility = false;
		Player.rigidbody.useGravity = true;
		Player.renderer.material = WhiteMaterial;
	}
	


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == GreenCapsule)
		{
			GreenCapsuleTriggerEnter(other.gameObject);
		}
		if (MClickOver)
		{
			if(other.gameObject.tag == Magnet.tag)
			{
				MagnetTriggerEnter();
			}
		}
	}

	void GreenCapsuleTriggerEnter(GameObject greenCapsuleObject)
	{
		MagnetAbility = true;
		timeLeftGreen = 5f;
		Player.renderer.material = GreenMaterial;
		Destroy(greenCapsuleObject);
	}

	void MagnetTriggerEnter()
	{
		Player.transform.Translate(new Vector3 (0,0,0));
		MClickOver = false;
	}
	
	void CastRay() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			Debug.DrawLine(ray.origin, hit.point);
			Debug.Log("Hit object: " + hit.collider);

			distance = Vector3.Distance (hit.collider.gameObject.transform.position, Player.transform.position);

			if (hit.collider.gameObject.tag.ToString() == "Magnet" && distance <= distanceAbility)
			{
				Debug.Log("Magnetizirahme se :))");
				Player.rigidbody.useGravity = false;
				Magnet = hit.collider.gameObject;
				MClickOver = true;
			}
		}

	}

	void MagnitUpdate()
	{
		Vector3 whereIWantToBe = Magnet.transform.position;
		Vector3 direction = whereIWantToBe - Player.transform.position;

		Player.transform.Translate(direction * Time.deltaTime * speed);
	}
}
