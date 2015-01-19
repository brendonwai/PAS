using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SingleMain : MonoBehaviour {
	QuestionGenerator QG = new QuestionGenerator();
	SingleScore lvl;
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
	public GameObject tally;
	float timer0;
	bool falling;
	bool choosing;
	Instantiate generator;
	bool more;
	public float looktime;
	Text livestext;
	int starLevel;
	
	public GameObject starSpawner, explosionSpawner;
	ShootingStar shootingStar;
	//Explosion explosion;
	bool starSpawned;
	bool gotStar;
	
	// Use this for initialization
	void Start () {
		choice = -1;
		generator = GameObject.Find ("Generators").GetComponent<Instantiate>();
		LB = GameObject.Find ("LeftButton").GetComponent <DisableButton> ();
		RB = GameObject.Find ("RightButton").GetComponent <DisableButton> ();
		lite = GameObject.Find ("Directional light").GetComponent<Light>();
		lvl = GameObject.Find ("LevelText").GetComponent <SingleScore> ();
		timersc = GameObject.Find ("TimerText").GetComponent <TimerScript> ();
		q = GameObject.Find ("QuestionText").GetComponent <Text> ();
		q.text = "";
		livestext = GameObject.Find ("LivesText").GetComponent<Text> ();
		time = timersc.count;
		level = 1;
		lives = 3;
		livestext.text = "Lives " + lives.ToString ();
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
	
	public void LeftButton(){
		choice =  0;
	}
	
	public void RightButton(){
		choice =  1;
	}
	
	void nextLevel(bool correct){
		level += 1;
		lvl.uplvl ();
		if (correct)
			lvl.upscore (5);
		state = 0;
		LB.changestate ();
		RB.changestate ();
		q.text = "";
		choosing = false;
		timersc.started = false;
		generator.clearShapes ();
		livestext.text = "Lives " + lives.ToString ();
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
		if (level % 5 == 0) {
			System.Random r = new System.Random();
			this.starLevel = r.Next (level, level + 5);
		}
		if (level == starLevel && !starSpawned) {
				shootingStar.starFactory ();
				starSpawned = true;
		}
		if (Input.GetKey ("space") && level % 2 == 0 && gotStar == false){
				gotStar = true;
				lvl.upscore (5);
				Vector3 lastPos = shootingStar.destroyStar();
				//explosion.explosionFactory(lastPos);
		}
		if (falling == false) {
			falling = true;
			timer0 = Time.time;
		}
		if (Time.time - timer0 > looktime){
			if (starSpawned && level % 2 != 0)
				starSpawned = false;
			gotStar = false;
			falling = false;
			state = 2;
		}
		//litLite ();
		//dimLite ();
	}
	
	void guess(){
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
			if (choice > -1){
				if ( tally.GetComponent<ObjectTally>().LeftMore== true){
					if (more == true){
						if (choice == 0){
							nextLevel (true);
						}
						else{
							if (lives == 1)
								GameOver ();
							else 
								lives--;
							nextLevel(false);
						}
					}
					else{
						if (choice == 1){
							nextLevel (true);
						}
						else{
							if (lives == 1)
								GameOver();
							else{
								lives--;
								nextLevel(false);
							}
						}
					}
				}
				else{
					if (more == true){
						if (choice == 1){
							nextLevel (true);
						}
						else{
							if (lives == 1)
								GameOver ();
							else {
								lives--;
								nextLevel(false);
							}
						}
					}
					else{
						if (choice == 0){
							nextLevel (true);
						}
						else{
							if (lives == 1)
								GameOver ();
							else{ 
								lives--;
								nextLevel (false);
							}
						}
					}
				}
				choice = -1;
				//choice is passed here
			}
		}
		else {
			if (lives == 1)
				GameOver ();
			else{
				lives--;
				nextLevel (false);
			}
		}
	}
	
	void GameOver(){
		Application.LoadLevel ("GameOver");
	}
	
}


