using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectTally : MonoBehaviour {

	public int rows,columns;
	public string[] possibleShapes;
	public string[] possibleColors;
	public bool LeftMore;
	private string requiredColor;
	private string requiredShape;
	private int colorNum=3;
	private int shapeNum=3;
	private List<string> shapePool;
	private List<string> colorPool;
	private double spawnRatio;
	private List<string[]> LeftPool;
	private List<string[]> RightPool;
	private List<string[]> ListRow;

	void Start(){
		shapePool=new List<string>();
		colorPool=new List<string>();
		LeftPool=new List<string[]>();
		RightPool=new List<string[]>();
		/*
		Load (.3, "Purple", "Circle");
		List<string[]> st = getObjectRow ();
		foreach(string[] s in st){
			Debug.Log("s1: "+s[0]+"s2: "+s[1]);
		}
		*/
	}

	void Load(double ratio,string color=null,string shape=null){
		spawnRatio = ratio;
		if(color!=null){
			requiredColor = color;
			colorPool.Add (color);
		}
		if(shape!=null){
			shapePool.Add (shape);
			requiredShape = shape;
		}
		int c = 1;
		int s=1;
		if (requiredColor==null){
			c=0;
		}
		if (requiredShape==null){
			s=0;
		}

		for (int i=0; i < colorNum - c;i++)
			colorPool.Add(PickColor());
		for(int y=0;y<shapeNum-s;y++){
			shapePool.Add (PickShape());
		}
		int num = (int)Mathf.Round(rows * columns * Random.Range (.4f, .8f));
		ListAppender (Random.Range (1,3), num);
	}
	
		

	List<string[]> getObjectRow(){
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

	void ListAppender(int choice,int requiredAmount){
		if (choice==1){
			if(requiredColor!=null && requiredShape!=null){
				for(int i=0;i<requiredAmount;i++){
					LeftPool.Add (new string[]{requiredShape,requiredColor});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					RightPool.Add (new string[]{requiredShape,requiredColor});
				}
			}else if(requiredColor!=null){
				for(int i=0;i<requiredAmount;i++){
					LeftPool.Add (new string[]{PickShapeFromPool(),requiredColor});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					RightPool.Add (new string[]{PickShapeFromPool(),requiredColor});
				}
			}else if(requiredShape!=null){
				for(int i=0;i<requiredAmount;i++){
					LeftPool.Add (new string[]{requiredShape,PickColorFromPool()});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					RightPool.Add (new string[]{requiredShape,PickColorFromPool()});
				}
			}else{
				for(int i=0;i<requiredAmount;i++){
					LeftPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					RightPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
				}
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
			if(requiredColor!=null && requiredShape!=null){
				for(int i=0;i<requiredAmount;i++){
					RightPool.Add (new string[]{requiredShape,requiredColor});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					LeftPool.Add (new string[]{requiredShape,requiredColor});
				}
			}else if(requiredColor!=null){
				for(int i=0;i<requiredAmount;i++){
					RightPool.Add (new string[]{PickShapeFromPool(),requiredColor});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					LeftPool.Add (new string[]{PickShapeFromPool(),requiredColor});
				}
			}else if(requiredShape!=null){
				for(int i=0;i<requiredAmount;i++){
					RightPool.Add (new string[]{requiredShape,PickColorFromPool()});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					LeftPool.Add (new string[]{requiredShape,PickColorFromPool()});
				}
			}else{
				for(int i=0;i<requiredAmount;i++){
					RightPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
				}
				for(int i=0;i<requiredAmount*spawnRatio;i++){
					LeftPool.Add (new string[]{PickShapeFromPool(),PickColorFromPool()});
				}
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

	string PickColor(){
	//	Debug.Log ("LOL");
		int poolCount = 0;
		int needed = 1;
		string colorselected = "NULL";
		while (poolCount < needed) {
			colorselected = possibleColors [Random.Range (0, possibleColors.Length - 1)];
			if (!(requiredColor.Equals(colorselected))){
				poolCount++;
			}
		}
		return colorselected;
	}
	string PickShape(){
		//	Debug.Log ("LOL");
		int poolCount = 0;
		int needed = 1;
		string shapeselected = "NULL";
		while (poolCount < needed) {
			shapeselected = possibleShapes [Random.Range (0, possibleShapes.Length - 1)];
			if (!(requiredShape.Equals(shapeselected))){
				poolCount++;
			}
		}
		return shapeselected;
	}

	string PickColorFromPool(){
		//	Debug.Log ("LOL");
		int poolCount = 0;
		int needed = 1;
		string colorselected = "NULL";
		while (poolCount < needed) {
			colorselected = colorPool [Random.Range (0, colorPool.Count - 1)];
			if (!(requiredColor.Equals(colorselected))){
				poolCount++;
			}
		}
		return colorselected;
	}
	string PickShapeFromPool(){
		//	Debug.Log ("LOL");
		int poolCount = 0;
		int needed = 1;
		string shapeselected = "NULL";
		while (poolCount < needed) {
			shapeselected = shapePool [Random.Range (0, shapePool.Count - 1)];
			if (!(requiredShape.Equals(shapeselected))){
				poolCount++;
			}
		}
		return shapeselected;
	}

	/*string PickShape(){
		string shapeselected = possibleShapes [Random.Range (0, possibleShapes.Length - 1)];
		if (shapePool.Count > 1 && shapePool.Contains (shapeselected)) {
			PickShape ();
		}
		return shapeselected;
	}
	

	string PickColorFromPool(){
		string colorSelected = colorPool [Random.Range (0, colorPool.Count - 1)];
		if(colorPool.Count>1 && colorSelected==requiredColor){
			PickColorFromPool();
		}
		return colorSelected;
	}

	string PickShapeFromPool(){
		string shapeSelected=shapePool[Random.Range(0,shapePool.Count-1)];
		if (shapePool.Count>1 && shapeSelected==requiredShape){
			PickShapeFromPool();
		}
		return shapeSelected;
	}*/
}
