using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //can load scenes

public class DataController : MonoBehaviour //because attached to game object
{
	public RoundData[] allRoundData;


	// Use this for initialization
	void Start () 
	{
		//when we load new scenes, the game object will persist
		DontDestroyOnLoad (gameObject);

		SceneManager.LoadScene ("MenuScreen");
	}
		
	public RoundData GetCurrentRoundData()
	{
		return allRoundData [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
