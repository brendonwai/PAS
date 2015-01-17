using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject GameObject = null;
	// Use this for initialization
	void Start () {
		GameObject = Instantiate(Resources.Load("Prefabs/Cube")) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
