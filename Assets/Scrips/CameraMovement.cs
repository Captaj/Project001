using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	public GameObject player;
	private Vector3 offset;

	// Start is called before the first frame update
	void Start()
	{
		//sets where the camera is in comparison to the player
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		//moves the camera with the player, taking into account the original offset
		transform.position = player.transform.position + offset;
	}
}