using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{
	private GameObject player;
    private PlatformerCharacter2D playerCont;
	// Use this for initialization
	void Start ()
    {
		FindPlayer();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

	public void FindPlayer()
	{
		playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.tag == "Player")
		{
	        playerCont.onLadder = true;
	        playerCont.m_Rigidbody2D.velocity = new Vector2(0f, 0f);
		}
    }

    void OnTriggerExit2D(Collider2D other)
    {
		if(other.gameObject.tag == "Player")
		{
        	playerCont.onLadder = false;
		}

    }
}
