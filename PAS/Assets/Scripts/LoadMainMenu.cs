using UnityEngine;
using System.Collections;

public class LoadMainMenu : MonoBehaviour {

	//All this class does is immediately load the main menu- it seems that
	//the falling blocks in that scene don't always begin dropping if loaded first.

	//float initial_time;

	void Start () 
	{
		Application.LoadLevel("MAINMENU");
		//initial_time = Time.time;
	}

	/*void Update()
	{
		if (Time.time > initial_time + 20)

	}*/
}
