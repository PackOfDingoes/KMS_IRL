using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	private GameObject player;
	private GameController gameController;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		gameController = GetComponent<GameController>();
	}

	void Update () 
	{
		if(gameController.cameraFollowPlayer == true)
		{
			this.transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 1f,this.transform.position.z);
		}
	}
}
