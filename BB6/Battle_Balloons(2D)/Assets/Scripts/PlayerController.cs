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

	public float CD_Remaining = 0;

	private Text cdText;
	private Text cdHolder;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();

		cdText = GameObject.FindGameObjectWithTag ("CooldownUI").GetComponent<Text> ();

		cdText.text = "Jump: " + CD_Remaining.ToString("0.0");
	}


	void Update()
	{
		//if local player set movement
		if (isLocalPlayer)
		{
			InputMovement ();
		}

		if (CD_Remaining > 0) {
			CD_Remaining -= Time.deltaTime;

			if(CD_Remaining < 0.0f)
				CD_Remaining = 0.0f;
			cdText.text = "Jump: " + CD_Remaining.ToString("0.0");
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
			CD_Remaining = jumpCooldown;
		}
	}
}
