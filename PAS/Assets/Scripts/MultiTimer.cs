using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MultiTimer : MonoBehaviour {

	public Text TimerText2;
	float time;
	int startCount = 5;
	public int count;
	public bool started;
	
	// Use this for initialization
	void Start(){
		startCount = 5;
		count = -5;
		started = false;
		TimerText2 = GetComponent<Text> ();
	}
	
	public void StartTimer () {
		if (started != true) {
			started = true;
			startCount = 5;
			count = startCount;
			TimerText2.text = "Pick a Side!\n" + count.ToString ();
			time = Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (count);
		if (started == true) {
						if (Time.time - time > 1) {
								count -= 1;
								time = Time.time;
								if (count > -1) {
										TimerText2.text = "Pick a Side!\n" + count.ToString ();
								} else {
										TimerText2.text = "";
										started = false;
								}
						}
				} else {
			TimerText2.text = "";
				}

				}
}