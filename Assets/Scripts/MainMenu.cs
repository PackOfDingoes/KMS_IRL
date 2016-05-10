using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public string level1;
	public string level2;
	public string practiseLevel;
	void Awake () 
	{
	
	}

	void Update () 
	{
	
	}

	public void Level1()
	{
		SceneManager.LoadScene(level1);
	}
	public void Level2()
	{
		SceneManager.LoadScene(level2);
	}
	public void PractiseLevel()
	{
		SceneManager.LoadScene(practiseLevel);
	}
	public void Exit()
	{
		Application.Quit();
	}
}
