using UnityEngine;
using System.Collections.Generic;

public class ObjectTally : MonoBehaviour {

    //This class determines the order, amount, and type of objects to be 
    //generated according to the requirements from the Question class.
    //The final returned object is a list of one row of objects in randomized order to be
    //displayed in the GUI.
    //output format example for 4 columns of object on each side:
    //[object1,object2,object3,object4,object5,object6,object7,object8]
    //each object is a string list in the format ["shape","color"]
    //the first four objects in the list goes on the left side, the rest goes on the right side
    //The objects should be generated in the exact order of the list since it is already randomized


    //number of rows and columns on each side
    //rows and columns are always equal on the left and right side
    public int rows, columns;
    //List of shapes that could be generated from this code
    //Remains constant
    //Make changes to list in Unity editor when needed
    public string[] possibleShapes;
    //same type of list as above for colors
    public string[] possibleColors;
    //True when left side has more required objects
    //used to determine correct answer for the question
    public bool LeftMore;
    //the color mentioned in the question that is guaranteed 
    //to be generated
    private string requiredColor;
    //Same as above for shapes
    private string requiredShape;
    //Number of colors to be included in the final output list
    private int colorNum = 2;
    //same as above for shapes
    private int shapeNum = 2;
    //list of shapes to be included in the final output list
    private List<string> shapePool = new List<string>();
    //same as above for colors
    private List<string> colorPool = new List<string>();

    //the complete list of objects to be generated on the left side
    private List<string[]> LeftPool = new List<string[]>();
    //same as above for the right side
    private List<string[]> RightPool = new List<string[]>();
    //one row of randomized final list of objects including the left and right side
    //to be called to display on GUI
    private List<string[]> ListRow;

    void Start() {
        shapePool = new List<string>();
        colorPool = new List<string>();
        LeftPool = new List<string[]>();
        RightPool = new List<string[]>();
    }

    //Call this function from Question.cs to input requirements from question
    //i.e: required shapes and colors
    //input format ["required colors","required shapes","color number","shape number""left object ratios","right object ratios"]
    //Adds required to color/shape to the corresponding list pool and calls
    //ListAppender function
    public void Load(Question question) {
        colorPool.Clear();
        shapePool.Clear();
        LeftPool.Clear();
        RightPool.Clear();
        colorNum = question.numColors;
        shapeNum = question.numShapes;

        requiredColor = question.color;
        requiredShape = question.shape;

        for (int i = 0; i < question.objects.Length; i++) {
            if (question.objects[i].Key == requiredColor && question.objects[i].Value == requiredShape)
                LeftMore = question.leftObjectRatios[i] > question.rightObjectRatios[i] ? true : false;
            colorPool.Add(question.objects[i].Key);
            shapePool.Add(question.objects[i].Value);
        }

        int sideObjectCount = rows * columns;
        fillObjectPools(question.objects, question.leftObjectRatios, question.rightObjectRatios, sideObjectCount);
    }


    //Call this function from GUI for the specific objects to generate in each row
    //each call returns one row of objects, so call 8 times if you have 8 rows
    public List<string[]> getObjectRow() {
        ListRow = new List<string[]>();
        if (LeftPool.Count == 0 || RightPool.Count == 0) {
            return null;
        }
        for (int i = 0; i < columns; i++) {
            int toRemove = Random.Range(0, LeftPool.Count);
            ListRow.Add(LeftPool[toRemove]);
            LeftPool.RemoveAt(toRemove);
        }
        for (int i = 0; i < columns; i++) {
            int toRemove = Random.Range(0, RightPool.Count);
            ListRow.Add(RightPool[toRemove]);
            RightPool.RemoveAt(toRemove);
        }
        return ListRow;
    }

    //No need to call this function from elsewhere
    //Appends item to left and right pool according to the requirements 
    //read from Load function. GetObjectRow will then randomly pick objects
    //from each pool for generating the final row lists
    void fillObjectPools(KeyValuePair<string, string>[] objects, double[] leftRatios, double[] rightRatios, int sideCount) {
        for (int i = 0; i < objects.Length; i++) {
            for (int leftIndex = 0; leftIndex < leftRatios[i] * sideCount; leftIndex++)
                LeftPool.Add(new string[] { objects[i].Value, objects[i].Key });

            for (int rightIndex = 0; rightIndex < rightRatios[i] * sideCount; rightIndex++)
                RightPool.Add(new string[] { objects[i].Value, objects[i].Key });
        }
    }
}
