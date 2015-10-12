﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public GameObject secretDoor;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		//SetCountText ();
		winText.text = "";
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
			count += 1;
			SetCountText ();
		}

		if (count == 1) 
		{
			secretDoor.transform.Rotate(0, -90, 0);
		}
	}

	void SetCountText()
	{
		countText.text = "Gem Count: " + count.ToString ();
		if (count == 6) 
		{
			winText.text = "You have escaped safely! :)";
		}
	}
}