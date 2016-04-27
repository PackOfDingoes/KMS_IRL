using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{

	public bool cameraFollowPlayer = false;

	public SpellCasting spellCasting;

	public GameObject energyBar;
	private RectTransform energyBarSize;
	private Vector2 energyBarMax;

	void Awake ()
	{
		spellCasting = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellCasting>();
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
}
