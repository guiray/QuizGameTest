using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //enable to edit and display valuesin unity inspector
public class RoundData 
{
	public string name;
	public int timeLimitInSeconds;
	public int pointsAddedForCorrectAnswer;
	public QuestionData[] questions;
}
