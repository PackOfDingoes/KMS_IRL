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
	private Ray mousePos;
	public Transform frontSpawn;
	public Transform backSpawn;
	private PlatformerCharacter2D playerCont;

	public float dashTime = 0.5f;
	public float windDashStrength = 1500f;
	public bool isWindDashing = false;

	public GameObject rock;

	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
		playerCont = GetComponent<PlatformerCharacter2D>();
	}

	void Start ()
    {
	    
	}
	
	void Update ()
    {
		mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
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

        if (Input.GetMouseButtonDown(0))
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

		if (spellPrep.Count >= preSpellToCast.Length)
		{
	        foreach (int spellcast in preSpellToCast)
	        {
	            spellToCast += spellcast.ToString();
	        }
		}
		else if(spellPrep.Count < preSpellToCast.Length)
		{

			spellToCast = "000";
			for (int i = 0; i<preSpellToCast.Length; i++)
			{
				preSpellToCast[i] = 0;
			}
		}

		switch (spellToCast)
		{
			case "111":
				Debug.Log("You cast spell 1");
				break;
			case "112":
				Debug.Log("You cast spell 2");
				break;
			case "113":
				Debug.Log("You cast spell 3");
				break;
			case "122":
				Debug.Log("You cast spell 4");
				break;
			case "123":
				Debug.Log("You cast spell 5");
				break;
			case "133":
				Debug.Log("You cast spell 8");
				break;
			case "222":
				Debug.Log("You cast Rock");
				Rock();
				break;
			case "223":
				Debug.Log("You cast Wind Dash");
				StartCoroutine(WindDash(dashTime));
				break;
			case "233":
				Debug.Log("You cast spell 0");
				break;
			case "333":
				Debug.Log("You cast spell 10");
				break;
			case "000":
				Debug.Log("ain't not spell nigga");
				break;
			default:
				Debug.Log("this isn't possible");
				break;
		}
    }

	IEnumerator WindDash(float dashingTime)
	{
		isWindDashing = true;
		rb2D.AddForce(mousePos.direction * windDashStrength);
		yield return new WaitForSeconds(dashingTime);
		isWindDashing = false;
	}

	void Rock()
	{
		if (mousePos.direction.x >=0 && playerCont.m_FacingRight == true || mousePos.direction.x < 0 && playerCont.m_FacingRight == false)
		{
			Instantiate(rock, frontSpawn.position, this.transform.rotation);
		}
		if (mousePos.direction.x < 0 && playerCont.m_FacingRight == true || mousePos.direction.x >=0 && playerCont.m_FacingRight == false)
		{
			Instantiate(rock, backSpawn.position, this.transform.rotation);
		}
	}
}
