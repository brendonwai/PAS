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
	int starLevel = 3;
	Play sound;
	multiplayerResults result;
	
	public GameObject starSpawner, explosionSpawner;
	ShootingStar shootingStar;
	//Explosion explosion;
	bool starSpawned;
	bool gotStar;
	
	// Use this for initialization
	void Start () {

		//initializes choice
		choice = -1;

		//creates all objects
		result = GameObject.Find ("multiplayerResults").GetComponent<multiplayerResults> ();
		sound = GameObject.Find ("SoundPlayer").GetComponent<Play>();
		generator = GameObject.Find ("Generators").GetComponent<Instantiate>();
		LB = GameObject.Find ("LeftButton").GetComponent <DisableButton> ();
		RB = GameObject.Find ("RightButton").GetComponent <DisableButton> ();
		lite = GameObject.Find ("Directional light").GetComponent<Light>();
		lvl = GameObject.Find ("LevelText").GetComponent <SingleScore> ();
		timersc = GameObject.Find ("TimerText").GetComponent <TimerScript> ();
		q = GameObject.Find ("QuestionText").GetComponent <Text> ();
		q.text = "";
		livestext = GameObject.Find ("LivesText").GetComponent<Text> ();
		shootingStar = starSpawner.GetComponent<ShootingStar> ();

		//initializes lives, levels and timer
		time = timersc.count;
		level = 1;
		lives = 3;
		livestext.text = "Lives " + lives.ToString ();
		state = 0;
		looktime = 5f;
	}
	
	void dimLite(){
		if (lite.intensity < 8) {
			lite.intensity += 0.25f;
		}
	}
	
	void litLite(){
		if (lite.intensity > 0.5) {
			GetComponent<Light>().intensity -= 0.25f;
		}
	}
	
	public void LeftButton(){
		choice =  0;
	}
	
	public void RightButton(){
		choice =  1;
	}
	
	void nextLevel(bool correct){
		increaseScore (correct);
		clearScreen ();
		livestext.text = "Lives " + lives.ToString ();
		if (looktime > 3) {
			looktime -= 0.1f;
		}
	}

	void increaseScore(bool correct){
		level += 1;
		lvl.uplvl ();
		if (correct) {
			sound.Song ();
			lvl.upscore (5);
		}else
			sound.Sound2 ();
	}
	void clearScreen(){
		state = 0;
		LB.changestate ();
		RB.changestate ();
		q.text = "";
		choosing = false;
		timersc.started = false;
		generator.clearShapes ();		
	}
	// Update is called once per frame
	void Update () {
		switch(state){
		//first stage that makes the question
		case 0:
			question ();
			break;
		//tells script to show blocks
		case 1: 
			displayBlockFall ();
			break;
		//takes the answer from the user
		case 2:
			guess ();
			break;
		}
	}	
	
	void question(){
		Question newQuestion = QG.getQuestion(level);
		checkMoreLess (newQuestion);
		generateQuestion (newQuestion);		
	}

	void checkMoreLess (Question currentQ){
		if (currentQ.quantity == "more")
			more = true;
		else
			more = false;
	}

	void generateQuestion(Question currentQ){
		if (currentQ.color == null && currentQ.shape == null)
			lvlquestion = "Which side has " + currentQ.quantity + " objects?";
		else if (currentQ.color == null && currentQ.shape != null) 
			lvlquestion = "Which side has " + currentQ.quantity + " " + currentQ.shape + "s?";
		else if (currentQ.shape == null && currentQ.color != null)
			lvlquestion = "Which side has " + currentQ.quantity + " " +  currentQ.color + "s?";
		else {	// Change the color of the font
			lvlquestion = "Which side has <size=45><color=black>" + currentQ.quantity;
			if (currentQ.color == "blue")
				lvlquestion = lvlquestion + "</color> <color=#00ffffff>" + currentQ.color + "</color> " + currentQ.shape + "</size>s?";
			else if (currentQ.color == "red")
				lvlquestion = lvlquestion + "</color> <color=red>" + currentQ.color + "</color> " + currentQ.shape + "</size>s?";
			else if (currentQ.color == "green")
				lvlquestion = lvlquestion + "</color> <color=#A9F5A9>" + currentQ.color + "</color> " + currentQ.shape + "</size>s?";
			else if (currentQ.color == "purple")
				lvlquestion = lvlquestion + "</color> <color=#8258FA>" + currentQ.color + "</color> " + currentQ.shape + "</size>s?";
			else if (currentQ.color == "yellow")
				lvlquestion = lvlquestion + "</color> <color=yellow>" + currentQ.color + "</color> " + currentQ.shape + "</size>s?";
		}
		string temp = currentQ.ratio.ToString();
		string numColors = currentQ.numColors.ToString ();
		string numShapes = currentQ.numShapes.ToString ();
		tally.SendMessage ("Load",new string[]{temp, currentQ.color, currentQ.shape, numColors, numShapes});
		state = 1;
	}

	void displayBlockFall(){
		startStar ();
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
	}
	void startStar(){
		if (level % 5 == 0) {
			System.Random r = new System.Random();
			this.starLevel = r.Next (level, level + 5);
		}
		
		if (level == starLevel && !starSpawned) {
			shootingStar.starFactory ();
			starSpawned = true;
		}
		if (Input.GetKey ("space") && (level == starLevel) && gotStar == false){
			gotStar = true;
			lvl.upscore (5);
			Vector3 lastPos = shootingStar.destroyStar();
			//explosion.explosionFactory(lastPos);
		}
	}
	
	void guess(){
		if (Input.GetKey("a"))
			choice = 0;
		if (Input.GetKey("d"))
			choice = 1;
		if (Input.GetKey("left"))
			choice = 0;
		if (Input.GetKey("right"))
			choice = 1;

		if (choosing == false) {
			choosing = true;
			LB.changestate ();
			RB.changestate ();
		}
		startQuestion ();
	}
	void startQuestion(){
		lvl.lvlText.text = "";
		q.text = lvlquestion;
		timersc.StartTimer ();
		time = timersc.count;
		checkTimer (time);
	}

	void checkTimer (int time){
		if (time > 0) {
			checkPlayerChoice();
		}else {
			if (lives == 1)
				GameOver ();
			else{
				lives--;
				nextLevel (false);
			}
		}
	}
	void checkPlayerChoice(){
		//gets if the player said the correct answer
		if (choice > -1){
			if ( tally.GetComponent<ObjectTally>().LeftMore== true){
				if (more == true)
					checkLives (ref lives, 0);
				else
					checkLives (ref lives, 1);
			}
			else{
				if (more == true)
					checkLives (ref lives, 1);
				else
					checkLives (ref lives, 0);
			}
		choice = -1;
		//choice is passed here
		}
	}
	void GameOver(){
		result.setWinner ("Game Over");
		Application.LoadLevel ("GameOver");
	}

	void checkLives (ref int currentLives, int cmp){
		//checks if the player ran out of lives, and if moves to the next level is answer is correct
		if (choice == cmp){
			nextLevel (true);
		}else{
			if (currentLives == 1)
				GameOver ();
			else{ 
				currentLives--;
				nextLevel (false);
			}
		}
	}
}


