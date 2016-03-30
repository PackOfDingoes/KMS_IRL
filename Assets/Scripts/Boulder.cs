using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour 
{
	private int bounceCount = 0;
	public int bounceMax = 3;
	private Rigidbody2D rb2D;
	private Ray mousePos;

	// Use this for initialization
	void Start () 
	{
		rb2D = GetComponent<Rigidbody2D>();
		mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
		rb2D.AddForce(mousePos.direction * 3000);
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (bounceCount > bounceMax)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		bounceCount++;
	}
}
