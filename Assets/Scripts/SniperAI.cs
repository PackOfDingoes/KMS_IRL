using UnityEngine;
using System.Collections;

public class SniperAI : MonoBehaviour
{
    public Transform sniperScope;
    public Transform playerPos;
    private bool shoot = false;
    public float sniperRange = 15f;
    //private bool playerInSights = false;

    // Use this for initialization
    void Start ()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(shoot);
        RayCast();
    }

    void RayCast()
    {
        //casts ray from sniperscope to player pos (-sniperScope.position + playerPos.position) = player direction
        RaycastHit2D playerInSights = Physics2D.Raycast(sniperScope.position, -sniperScope.position + playerPos.position, sniperRange);
        if (playerInSights.collider !=null )
        {
            //Debug.DrawLine(sniperScope.position, playerInSights.point, Color.red);
            if (playerInSights.collider.tag == "Player")
            {
                shoot = true;
            }
            if (playerInSights.collider.tag != "Player")
            {
                shoot = false;
            }
        }
        if (playerInSights.collider == null)
        {
            shoot = false;
        }
    }
}
