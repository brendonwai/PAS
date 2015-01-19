using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	public GameObject audioSource;
	public GameObject audioSource2;

	public void waitLoad(){
		InvokeRepeating ("load", 0.5f, 0);
	}
	public void load() {
		Application.LoadLevel("SpawnScene");
	}
	public void waitQuit(){
		InvokeRepeating ("quit", 0.5f, 0);
	}
	public void quit (){
		Application.Quit();
	}
	public void waitMenu(){
		InvokeRepeating ("MainMenu", 0.5f, 0);
	}
	public void MainMenu (){
		Application.LoadLevel ("MAINMENU");
	}
	public void waitHowToPlay(){
		InvokeRepeating ("HowToPlay", 0.5f, 0);
	}
	public void HowToPlay (){
		Application.LoadLevel ("HowToPlay");
	}
	public void waitSinglePlayer(){
		InvokeRepeating ("loadSinglePlayer", 0.5f, 0);
	}
	public void loadSinglePlayer() {
		Application.LoadLevel("SinglerPlayer");
	}
	public void Song(){
		AudioSource sfx = audioSource.GetComponent<AudioSource> ();
		sfx.Play ();
		//System.Media.SoundPlayer player = new System.Media.SoundPlayer ();
		//player.SoundLocation = "/Sound/Select_Menu.wav";
		//player.Play ();
	}
	public void Sound2(){
		AudioSource sfx = audioSource2.GetComponent<AudioSource> ();
		sfx.Play ();
		//System.Media.SoundPlayer player = new System.Media.SoundPlayer ();
		//player.SoundLocation = "/Sound/Select_Menu.wav";
		//player.Play ();
	}

}
