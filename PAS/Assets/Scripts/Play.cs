using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	public void load() {
		Application.LoadLevel("SpawnScene");
	}
	public void quit (){
		Application.Quit();
	}
	public void MainMenu (){
		Application.LoadLevel ("MAINMENU");
	}
	public void HowToPlay (){
		Application.LoadLevel ("HowToPlay");
	}
	public void loadSinglePlayer() {
		Application.LoadLevel("SinglerPlayer");
	}
}
