using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class findMultiplayerResults : MonoBehaviour {

	GameObject persistentGameObject;
	public GameObject UItext;


	// Use this for initialization
	void Start () {
		persistentGameObject = GameObject.Find("multiplayerResults");

		multiplayerResults mp = persistentGameObject.GetComponent<multiplayerResults>();

		
		Debug.Log (mp.winner);

        if (string.Compare(mp.winner, "Game Over")==0)
        {
            mp.winner = "Player";
        }
        else
            Debug.Log("WTF");
		UItext.GetComponent<Text>().text = mp.winner;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
