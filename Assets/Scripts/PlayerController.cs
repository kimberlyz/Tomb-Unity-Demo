using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveVertical = Input.GetAxis ("Vertical");
		//Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);
		//rb.AddRelativeForce (movement * speed);

		float rotateHorizontal = Input.GetAxis ("Horizontal");
		//transform.Rotate (0, rotateHorizontal, 0);

		transform.Translate(Vector3.forward * moveVertical * speed);
		transform.Rotate(Vector3.up * rotateHorizontal);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
		}
	}
}