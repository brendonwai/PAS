using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {
	public GameObject cube;
	public GameObject spawnPoint = null;
	public int cubeCount = 8;
	private double spawnInterval;
	private float lastSpawn;
	public GameObject gameObject1 = null;



	private bool notDone = true;


	private float time;
	// Use this for initialization
	void Start () 
	{
		SpawnNew ();

	}
	void SpawnNew() {
		gameObject1 = Instantiate(cube, spawnPoint.transform.position, Quaternion.identity) as GameObject;
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
