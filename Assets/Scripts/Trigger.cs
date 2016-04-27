using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public bool isSwitch;
	private bool canActivate = false;
	public GameObject[] door;
    private Door doorScript;

	// Use this for initialization
	void Start () 
	{


        for (int i = 0; i < door.Length; i++)
        {
            doorScript = door[i].GetComponent<Door>();
            doorScript.OpenSeseme();
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E) && canActivate == true)
		{
            for (int i = 0; i < door.Length; i++)
            {
                doorScript = door[i].GetComponent<Door>();
                doorScript.isActivated = !doorScript.isActivated;
                doorScript.OpenSeseme();
            }
        }
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && isSwitch == false || other.gameObject.tag == "Heavy Object" && isSwitch == false)
		{
            for (int i = 0; i < door.Length; i++)
            {
                doorScript = door[i].GetComponent<Door>();
                doorScript.isActivated = !doorScript.isActivated;
                doorScript.OpenSeseme();
            }
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
