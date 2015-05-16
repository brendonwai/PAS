using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {
	QuestionGenerator QG = new QuestionGenerator();
	ScoreScript lvl;
	public int level;
	bool p1;
	bool c1;
	bool p2;
	bool c2;
	TimerScript timersc;
	int time;
	Light lite;
	int state;
	int choice1;
	int choice2;
	Text shownQuestion;
	string lvlquestion;
	DisableButton LB;
	DisableButton TLB;
	DisableButton RB;
	DisableButton TRB;
	public GameObject tally;
	float timer0;
	bool falling;
	bool choosing;
	Instantiate generator;
	bool more;
	public float looktime;
	multiplayerResults result;
	Play sound;

	// Use this for initialization
	void Start () {

		//choice checks answers 
		choice1 = -1;
		choice2 = -1;

		//grabs all the objects, and sets them to variables
		sound = GameObject.Find ("SoundPlayer").GetComponent<Play>();
		result = GameObject.Find ("multiplayerResults").GetComponent<multiplayerResults> ();
		generator = GameObject.Find ("Generators").GetComponent<Instantiate>();
		TLB = GameObject.Find ("TopLeftButton").GetComponent <DisableButton> ();
		LB = GameObject.Find ("LeftButton").GetComponent <DisableButton> ();
		RB = GameObject.Find ("RightButton").GetComponent <DisableButton> ();
		TRB = GameObject.Find ("TopRightButton").GetComponent <DisableButton> ();
		lite = GameObject.Find ("Directional light").GetComponent<Light>();
		lvl = GameObject.Find ("LevelText").GetComponent <ScoreScript> ();
		timersc = GameObject.Find ("TimerText").GetComponent <TimerScript> ();
		shownQuestion = GameObject.Find ("QuestionText").GetComponent <Text> ();
		shownQuestion.text = "";

		time = timersc.count;
		level = 1;
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

	// Chooses the answer for touch controls
	public void TopLeftButton(){
		choice1 =  0;
	}

	public void LeftButton(){
		choice1 = 1;
	}

	public void TopRightButton(){
		choice2 =  1;
	}

	public void RightButton(){
		choice2 = 0;
	}

	void nextLevel(bool correct1, bool correct2){
		//increases level and level difficulty 
		increaseScore (correct1, correct2);
		clearScreen ();

		//reduce look timer and to increase difficulty
		if (looktime > 3) {
			looktime -= 0.1f;
		}
	}

	void increaseScore(bool player1Correct, bool player2Correct){
		//increases level and level difficulty 
		level += 1;
		lvl.uplvl ();
		if (player1Correct)
			lvl.upscore (5);
		if (player2Correct)
			lvl.upscore2 (5);
		if (level >= 10 && lvl.score != lvl.score2)
			GameOver ();                                         
	}

	void clearScreen(){
		clearPlayerInfo ();
		//state to tell what the game needs to do next
		state = 0;
		//cleans up buttons
		TLB.changestate ();
		LB.changestate ();
		TRB.changestate ();
		RB.changestate ();
		//clears question
		shownQuestion.text = "";
		//allow no one to choose answer
		choosing = false;
		//turn off timer
		timersc.started = false;
		//clear blocks on the screen for restart
		generator.clearShapes ();
	}

	void clearPlayerInfo(){
		//valid players
		p1 = false;
		p2 = false;
		//boolean to hold if the player choices correctly 
		c1 = false;
		c2 = false;
		//int to determine the choice 
		choice1 = -1;
		choice2 = -1;
	}

	// Update is called once per frame
	void Update () {
		switch(state){
			//create question
		case 0:
			question ();
			break;
			//create blocks
		case 1:
			displayBlockFall ();
			break;
			//answer question
		case 2:
			guess ();
			break;
		}
	}	
	//makes the question fo the game
	void question(){
		Question newQuestion = QG.getQuestion(level);
		checkMoreLess (newQuestion);
		generateQuestion (newQuestion);
	}
	//checks More or Less for the question
	void checkMoreLess (Question currentQ){
		if (currentQ.quantity == "more")
			more = true;
		else 
			more = false;
	}

	//Outs question and stores it;
    void generateQuestion(Question currentQ)
    {
        if (currentQ.color == null && currentQ.shape == null)
            lvlquestion = "Which side has " + currentQ.quantity + " objects?";
        else if (currentQ.color == null && currentQ.shape != null)
            lvlquestion = "Which side has " + currentQ.quantity + " " + currentQ.shape + "s?";
        else if (currentQ.shape == null && currentQ.color != null)
            lvlquestion = "Which side has " + currentQ.quantity + " " + currentQ.color + "s?";
        else
        {	// Change the color of the font
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
        string numColors = currentQ.numColors.ToString();
        string numShapes = currentQ.numShapes.ToString();
        tally.SendMessage("Load", new string[] { temp, currentQ.color, currentQ.shape, numColors, numShapes });
        state = 1;
    }

	//shows falling blocks to the screen
	void displayBlockFall(){
		if (falling == false) {
			falling = true;
			timer0 = Time.time;
		}
		if (Time.time - timer0 > looktime){
			falling = false;
			state = 2;
		}

	}


	void guess(){
		//assigns input to keys
		if (Input.GetKey("a") && p1 == false)
			choice1 = 0;
		if (Input.GetKey("d") && p1 == false)
			choice1 = 1;
		if (Input.GetKey("left") && p2 == false)
			choice2 = 0;
		if (Input.GetKey("right") && p2 == false)
			choice2 = 1;

		//flips to turn on buttons
		if (choosing == false) {
			choosing = true;
			TLB.changestate();
			LB.changestate ();
			TRB.changestate();
			RB.changestate ();
		}

		//outputs the question to the screen
		startQuestion ();
	}
	void startQuestion (){
		//starts timer and outputs the question similtaneously 
		lvl.lvlText.text = "";

		shownQuestion.text = lvlquestion;
		timersc.StartTimer ();
		time = timersc.count;
		CheckTimer (time);
	}
	//Checks to see if the game is over 
	void GameOver(){
		if (lvl.score > lvl.score2)
			result.setWinner ("Player 1 Wins");
		else
			result.setWinner ("Player 2 Wins");
		Application.LoadLevel ("GameOver");
	}

	void CheckTimer(int time){
		if (time > 0) {
			//player1
			checkPlayerChoice (ref choice1, ref p1, ref c1);
			//player2
			checkPlayerChoice (ref choice2, ref p2, ref c2);
		}else{
			if (level >= 10 && lvl.score != lvl.score2)
				GameOver ();
			else{
				nextLevel (c1,c2);
			}
		}
	}
	void checkPlayerChoice(ref int choice, ref bool player, ref bool validChoice){
		if (choice > -1 && player == false) {
			sound.Song ();
			if (tally.GetComponent<ObjectTally> ().LeftMore == true) {
				if (more == true) 
					flipChoice(ref choice, ref validChoice, 0);
				else
					flipChoice(ref choice, ref validChoice, 1);
			} else {
				if (more == true)
					flipChoice(ref choice, ref validChoice, 1);
				else 
					flipChoice(ref choice, ref validChoice, 0);
			}
			player = true;
			choice = -1;
		}
	}

	void flipChoice(ref int choice, ref bool validChoice, int cmp){
		if (choice == cmp)
			validChoice = true;
		else
			validChoice = false;
	}
}


