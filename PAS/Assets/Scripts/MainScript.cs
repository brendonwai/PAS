using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {
	QuestionGenerator QG = new QuestionGenerator();
	ScoreScript score;
	public int level;
	public int lives;
	TimerScript timersc;
	int time;
	Light lite;
	int state;
	int choice;
	Text q;
	string lvlquestion;
	
	// Use this for initialization
	void Start () {
		lite = GameObject.Find ("Directional light").GetComponent<Light>();
		score = GameObject.Find ("LevelText").GetComponent <ScoreScript> ();
		timersc = GameObject.Find ("TimerText").GetComponent <TimerScript> ();
		q = GameObject.Find ("QuestionText").GetComponent <Text> ();
		//livestext = GameObject.Find ("LivesText").GetComponent<Text> ();
		time = timersc.count;;
		level = 1;
		//		lives = 3;
		//livestext.text = "";//lives.ToString ();
		state = 0;
		
	}
	
	void dimLite(){
		if (lite.intensity < 8) {
			lite.intensity += 0.25f;
		}
	}
	
	void litLite(){
		if (lite.intensity > 0.5) {
			light.intensity -= 0.25f;
		}
	}
	
	public void LeftButton(){
		choice =  0;
	}
	
	public void RightButton(){
		choice =  1;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0) {
			question ();
		}
		if (state == 1) {
			displayBlockFall ();
		}
		if (state == 2) {
			guess ();
		}
	}	
	
	void question(){
		Question newQuestion = QG.getQuestion(level);
		if (newQuestion.color == null && newQuestion.shape == null)
			lvlquestion = "Which side has " + newQuestion.quantity + " objects?";
		else if (newQuestion.color == null && newQuestion.shape != null) 
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.shape + "s?";
		else if (newQuestion.shape == null && newQuestion.color != null)
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.color + "s?";
		else 
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.color + " " + newQuestion.shape + "s?";
		state = 1;
	}
	
	void displayBlockFall(){
		//litLite ();
		dimLite ();
		state = 2;
	}
	
	void guess(){
		q.text = lvlquestion;
		timersc.StartTimer ();
		time = timersc.count;
		if (time > 0) {
			if (choice > -1){
				level += 1;
				score.up ();
				//choice is passed here
			}
		}
		else {
			GameOver ();
		}
		state = 0;
	}
	
	void GameOver(){
		Application.LoadLevel ("GameOver");
	}
	
}


