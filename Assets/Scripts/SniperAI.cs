using UnityEngine;
using System.Collections;

public class SniperAI : MonoBehaviour
{
    public Transform sniperScope;
    public Transform playerPos;
    private bool playerInSights = false;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        RayCast();
    }

    void RayCast()
    {
        playerInSights = Physics2D.Linecast(sniperScope.position, playerPos.position, 1 << LayerMask.NameToLayer("Ground"));
        if (playerInSights == false)
        {
            Debug.DrawLine(sniperScope.position, playerPos.position, Color.green);
        }
        if (playerInSights == true)
        {
            Debug.DrawLine(sniperScope.position, playerPos.position, Color.red);
        }
    }
}
