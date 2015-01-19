using UnityEngine;
using System.Collections;

public class ReturnToMenu : MonoBehaviour {

	// Use this for initialization
	public void wait(){
		InvokeRepeating ("returnToMenu", 0.5f, 0);
	}
	public void returnToMenu()
	{
		Application.LoadLevel("MAINMENU");
		Debug.Log("squake");
	}

}
