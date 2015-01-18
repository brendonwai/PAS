using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreScript : MonoBehaviour {

	MainScript mainobj;
	string defaulttext = "Level: ";
	public Text lvlText;
	int level;
	public int score;

	//call this when you level up/score up
	public void up(){
		level = mainobj.level;
		lvlText.text = defaulttext + level.ToString ();
	}

	// Use this for initialization
	void Start () {
		mainobj = GameObject.Find ("MainObject").GetComponent<MainScript> ();
		level = mainobj.level;
		lvlText = GetComponent<Text> ();
		lvlText.text = defaulttext + level.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
