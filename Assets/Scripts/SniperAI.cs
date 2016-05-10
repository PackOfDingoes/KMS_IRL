using UnityEngine;
using System.Collections;

public class SniperAI : MonoBehaviour
{
    public GameObject sniperScope;
	private Quaternion rotation;
    public Transform playerPos;
    private bool shoot = false;
    public float sniperRange = 15f;
	public float fireRate;
	private bool reloading = false;
	public GameObject bullet;
    //private bool playerInSights = false;

    // Use this for initialization
    void Start ()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update ()
    {   
		rotation = Quaternion.LookRotation(playerPos.transform.position-sniperScope.transform.position,sniperScope.transform.TransformDirection(Vector3.up));
		sniperScope.transform.rotation = new Quaternion(0,0,rotation.z,rotation.w);

        RayCast();
		if (shoot == true)
		{
			StartCoroutine(ShotsFired(fireRate));
		}
    }

    void RayCast()
    {
        //casts ray from sniperscope to player pos (-sniperScope.transform.position + playerPos.position) = player direction
        RaycastHit2D playerInSights = Physics2D.Raycast(sniperScope.transform.position, -sniperScope.transform.position + playerPos.position, sniperRange);
		if (playerInSights.collider != null)
        {
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

	IEnumerator ShotsFired(float fireRate)
	{
		if (reloading == false)
		{
			Instantiate(bullet, sniperScope.transform.position,new Quaternion(0,0,rotation.z,rotation.w));
			reloading = true;

			yield return new WaitForSeconds(fireRate);

			reloading = false;
		}
	}
}
