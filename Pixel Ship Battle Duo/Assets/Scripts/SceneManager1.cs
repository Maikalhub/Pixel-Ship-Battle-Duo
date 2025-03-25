using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager1 : MonoBehaviour
{

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}



	public void ExitGame()
	{
		Debug.Log("Exit");
		Application.Quit();
	}



	public void reMenu()
	{
		SceneManager.LoadScene("Menu");
	}

    public void rePreMenu() 
	{
		SceneManager.LoadScene("PreMenu");

	}



	public void reStartGame() 
	{
		SceneManager.LoadScene("Game");
	}


}
