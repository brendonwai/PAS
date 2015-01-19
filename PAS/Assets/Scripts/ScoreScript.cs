using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreScript : MonoBehaviour {

	MainScript mainobj;
	string defaulttext = "Level ";
	public Text lvlText;
	public Text scoreText;
	public Text scoreText2;
	int level;
	public int score;
	public int score2;

	//call this when you level up/score up
	public void uplvl(){
		level = mainobj.level;
		lvlText.text = defaulttext + level.ToString ();
	}

	public void upscore(int newScore){
		score += newScore;
		scoreText.text = "Player1 " + score.ToString ();
	}

	public void upscore2(int newScore){
		score2 += newScore;
		scoreText2.text = "Player2 " + score2.ToString ();
	}


	// Use this for initialization
	void Start () {
		score = 0;
		score2 = 0;
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		scoreText2 = GameObject.Find ("ScoreText2").GetComponent<Text> ();
		mainobj = GameObject.Find ("MainObject").GetComponent<MainScript> ();
		level = mainobj.level;
		lvlText = GetComponent<Text> ();
		lvlText.text = defaulttext + level.ToString ();
		scoreText.text = "Player1 " + score.ToString ();
		scoreText2.text = "Player2 " + score2.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
