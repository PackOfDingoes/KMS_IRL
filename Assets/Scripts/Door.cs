using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	private Collider2D doorCollider;
	private Renderer doorVisuals;
    public bool isActivated = false;
    //private bool isActivated = false;
    // Use this for initialization
    void Awake () 
	{
		doorCollider = this.GetComponent<Collider2D>();
		doorVisuals = this.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void OpenSeseme()
	{
		if (isActivated == true)
		{
			doorCollider.enabled = false;
			doorVisuals.enabled = false;

			Debug.Log("opened");
		}

		if(isActivated == false)
		{
			doorCollider.enabled = true;
			doorVisuals.enabled = true;

			Debug.Log("closed");
		}
	}
}
