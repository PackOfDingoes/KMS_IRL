using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpellCasting : MonoBehaviour
{
    public Queue<int> spellPrep = new Queue<int>(3);
    private int spellComboMax = 3;
    private int[] preSpellToCast = new int[3];
    private string spellToCast = null;
	private Rigidbody2D rb2D;

	// Use this for initialization

	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
		Debug.DrawLine(this.transform.position, Input.mousePosition/2, Color.red);
	    if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellPrep.Enqueue(1);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spellPrep.Enqueue(2);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spellPrep.Enqueue(3);
        }
        for (int i = spellPrep.Count; i > spellComboMax ; i--)
        {
            spellPrep.Dequeue();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
        	CastSpell();
			spellPrep.Clear();
        }
    }

    void CastSpell()
    {
        spellPrep.CopyTo(preSpellToCast, 0);
        Array.Sort(preSpellToCast);

		spellToCast = null;

		if (spellPrep.Count > 0)
		{
	        foreach (int spellcast in preSpellToCast)
	        {
	            spellToCast += spellcast.ToString();
	        }
		}
		else if(spellPrep.Count == 0)
		{
			spellToCast = null;
		}

        if(spellToCast == "111")
        {
            Debug.Log("You cast spell 1");
        }
        if (spellToCast == "112")
        {
            Debug.Log("You cast spell 2");
        }
        if (spellToCast == "113")
        {
            Debug.Log("You cast spell 3");
        }
        if (spellToCast == "122")
        {
            Debug.Log("You cast spell 4");
        }
        if (spellToCast == "123")
        {
            Debug.Log("You cast spell 5");
        }
        if (spellToCast == "133")
        {
            Debug.Log("You cast spell 6");
        }
        if (spellToCast == "222")
        {
            Debug.Log("You cast spell 7");
        }
        if (spellToCast == "223")
        {
            Debug.Log("You cast spell 8");
			WindDash();
        }
        if (spellToCast == "233")
        {
            Debug.Log("You cast spell 9");
        }
        if (spellToCast == "333")
        {
            Debug.Log("You cast spell 10");
        }
		if (spellToCast == null)
		{
			Debug.Log("no spell");
		}
    }

	void WindDash()
	{
		Vector2 direction = (Input.mousePosition - this.transform.position).normalized;
		rb2D.AddForce(direction * 300);
	}
}
