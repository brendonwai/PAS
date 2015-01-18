using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// ["shape","color"]


// getObjectRow()


public class Instantiate : MonoBehaviour {
	public GameObject Square;
	public GameObject Circle;
	public GameObject Triangle;
	public GameObject spawnPoint1 = null;
	public GameObject spawnPoint2 = null;
	public GameObject spawnPoint3 = null;
	public GameObject spawnPoint4 = null;
	public GameObject spawnPoint5 = null;
	public GameObject spawnPoint6 = null;
	public GameObject spawnPoint7 = null;
	public GameObject spawnPoint8 = null;
	public int cubeCount = 8;
	private double spawnInterval;
	private float lastSpawn;
	public GameObject gameObject1 = null;
	public GameObject rowGetter;
//	private string[] row;


	private bool notDone = true;


	private float time;
	// Use this for initialization
	void Start () 
	{
		SpawnNew ();

	}
	void SpawnNew() {

	//	row = rowGetter.SendMessage("getObjectRow");


		gameObject1 = Instantiate(Square, spawnPoint1.transform.position, Quaternion.identity) as GameObject;
		gameObject1 = Instantiate(Square, spawnPoint2.transform.position, Quaternion.identity) as GameObject;
		gameObject1 = Instantiate(Square, spawnPoint3.transform.position, Quaternion.identity) as GameObject;
		gameObject1 = Instantiate(Square, spawnPoint4.transform.position, Quaternion.identity) as GameObject;
		gameObject1 = Instantiate(Square, spawnPoint5.transform.position, Quaternion.identity) as GameObject;
		gameObject1 = Instantiate(Square, spawnPoint6.transform.position, Quaternion.identity) as GameObject;
		gameObject1 = Instantiate(Square, spawnPoint7.transform.position, Quaternion.identity) as GameObject;
		gameObject1 = Instantiate(Square, spawnPoint8.transform.position, Quaternion.identity) as GameObject;

		
		cubeCount--;
		lastSpawn = Time.time;
		spawnInterval = Random.Range(5,10)*0.02;
	}
	// Update is called once per frame
	void Update () {
		if (notDone) 
		{
			if(cubeCount==0)
			{
				notDone = false;
			}
				
			if(Time.time > (lastSpawn + spawnInterval))
			{
				SpawnNew ();
			}
		}


	}
}
