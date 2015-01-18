using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	QuestionGenerator QG = new QuestionGenerator();
	GameObject levelobj;
	ScoreScript score;
	public int level = 1;
	GameObject timerobj;
	TimerScript timersc;
	int time;

	// Use this for initialization
	void Start () {
		levelobj = GameObject.Find ("LevelText");
		score = levelobj.GetComponent <ScoreScript> ();
		timerobj = GameObject.Find ("TimerText");
		timersc = timerobj.GetComponent <TimerScript> ();
		time = timersc.count;
	}
	
	// Update is called once per frame
	void Update () {
		question ();
		displayBlockFall ();
		guess ();
	}

	void question(){
		Question newQuestion = QG.getQuestion(level);
		Debug.Log (newQuestion.color.ToString ());
		}

	void displayBlockFall(){
		}

	void guess(){
		timersc.StartTimer ();
		time = timersc.count;
		if (time > 0) {
				}
		else {
			Application.LoadLevel ("GameOver");
			level += 1;
			score.up ();
			}
		}

}
