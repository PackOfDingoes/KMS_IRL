using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public bool isSwitch;
	static public bool isActivated = false;
	private bool canActivate = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E) && canActivate == true)
		{
			isActivated = !isActivated;
			Debug.Log("isActivated = " + isActivated);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && isSwitch == false)
		{
			isActivated = !isActivated;

			Debug.Log("isActivated = " + isActivated);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && isSwitch == true)
		{
			canActivate = true;
		} 
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && isSwitch == true)
		{
			canActivate = false;
		} 
	}
}
