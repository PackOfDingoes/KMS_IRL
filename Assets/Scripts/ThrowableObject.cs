using UnityEngine;
using System.Collections;

public class ThrowableObject: MonoBehaviour 
{
	private Rigidbody2D rb2D;
	private Ray mousePos;

	public bool thrownFromPlayer;
	public int throwForce = 3000;
	public float destroyAfter = 3f;
	private float destroyTimer = 0f;

	[HideInInspector]public bool hasCone = false;
	[HideInInspector]public float[] coneWidth = new float[2]{-15, 15};

	public bool destroyOnStill;
	private float stillDestroyTimer = 0f;
	public float stillDestroyAfter = 3f;

	public bool destroyOnBounches;
	private int bounceCount = 0;
	public int bounceMax = 3;

	public bool destroyOnTaggedTouch;
	public string[] destroyTags;
	public bool destroySelf;
	public bool destroyOther;

	// Use this for initialization
	void Start () 
	{
		rb2D = GetComponent<Rigidbody2D>();
		if(thrownFromPlayer == true)
		{
			mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (hasCone == false)
			{
				rb2D.AddForce(mousePos.direction * throwForce);
			}

			if (hasCone == true)
			{
				rb2D.AddForce(new Vector3(mousePos.direction.x + Random.Range(coneWidth[0], coneWidth[1]), mousePos.direction.y + Random.Range(coneWidth[0], coneWidth[1]),0f) * throwForce);
			}
		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		destroyTimer += Time.deltaTime;

		if (destroyOnStill == true)
		{
			if (rb2D.velocity.x == 0 && rb2D.velocity.y == 0)
			{
				stillDestroyTimer += Time.deltaTime;
			}
			else if (rb2D.velocity.x != 0 && rb2D.velocity.y != 0)
			{
				stillDestroyTimer = 0;
			}
			if (stillDestroyTimer > stillDestroyAfter)
			{
				Destroy(this.gameObject);
			}
		}


		if (destroyTimer >= destroyAfter)
		{
			Destroy(this.gameObject);
		}

		if (bounceCount > bounceMax && destroyOnBounches == true)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		bounceCount++;

		if (destroyOnTaggedTouch == true)
		{
			foreach(string objectTouched in destroyTags)
			{
				if(other.gameObject.tag == objectTouched)
				{
					if (destroySelf == true)
					{
						Destroy(this.gameObject);
					}
					if (destroyOther == true)
					{
						Destroy(other.gameObject);
					}
				}
			}
		}
	}
}
