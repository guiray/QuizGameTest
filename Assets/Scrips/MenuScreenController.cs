using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //load a different scene

public class MenuScreenController : MonoBehaviour //because attached to game object
{

	public void StartGame() 
	{
		SceneManager.LoadScene("Game");
	}


}
