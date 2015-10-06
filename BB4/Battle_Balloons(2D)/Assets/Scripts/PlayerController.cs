using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

	private Rigidbody2D rb;
	private float timeStamp = 0.0f;

	public float speed;
	public float jumpSpeed;
	public float jumpCooldown;


	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}


	void Update()
	{
		//if local player set movement and camera
		if (isLocalPlayer)
		{
			InputMovement ();
		}
	}

	void InputMovement ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		
		rb.AddForce (movement * speed);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}
	}

	void Jump (){

		if (timeStamp <= Time.time) {
			rb.AddForce (Vector2.up * jumpSpeed);
			timeStamp = Time.time + jumpCooldown;
		}
	}
}
