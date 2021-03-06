﻿using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{

	[HideInInspector]public bool cameraFollowPlayer = false;

	private SpellCasting spellCasting;
	private PlatformerCharacter2D playerCont;
	private Canvas canvasUI;
	private GameObject paused;
	public bool isPaused = false;
    private GameObject resumeButton;
	public bool playerIsDead = false;

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
		paused = GameObject.Find("Paused");
        resumeButton = GameObject.Find("Resume");
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
		ToggleMenu(false);
	}

	void Update () 	
	{
		if (playerIsDead == false)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ToggleMenu(!isPaused);
			}
		}
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
	public void FuckThis(float seconds)
	{
		StartCoroutine(KillPlayer(seconds));
	}
	IEnumerator KillPlayer(float DeathCamTime)
	{
		playerIsDead = true;
		playerCont.playerIsDead = true;
		yield return new WaitForSeconds(DeathCamTime);
		ToggleMenu(true);
		GameObject.Find("PausedText").GetComponent<Text>().text = "You Died";
        resumeButton.SetActive(false);
    }
    public void FinishLevel()
	{
		ToggleMenu(true);
		GameObject.Find("PausedText").GetComponent<Text>().text = "Level Complete!";
		resumeButton.SetActive(false);
	}

	public void Resume()
	{
		ToggleMenu(false);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Restart()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	private void ToggleMenu(bool showMenu) 
	{
		if (showMenu == true) 
		{
			Time.timeScale = 0.0f;
			paused.SetActive(true);
			isPaused = true;
		} 

		else 
		{
			Time.timeScale = 1.0f;
			paused.SetActive(false);
			isPaused = false;
		}
	}

	public void FindPlayer()
	{
		spellCasting = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellCasting>();
		playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();
	}
}
