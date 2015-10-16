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
	public int rows,columns;
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
	private int colorNum=2;
	//same as above for shapes
	private int shapeNum=2;
	//list of shapes to be included in the final output list
	private List<string> shapePool=new List<string>();
	//same as above for colors
	private List<string> colorPool =new List<string>();

	//the complete list of objects to be generated on the left side
	private List<string[]> LeftPool=new List<string[]>();
	//same as above for the right side
	private List<string[]> RightPool=new List<string[]>();
	//one row of randomized final list of objects including the left and right side
	//to be called to display on GUI
	private List<string[]> ListRow;

	void Start(){
		shapePool=new List<string>();
		colorPool=new List<string>();
		LeftPool=new List<string[]>();
		RightPool=new List<string[]>();
	}

	//Call this function from Question.cs to input requirements from question
	//i.e: required shapes and colors
	//input format ["required colors","required shapes","color number","shape number""left object ratios","right object ratios"]
	//Adds required to color/shape to the corresponding list pool and calls
	//ListAppender function
	public void Load(Question question){
		colorPool.Clear();
		shapePool.Clear();
		LeftPool.Clear();
		RightPool.Clear();
        colorNum = question.numColors;
        shapeNum = question.numShapes;

        requiredColor = question.color;
        requiredColor = question.shape;

        foreach (KeyValuePair<string,string> shapeObject in question.objects) {
            colorPool.Add(shapeObject.Key);
            shapePool.Add(shapeObject.Value);
        }

		ListAppender (Random.Range (1,3), num);
	}
	
		
	//Call this function from GUI for the specific objects to generate in each row
	//each call returns one row of objects, so call 8 times if you have 8 rows
	public List<string[]> getObjectRow(){
		ListRow = new List<string[]> ();
		if(LeftPool.Count==0 || RightPool.Count==0){
			return null;
		}
		for (int i=0;i<columns;i++){
			int toRemove=Random.Range (0,LeftPool.Count);
			ListRow.Add (LeftPool[toRemove]);
			LeftPool.RemoveAt(toRemove);
		}
		for(int i=0;i<columns;i++){
			int toRemove=Random.Range (0,RightPool.Count);
			ListRow.Add (RightPool[toRemove]);
			RightPool.RemoveAt(toRemove);
		}
		return ListRow;
	}

	//No need to call this function from elsewhere
	//Appends item to left and right pool according to the requirements 
	//read from Load function. GetObjectRow will then randomly pick objects
	//from each pool for generating the final row lists
	void ListAppender(int choice,int requiredAmount){
		if (choice==1){		
			for(int i=0;i<requiredAmount;i++){
				LeftPool.Add (new string[]{requiredShape,requiredColor});
			}
			for(int i=0;i<requiredAmount*spawnRatio;i++){
				RightPool.Add (new string[]{requiredShape,requiredColor});
			}		
			for(int i=0;i<rows*columns-requiredAmount;i++){
				LeftPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
			}
			for(int i=0;i<rows*columns-requiredAmount*spawnRatio;i++){
				RightPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
			}
			LeftMore=true;
		}
		if(choice==2){
			for(int i=0;i<requiredAmount;i++){
				RightPool.Add (new string[]{requiredShape,requiredColor});
			}
			for(int i=0;i<requiredAmount*spawnRatio;i++){
				LeftPool.Add (new string[]{requiredShape,requiredColor});
			}
			for(int i=0;i<rows*columns-requiredAmount;i++){
				RightPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
			}
			for(int i=0;i<rows*columns-requiredAmount*spawnRatio;i++){
				LeftPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
			}
			LeftMore=false;
		}
	}


//--------------------------------nothing wrong beyond this point--------------------------


	//No need to call this function from elsewhere
	//Support function that randomly picks a color from possibleColor pool
	string PickColor(){

		int poolCount = 0;
		string colorselected = "NULL";
		while (poolCount < 1) {
			colorselected = possibleColors [Random.Range (0, possibleColors.Length)];
			if (!(requiredColor.Equals(colorselected))){
				poolCount++;
			}
		}
		return colorselected;
	}

	//No need to call this function from elsewhere
	//same as the function above for shapes
	string PickShape(){

		int poolCount = 0;
		string shapeselected = "NULL";
		while (poolCount < 1) {
			shapeselected = possibleShapes [Random.Range (0, possibleShapes.Length)];
			if (!(requiredShape.Equals(shapeselected))){
				poolCount++;
			}
		}
		return shapeselected;
	}

	//No need to call this function from elsewhere
	//Support function that randomly picks a color from ColorPool to include in either left
	//or right pool
	string PickColorFromPool(){
		int poolCount = 0;
		int needed = 1;
		string colorselected = "NULL";
		while (poolCount < needed) {
			colorselected = colorPool [Random.Range (0, colorPool.Count)];
			if (!(requiredColor.Equals(colorselected))){
				poolCount++;
			}
		}
		return colorselected;
	}

	//No need to call this function from elsewhere
	//same as the function above for shapes
	string PickShapeFromPool(){
		int poolCount = 0;
		int needed = 1;
		string shapeselected = "NULL";
		while (poolCount < needed) {
			shapeselected = shapePool [Random.Range (0, shapePool.Count)];
			if (!(requiredShape.Equals(shapeselected))){
				poolCount++;
			}
		}
		return shapeselected;
	}

}
