using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	private Collider2D doorCollider;
	private Renderer doorVisuals;
	//private bool isActivated = false;
	// Use this for initialization
	void Start () 
	{
		doorCollider = this.GetComponent<Collider2D>();
		doorVisuals = this.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void OpenSeseme(bool isOpen)
	{
		if (isOpen == true)
		{
			doorCollider.enabled = false;
			doorVisuals.enabled = false;

			Debug.Log("opened");
		}

		if(isOpen == false)
		{
			doorCollider.enabled = true;
			doorVisuals.enabled = true;

			Debug.Log("closed");
		}
	}
}
