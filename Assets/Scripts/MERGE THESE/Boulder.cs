using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour {

    private int bounceCount = 0;
    public int bounceMax = 3;
    public GameObject Nova;
    private bool makeBox = true;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(bounceCount);
	    if (bounceCount > bounceMax)
        {
            Destroy(this.gameObject);
        }
        if (bounceCount > 0 && makeBox == true)
        {
            StartCoroutine(CreateABoxForSomeReason(0.2f));
            makeBox = false;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        bounceCount++;
    }

    IEnumerator CreateABoxForSomeReason(float wait)
    {
        yield return new WaitForSeconds(wait);
        GameObject nova = Instantiate(Nova, this.transform.position, Quaternion.identity) as GameObject;
        nova.transform.parent = gameObject.transform;
    }
}
