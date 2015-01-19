using UnityEngine;
using System.Collections;

public class multiplayerResults : MonoBehaviour {

	public string winner = "GAME OVER";

	// Use this for initialization
	void Start () {

		Object.DontDestroyOnLoad(this.gameObject);
	}

	
	public void setWinner(string playerName)
	{
		winner = playerName;	
	}

}
