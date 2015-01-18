using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TimerScript : MonoBehaviour {
	
	string text;
	Text TimerText;
	float time;
	int startCount = 5;
	public int count;
	public bool started;
	
	// Use this for initialization
	void Start(){
		startCount = 5;
		count = -5;
		started = false;
		TimerText = GetComponent<Text> ();
	}
	
	public void StartTimer () {
		if (started != true) {
			started = true;
			startCount = 5;
			count = startCount;
			TimerText.text = "Pick a Side!\n" + count.ToString ();
			time = Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (count);
		if (Time.time - time > 1){
			count -= 1;
			time = Time.time;
			if (count > 0){
				TimerText.text = "Pick a Side!\n" + count.ToString ();
			}
			else{
				text = "";
				if (count < -2){
					started = false;
				}
			}
		}
	}
	
	void Do(){
		//Do whatever happens when timer goes to zero
	}
}