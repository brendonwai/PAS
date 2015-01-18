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
	DisableButton LB;
	DisableButton RB;
	GameObject tally;
	
	// Use this for initialization
	void Start () {
		choice = -1;
		tally = GameObject.Find ("ObjTally");
		LB = GameObject.Find ("LeftButton").GetComponent <DisableButton> ();
		RB = GameObject.Find ("RightButton").GetComponent <DisableButton> ();
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
		Question newQuestion = QG.getQuestion(10);
		if (newQuestion.color == null && newQuestion.shape == null)
			lvlquestion = "Which side has " + newQuestion.quantity + " objects?";
		else if (newQuestion.color == null && newQuestion.shape != null) 
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.shape + "s?";
		else if (newQuestion.shape == null && newQuestion.color != null)
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.color + "s?";
		else 
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.color + " " + newQuestion.shape + "s?";
		tally.SendMessage ("Load",newQuestion.creationRatio, newQuestion.color, newQuestion.shape);
		state = 1;
	}
	
	void displayBlockFall(){
		//litLite ();
		dimLite ();
		state = 2;
	}
	
	void guess(){
		//fLB.changestate ();
		//RB.changestate ();
		q.text = lvlquestion;
		timersc.StartTimer ();
		time = timersc.count;
		if (time > 0) {
			if (choice > -1){
				if (tally.GetComponent<LeftMore>() == true){
					if (choice == 0){
						level += 1;
						score.up ();
					}
					else{
						GameOver ();
					}
				}
				else{
					if (choice == 1){
						level += 1;
						score.up ();
					}
					else{
						GameOver ();
					}
				}
				choice = -1;
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


