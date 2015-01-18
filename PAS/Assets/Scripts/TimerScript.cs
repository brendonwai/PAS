using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TimerScript : MonoBehaviour {
	
	string text;
	Text TimerText;
	float time;
	public int startCount = 5;
	public int count;
	bool started;
	
	// Use this for initialization
	void Start(){
		startCount = 5;
		started = false;
	}
	
	public void StartTimer () {
		if (started != true) {
			started = true;
			count = startCount;
			TimerText = GetComponent<Text> ();
			TimerText.text = "Pick a Side!\n" + count.ToString ();
			time = Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - time > 1){
			count -= 1;
			time = Time.time;
			if (count > 0){
				text = count.ToString ();
			}
			else{
				text = "";
				if (count < -2){
					started = false;
				}
			}
			TimerText.text = "Pick a Side!\n" + text;
		}
	}
	
	void Do(){
		//Do whatever happens when timer goes to zero
	}
}