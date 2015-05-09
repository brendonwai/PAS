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
	public int cubeCount = 7;
	private double spawnInterval;
	private float lastSpawn;
	private GameObject gameObject;
	public GameObject rowGetter;
	public float rate;
	private int spawnRound;
	private GameObject[] spawnPoints;

	private ObjectTally tally;

	public bool gameOverMode;

	//Imitate row this script will get from tally or whatever
	/*
	private string[] col1 = {"Circle", "Red"};
	private string[] col2 = {"Circle", "Red"};
	private string[] col3 = {"Square", "Red"};
	private string[] col4 = {"Circle", "Blue"};
	private string[] col5 = {"Circle", "Red"};
	private string[] col6 = {"Square", "Blue"};
	private string[] col7 = {"Circle", "Red"};
	private string[] col8 = {"Circle", "Purple"};
	string[,] row1 = new string[8,2] {{"Circle", "Red"}, {"Circle", "Red"}, {"Square", "Yellow"}, {"Circle", "Blue"}, {"Circle", "Red"}, {"Square", "Green"}, {"Circle", "Red"}, {"Circle", "Purple"}};
	*/
	//

	private bool notDone = true;

	private float time;
	// Use this for initialization
	void Start () 
	{
		spawnPoints = new GameObject[]{spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4, spawnPoint5, spawnPoint6, spawnPoint7, spawnPoint8};

		if(!gameOverMode)
			tally = GameObject.FindGameObjectWithTag("Tally").GetComponent<ObjectTally>();

		spawnRound = cubeCount;
		SpawnNew ();

	}

	string ranShape()
	{
		int ranNum = Random.Range(0,3);
		string shape = "";

		if (ranNum == 0)
			shape = "circle";
		if (ranNum == 1)
			shape = "square";
		if (ranNum == 2)
			shape = "triangle";


		return shape;

	}

	string ranColor()
	{
		int ranNum = Random.Range(0,5);
		string color = "";
		
		if (ranNum == 0)
			color = "red";
		if (ranNum == 0)
			color = "blue";
		if (ranNum == 0)
			color = "green";
		if (ranNum == 3)
			color = "yellow";
		if (ranNum == 4)
			color = "purple";

		return color;

	}

	void SpawnNew() {

		//[ ["Circle","Red"], ["Square","Blue"], ...] eight string arrays in total, the first four are the
		//in the row on the left, rest is for the right

		List<string[]> row = new List<string[]>();

		if(spawnRound>1)
		{
			//Get a fresh row from object tally here

			//row1[0,0] bottom left object's shape
			//row1[0,1] bottom left object's color
			//row1[1,0] right of the top object


			if(!gameOverMode)
				row = tally.getObjectRow();
			else
			{
				for (int i = 0; i < 8; i++)
				{
					row.Add(new string[]{ranShape(),ranColor()});
				}

			}


			for (int i = 0; i < 8; i++)
			{

				GameObject shapeType = null;
				ShapeColor shapeColor = ShapeColor.BLANK;

                if (row[i][0] == "circle")
                    shapeType = Circle;
                else if (row[i][0] == "square")
                    shapeType = Square;
                else if (row[i][0] == "triangle")
                    shapeType = Triangle;
                else
                    shapeType = Circle;
                if (row[i][1] == "red")
                    shapeColor = ShapeColor.Red;
                else if (row[i][1] == "green")
                    shapeColor = ShapeColor.Green;
                else if (row[i][1] == "blue")
                    shapeColor = ShapeColor.Blue;
                else if (row[i][1] == "yellow")
                    shapeColor = ShapeColor.Yellow;
                else if (row[i][1] == "purple")
                    shapeColor = ShapeColor.Purple;
                else
                    shapeColor = ShapeColor.BLANK;

				gameObject = Instantiate(shapeType, spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
				PASColor colorSetter = gameObject.GetComponent<PASColor>();
				colorSetter.setColor(shapeColor);
			}

		lastSpawn = Time.time;
		spawnInterval = Random.Range(5,10)*rate;
		}
	}

	public void clearShapes()
	{
		foreach (GameObject shape in GameObject.FindGameObjectsWithTag("Shape"))
		{
			Object.Destroy(shape);
		}

		spawnRound = cubeCount;
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

				if (!gameOverMode)
				    spawnRound--;

				//Debug.Log(spawnRound);

			}
		}


	}
}
