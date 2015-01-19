using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {
	QuestionGenerator QG = new QuestionGenerator();
	ScoreScript lvl;
	public int level;
	int lives;
	int lives2;
	bool p1;
	bool c1;
	bool p2;
	bool c2;
	TimerScript timersc;
	int time;
	Light lite;
	int state;
	int choice;
	int choice2;
	Text q;
	string lvlquestion;
	DisableButton LB;
	DisableButton RB;
	public GameObject tally;
	float timer0;
	bool falling;
	bool choosing;
	Instantiate generator;
	bool more;
	public float looktime;
	Text livestext;

	public GameObject starSpawner;
	ShootingStar shootingStar;
	bool starSpawned;

	// Use this for initialization
	void Start () {
		choice = -1;
		choice2 = -1;
		generator = GameObject.Find ("Generators").GetComponent<Instantiate>();
		LB = GameObject.Find ("LeftButton").GetComponent <DisableButton> ();
		RB = GameObject.Find ("RightButton").GetComponent <DisableButton> ();
		lite = GameObject.Find ("Directional light").GetComponent<Light>();
		lvl = GameObject.Find ("LevelText").GetComponent <ScoreScript> ();
		timersc = GameObject.Find ("TimerText").GetComponent <TimerScript> ();
		q = GameObject.Find ("QuestionText").GetComponent <Text> ();
		q.text = "";
		time = timersc.count;
		level = 1;
		state = 0;
		shootingStar = starSpawner.GetComponent<ShootingStar> ();
		looktime = 5f;
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
	
//	public void LeftButton(){
//		choice =  0;
//	}
//	
//	public void RightButton(){
//		choice =  1;
//	}

	void nextLevel(bool correct1, bool correct2){
		level += 1;
		lvl.uplvl ();
		if (correct1)
			lvl.upscore (5);
		if (correct2)
			lvl.upscore2 (5);
		state = 0;
		LB.changestate ();
		RB.changestate ();
		q.text = "";
		choosing = false;
		timersc.started = false;
		generator.clearShapes ();
		if (looktime > 3) {
			looktime -= 0.1f;
			}
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
		if (newQuestion.quantity == "more") {
			more = true;
		} 
		else {
			more = false;
		}


		if (newQuestion.color == null && newQuestion.shape == null)
			lvlquestion = "Which side has " + newQuestion.quantity + " objects?";
		else if (newQuestion.color == null && newQuestion.shape != null) 
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.shape + "s?";
		else if (newQuestion.shape == null && newQuestion.color != null)
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.color + "s?";
		else 
			lvlquestion = "Which side has " + newQuestion.quantity + " " + newQuestion.color + " " + newQuestion.shape + "s?";
		string temp =newQuestion.creationRatio.ToString();
		tally.SendMessage ("Load",new string[]{temp, newQuestion.color, newQuestion.shape});
		state = 1;
	}
	
	void displayBlockFall(){
		if (level % 2 == 0 && !starSpawned) {
			shootingStar.starFactory();
			starSpawned = true;
		}
		if (starSpawned)
						starSpawned = false;
		if (falling == false) {
			falling = true;
			timer0 = Time.time;
		}
		if (Time.time - timer0 > looktime){
			falling = false;
			state = 2;
		}
		//litLite ();
		//dimLite ();
	}
	
	void guess(){
		if (Input.GetKey("a"))
			choice = 0;
		if (Input.GetKey("d"))
			choice = 1;
		if (Input.GetKey("left"))
			choice2 = 0;
		if (Input.GetKey("right"))
			choice2 = 1;
		
		if (choosing == false) {
			choosing = true;
			LB.changestate ();
			RB.changestate ();
				}
		lvl.lvlText.text = "";
		q.text = lvlquestion;
		timersc.StartTimer ();
		time = timersc.count;
		if (time > 0) {
						if (choice > -1 && p1 == false) {
								if (tally.GetComponent<ObjectTally> ().LeftMore == true) {
										if (more == true) {
												if (choice == 0) {
														c1 = true;
												} else {
														c1 = false;
												}
										} else {
												if (choice == 1) {
														c1 = true;
												} else {
														c1 = false;
												}
										}
								} else {
										if (more == true) {
												if (choice == 1) {
														c1 = true;
												} else {
														c1 = false;
												}
										} else {
												if (choice == 0) {
														c1 = true;
												} else {
														c1 = false;
												}
										}
								}
								p1 = true;
								choice = -1;
						}
						//player2
						if (choice2 > -1 && p2 == false) {
								if (tally.GetComponent<ObjectTally> ().LeftMore == true) {
										if (more == true) {
												if (choice2 == 0) {
														c2 = true;
												} else {
														c2 = false;
												}
										} else {
												if (choice2 == 1) {
														c2 = true;
												} else {
														c2 = false;
												}
										}
								} else {
										if (more == true) {
												if (choice2 == 1) {
														c2 = true;
												} else {
														c2 = false;
												}
										} else {
												if (choice2 == 0) {
														c2 = true;
												} else {
														c2 = false;
												}
										}
								}
				p2 = true;
								choice2 = -1;
						}
				}
		else {
			if (level > 10 && lvl.score != lvl.score2)
				GameOver ();
			else{
				nextLevel (c1,c2);
			}
		}
	}
	
	void GameOver(){
		Application.LoadLevel ("GameOver");
	}
	
}


