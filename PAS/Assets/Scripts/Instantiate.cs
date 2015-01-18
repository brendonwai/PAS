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
	private GameObject gameObject;
	public GameObject rowGetter;
	public float rate;
	private int spawnRound;
	private GameObject[] spawnPoints;


	//Imitate row this script will get from tally or whatever
	private string[] col1 = {"Circle", "Red"};
	private string[] col2 = {"Circle", "Red"};
	private string[] col3 = {"Square", "Red"};
	private string[] col4 = {"Circle", "Blue"};
	private string[] col5 = {"Circle", "Red"};
	private string[] col6 = {"Square", "Blue"};
	private string[] col7 = {"Circle", "Red"};
	private string[] col8 = {"Circle", "Blue"};
	string[,] row1 = new string[8,2] {{"Circle", "Red"}, {"Circle", "Red"}, {"Square", "Red"}, {"Circle", "Blue"}, {"Circle", "Red"}, {"Square", "Blue"}, {"Circle", "Red"}, {"Circle", "Blue"}};



	//


	private bool notDone = true;


	private float time;
	// Use this for initialization
	void Start () 
	{
		spawnPoints = {spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4, spawnPoint5, spawnPoint6, spawnPoint7, spawnPoint8};

		spawnRound = cubeCount;
		SpawnNew ();

	}
	void SpawnNew() {

		//[ ["Circle","Red"], ["Square","Blue"], ...] eight string arrays in total, the first four are the
		//in the row on the left, rest is for the right


		if(spawnRound>1)
		{
			//Get a fresh row from object tally here

			//row1[0,0] bottom left object's shape
			//row1[0,1] bottom left object's color
			//row1[1,0] right of the top object


			//column 1
			GameObject shapeType;
			ShapeColor shapeColor;
			GameObject[] spawnPoints;

			if(row1[0,0]=="Circle")
				shapeType = Circle;
			if(row1[0,0]=="Square")
				shapeType = Square;
			if(row1[0,0]=="Triangle")
				shapeType = Triangle;
			if(row1[0,1]=="Red")
				shapeColor = ShapeColor.Red;
			if(row1[0,1]=="Green")
				shapeColor = ShapeColor.Green;
			if(row1[0,1]=="Blue")
				shapeColor = ShapeColor.Blue;

			gameObject = Instantiate(shapeType, spawnPoint1.transform.position, Quaternion.identity) as GameObject;
			gameObject.GetComponent<PASColor>().setColor(shapeColor);

			
			
			// column 2
			if(row1[1,0]=="Circle")
			{gameObject = Instantiate(Circle, spawnPoint2.transform.position, Quaternion.identity) as GameObject;}
			if(row1[1,0]=="Square")
			{gameObject = Instantiate(Square, spawnPoint2.transform.position, Quaternion.identity) as GameObject;}
			if(row1[1,0]=="Triangle")
			{gameObject = Instantiate(Triangle, spawnPoint2.transform.position, Quaternion.identity) as GameObject;}

			// column 3 
			if(row1[2,0]=="Circle")
			{gameObject = Instantiate(Circle, spawnPoint3.transform.position, Quaternion.identity) as GameObject;}
			if(row1[2,0]=="Square")
			{gameObject = Instantiate(Square, spawnPoint3.transform.position, Quaternion.identity) as GameObject;}
			if(row1[2,0]=="Triangle")
			{gameObject = Instantiate(Triangle, spawnPoint3.transform.position, Quaternion.identity) as GameObject;}

			if(row1[3,0]=="Circle")
			{gameObject = Instantiate(Circle, spawnPoint4.transform.position, Quaternion.identity) as GameObject;}
			if(row1[3,0]=="Square")
			{gameObject = Instantiate(Square, spawnPoint4.transform.position, Quaternion.identity) as GameObject;}
			if(row1[3,0]=="Triangle")
			{gameObject = Instantiate(Triangle, spawnPoint4.transform.position, Quaternion.identity) as GameObject;}

			if(row1[4,0]=="Circle")
			{gameObject = Instantiate(Circle, spawnPoint5.transform.position, Quaternion.identity) as GameObject;}
			if(row1[4,0]=="Square")
			{gameObject = Instantiate(Square, spawnPoint5.transform.position, Quaternion.identity) as GameObject;}
			if(row1[4,0]=="Triangle")
			{gameObject = Instantiate(Triangle, spawnPoint5.transform.position, Quaternion.identity) as GameObject;}

			if(row1[5,0]=="Circle")
			{gameObject = Instantiate(Circle, spawnPoint6.transform.position, Quaternion.identity) as GameObject;}
			if(row1[5,0]=="Square")
			{gameObject = Instantiate(Square, spawnPoint6.transform.position, Quaternion.identity) as GameObject;}
			if(row1[5,0]=="Triangle")
			{gameObject = Instantiate(Triangle, spawnPoint6.transform.position, Quaternion.identity) as GameObject;}

			if(row1[6,0]=="Circle")
			{gameObject = Instantiate(Circle, spawnPoint7.transform.position, Quaternion.identity) as GameObject;}
			if(row1[6,0]=="Square")
			{gameObject = Instantiate(Square, spawnPoint7.transform.position, Quaternion.identity) as GameObject;}
			if(row1[6,0]=="Triangle")
			{gameObject = Instantiate(Triangle, spawnPoint7.transform.position, Quaternion.identity) as GameObject;}

			if(row1[7,0]=="Circle")
			{gameObject = Instantiate(Circle, spawnPoint8.transform.position, Quaternion.identity) as GameObject;}
			if(row1[7,0]=="Square")
			{gameObject = Instantiate(Square, spawnPoint8.transform.position, Quaternion.identity) as GameObject;}
			if(row1[7,0]=="Triangle")
			{gameObject = Instantiate(Triangle, spawnPoint8.transform.position, Quaternion.identity) as GameObject;}

			


//			gameObject = Instantiate(Square, spawnPoint1.transform.position, Quaternion.identity) as GameObject;
//		gameObject = Instantiate(Square, spawnPoint2.transform.position, Quaternion.identity) as GameObject;
//		gameObject = Instantiate(Square, spawnPoint3.transform.position, Quaternion.identity) as GameObject;
//		gameObject = Instantiate(Square, spawnPoint4.transform.position, Quaternion.identity) as GameObject;
//		gameObject = Instantiate(Square, spawnPoint5.transform.position, Quaternion.identity) as GameObject;
//		gameObject = Instantiate(Square, spawnPoint6.transform.position, Quaternion.identity) as GameObject;
//		gameObject = Instantiate(Square, spawnPoint7.transform.position, Quaternion.identity) as GameObject;
//		gameObject = Instantiate(Square, spawnPoint8.transform.position, Quaternion.identity) as GameObject;//

		lastSpawn = Time.time;
		spawnInterval = Random.Range(5,10)*rate;
		}
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
				spawnRound--;
			}
		}


	}
}
