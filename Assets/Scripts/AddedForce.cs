﻿using UnityEngine;
using System.Collections;

public class AddedForce : MonoBehaviour
{
    public bool isConstantForce = false;
    public float forceAmount = 30f;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (isConstantForce == false)
        {
            BROOMBROOM(forceAmount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isConstantForce == true)
        {
            BROOMBROOM(forceAmount);
        }
    }

    void BROOMBROOM(float forceAmount)
    {
		rb2d.velocity = transform.right * -forceAmount;
    }
}
