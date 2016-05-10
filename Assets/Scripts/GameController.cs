using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{

	[HideInInspector]public bool cameraFollowPlayer = false;

	private SpellCasting spellCasting;

	private Canvas canvasUI;

	//energy bar
	private GameObject energyBar;
	private RectTransform energyBarSize;
	private Vector2 energyBarMax;

	//spell combo shit
	public Color[] comboColours = new Color[4];
	private int[] comboType = new int[3]{0,0,0};
	private GameObject[] comboPos = new GameObject[3];

	void Awake ()
	{
		FindPlayer();
		canvasUI = GameObject.Find("UI").GetComponent<Canvas>();
		canvasUI.worldCamera = this.gameObject.GetComponent<Camera>();
		energyBar = GameObject.FindGameObjectWithTag("Energy Bar");
		energyBarSize = energyBar.GetComponent<RectTransform>();
		energyBarMax = energyBarSize.sizeDelta;
		for(int i = 0; i<comboPos.Length; i++)
		{
			comboPos[i] = GameObject.Find("SpellCombo"+i);
		}

	}

	void Start () 
	{
	
	}

	void Update () 	
	{
		EnergyBar();
		SpellPrep();
	}

	void EnergyBar()
	{
		float energyCurrent = spellCasting.energyCurrent;

		energyBarSize.sizeDelta = new Vector2(energyBarMax.x * energyCurrent/100, energyBarMax.y); 
	}

	void SpellPrep()
	{
		Image comboImage;
		int arraySpot = 2;
		int arrayStart = 0;

		for(int i = 3; i>0; i--)
		{
			if(spellCasting.spellPrep.Count == i)
			{
				spellCasting.spellPrep.CopyTo(comboType,arrayStart);
			}
			arrayStart++;
		}

		for(int i = 0; i<3; i++)
		{
			comboImage = comboPos[arraySpot].GetComponent<Image>();
			arraySpot--;

			for(int u = 0; u<4; u++)
			{
				if(comboType[i] == u)
				{
					comboImage.color = comboColours[u];
				}
			}
		}
	}

	public void ClearSpellArray()
	{
		for (int i = 0; i<comboType.Length; i++)
		{
			comboType[i] = 0;
		}
	}

	public void FindPlayer()
	{
		spellCasting = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellCasting>();
	}
}
