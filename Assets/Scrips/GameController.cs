﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 	

public class GameController : MonoBehaviour //because attached to game object
{

	public Text questionDisplayText;
	public Text scoreDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;

	private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int questionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		dataController = FindObjectOfType<DataController> ();
		currentRoundData = dataController.GetCurrentRoundData ();
		questionPool = currentRoundData.questions;
		timeRemaining = currentRoundData.timeLimitInSeconds;

		playerScore = 0;
		questionIndex = 0;

		showQuestion ();
		isRoundActive = true;
		
	}

	private void showQuestion() {
		RemoveAnswerButtons ();
		QuestionData questionData = questionPool [questionIndex];
		questionDisplayText.text = questionData.questionText;

		for (int i = 0; i < questionData.answers.Length; i++) {
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject ();
			answerButtonGameObjects.Add (answerButtonGameObject);
			answerButtonGameObject.transform.SetParent (answerButtonParent);

			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton> ();
			answerButton.Setup (questionData.answers [i]);
		}
	}

	private void RemoveAnswerButtons(){
		while (answerButtonGameObjects.Count > 0) {
			answerButtonObjectPool.ReturnObject (answerButtonGameObjects [0]);
			answerButtonGameObjects.RemoveAt (0);
		}
	}

	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect) 
		{
			playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = "Score: " + playerScore.ToString ();
		}
		if (questionPool.Length > questionIndex + 1) {
			questionIndex++;
			showQuestion ();
		} 
		else 
		{
			EndRound ();
		}

	}

	public void EndRound()
	{
		isRoundActive = false;

		questionDisplay.SetActive (false);
		roundEndDisplay.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
