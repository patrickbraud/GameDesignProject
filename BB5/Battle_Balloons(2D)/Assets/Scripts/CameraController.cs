using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class CameraController : NetworkBehaviour {

	public GameObject player;

	private float xMin, xMax, yMin, yMax;
	private Vector3 offset;

	public float mapX;
	public float mapY;


	
	void Start()
	{

		Camera.main.transform.position = transform.position;

		offset = transform.position - player.transform.position;


		float vertExtent = Camera.main.orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;

		xMin = (float)(horzExtent - mapX / 2.0);
		xMax = (float)(mapX / 2.0 - horzExtent);
		yMin = (float)(vertExtent - mapY / 2.0);
		yMax = (float)(mapY / 2.0 - vertExtent);
	}

	
	void Update ()
	{


		if (isLocalPlayer) {
			Camera.main.transform.position = player.transform.position + offset;

			Vector3 v3 = transform.position;

			Camera.main.transform.position = v3 + offset;

			Vector3 newV = transform.position;

			newV.z = -2.5f;
			newV.x = Mathf.Clamp (newV.x, xMin, xMax);
			newV.y = Mathf.Clamp (newV.y, yMin, yMax);

			Camera.main.transform.position = newV;

		}
	}
}
