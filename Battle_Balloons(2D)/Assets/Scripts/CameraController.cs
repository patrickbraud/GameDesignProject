using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private float xMin, xMax, yMin, yMax;
	
	private Vector3 offset;

	private float mapX = 50.0f;
	private float mapY = 25.0f;


	
	void Start ()
	{
		offset = transform.position - player.transform.position;


		float vertExtent = Camera.main.orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;

		xMin = (float)(horzExtent - mapX / 2.0);
		xMax = (float)(mapX / 2.0 - horzExtent);
		yMin = (float)(vertExtent - mapY / 2.0);
		yMax = (float)(mapY / 2.0 - vertExtent);
	}

	
	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;

		Vector3 v3 = player.transform.position;
		v3.x = Mathf.Clamp(v3.x, xMin, xMax);
		v3.y = Mathf.Clamp(v3.y, yMin, yMax);
		transform.position = v3 + offset;
	}
}
