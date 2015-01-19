using UnityEngine;
using System.Collections;

public class ReturnToMenu : MonoBehaviour {

	// Use this for initialization
	public void returnToMenu()
	{
		Application.LoadLevel("MAINMENU");
		Debug.Log("squake");
	}

}
