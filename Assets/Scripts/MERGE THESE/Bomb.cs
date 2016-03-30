using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float destroyTimer = 0f;
    public float destroyAfter = 1f;


    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (rb2d.velocity.x == 0 && rb2d.velocity.y == 0)
        {
            destroyTimer = destroyTimer + Time.deltaTime;
        }
        else if (rb2d.velocity.x != 0 && rb2d.velocity.y != 0)
        {
            destroyTimer = 0;
        }
        if (destroyTimer > destroyAfter)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(destroyTimer);
    }
}
