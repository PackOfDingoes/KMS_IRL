using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    private PlatformerCharacter2D playerCont;
	// Use this for initialization
	void Start ()
    {
        playerCont = player.GetComponent<PlatformerCharacter2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        playerCont.onLadder = true;
        playerCont.m_Rigidbody2D.velocity = new Vector2(0f, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerCont.onLadder = false;
    }
}
