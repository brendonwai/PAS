using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreScript : MonoBehaviour {

	MainScript mainobj;
	string defaulttext = "Level: ";
	Text ScoreText;
	int level;

	//call this when you level up/score up
	public void up(){
		level = mainobj.level;
		ScoreText.text = defaulttext + level.ToString ();
	}

	// Use this for initialization
	void Start () {
		mainobj = GameObject.Find ("MainObject").GetComponent<MainScript> ();
		level = mainobj.level;
		ScoreText = GetComponent<Text> ();
		ScoreText.text = defaulttext + level.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
