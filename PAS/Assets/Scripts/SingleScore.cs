using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SingleScore : MonoBehaviour {
	
	SingleMain mainobj;
	string defaulttext = "Level ";
	public Text lvlText;
	public Text scoreText;
	int level;
	public int score;
	
	//call this when you level up/score up
	public void uplvl(){
		level = mainobj.level;
		lvlText.text = defaulttext + level.ToString ();
	}
	
	public void upscore(int newScore){
		score += newScore;
		scoreText.text = "Score " + score.ToString ();
	}
	
	// Use this for initialization
	void Start () {
		score = 0;
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		mainobj = GameObject.Find ("MainObject").GetComponent<SingleMain> ();
		level = mainobj.level;
		lvlText = GetComponent<Text> ();
		lvlText.text = defaulttext + level.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
