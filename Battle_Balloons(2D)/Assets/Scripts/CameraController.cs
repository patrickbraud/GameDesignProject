using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float xMin, xMax, yMin, yMax;
	
	private Vector3 offset;

	public float mapX;
	public float mapY;


	
	void Start ()
	{
		offset = transform.position - player.transform.position;


		float vertExtent = Camera.main.orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;

//		xMin = (float)(horzExtent - mapX / 2.0);
//		xMax = (float)(mapX / 2.0 - horzExtent);
//		yMin = (float)(vertExtent - mapY / 2.0);
//		yMax = (float)(mapY / 2.0 - vertExtent);
	}

	
	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;

		Vector3 v2 = transform.position;
		v2.x = Mathf.Clamp(v2.x, xMin, xMax);
		v2.y = Mathf.Clamp(v2.y, yMin, yMax);
		transform.position = v2 + offset;
	}
}
