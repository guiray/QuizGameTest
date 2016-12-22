using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour //because attached to game object
{
	//store reference to the button text
	public Text answerText;

	private AnswerData answerData;

	// Use this for initialization
	void Start () {
		
	}

	public void Setup(AnswerData data){
		answerData = data;

		answerText.text = answerData.answerText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
