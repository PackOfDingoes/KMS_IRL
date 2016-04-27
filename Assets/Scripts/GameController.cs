using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{

	[HideInInspector]public bool cameraFollowPlayer = false;

	[HideInInspector]public SpellCasting spellCasting;
	[HideInInspector]public GameObject energyBar;
	private RectTransform energyBarSize;
	private Vector2 energyBarMax;

	void Awake ()
	{
		FindPlayer();
		energyBar = GameObject.FindGameObjectWithTag("Energy Bar");
		energyBarSize = energyBar.GetComponent<RectTransform>();
		energyBarMax = energyBarSize.sizeDelta;
	}

	void Start () 
	{
	
	}

	void Update () 
	{
		EnergyBar();
	}

	void EnergyBar()
	{
		float energyCurrent = spellCasting.energyCurrent;

		energyBarSize.sizeDelta = new Vector2(energyBarMax.x * energyCurrent/100, energyBarMax.y); 
	}

	public void FindPlayer()
	{
		spellCasting = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellCasting>();
	}
}
