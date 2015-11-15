using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NewBehaviourScript : MonoBehaviour {

    public GameObject Card;
    public GameObject Square;
    public GameObject Circle;
    public GameObject Triangle;
    public GameObject spawnPoint1 = null;
    private GameObject[] spawnPoints;
    public bool gameOverMode;
    private int cardCount;
    // Use this for initialization
    void Start () {
        spawnPoints = new GameObject[] { spawnPoint1 };
	}
    string ranShape()
    {
        int ranNum = Random.Range(0, 3);
        string shape = "";

        switch(ranNum)
        {
            case 0:
                shape = "circle";
                break;
            case 1:
                shape = "square";
                break;
            case 2:
                shape = "triangle";
                break;
        }

        return shape;

    }

    //to choose random card color 
    string ranColor()
    {
        int ranNum = Random.Range(0, 5);
        string color = "";
        switch (ranNum)
        {
            case 0:
                color = "red";
                break;
            case 1:
                color = "blue";
                break;
            case 2:
                color = "green";
                break;
            case 3:
                color = "yellow";
                break;
            case 4:
                color = "purple";
                break;
        }
        return color;
    }

    void SpawnNew()
    {

        //[ ["Circle","Red"], ["Square","Blue"], ...] eight string arrays in total, the first four are the
        //in the row on the left, rest is for the right

        List<string[]> row = new List<string[]>();

        if (cardCount > 1)
        {
            //Get a fresh row from object tally here

            //row1[0,0] bottom left object's shape
            //row1[0,1] bottom left object's color
            //row1[1,0] right of the top object


            if (!gameOverMode)
                //row = tally.getObjectRow();
                row.Add()
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    row.Add(new string[] { ranShape(), ranColor() });
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

                gameObject1 = Instantiate(shapeType, spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
                PASColor colorSetter = gameObject1.GetComponent<PASColor>();
                colorSetter.setColor(shapeColor);
            }

            lastSpawn = Time.time;
            spawnInterval = Random.Range(5, 10) * rate;
        }
    }

    public void clearShapes()
    {
        foreach (GameObject shape in GameObject.FindGameObjectsWithTag("Shape"))
        {
            Object.Destroy(shape);
        }

        cardCount = cubeCount;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
