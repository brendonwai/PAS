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
	private int colorNum=1;
	private int shapeNum=2;
	private List<string> shapePool=null;
	private List<string> colorPool=null;
	private double spawnRatio;
	private List<string[]> LeftPool=null;
	private List<string[]> RightPool=null;
	private List<string[]> ListRow;

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

	}

	void Generate(){
		int c = 1;
		int s=1;
		if (requiredColor==null){
			c=0;
		}
		if (requiredShape==null){
			s=0;
		}
		for (int i=0;i<colorNum-c;i++){
			colorPool.Add(PickColor());
		}
		for(int y=0;y<shapeNum-s;y++){
			shapePool.Add (PickShape());
		}
		int num = (int)Mathf.Round(rows * columns * Random.Range (.4f, .8f));
		ListAppender (Random.Range (1,2), num);
	}

	List<string[]> getObjectRow(){
		ListRow = new List<string[]> ();
		if(LeftPool.Count==0 || RightPool.Count==0){
			return null;
		}
		for (int i=0;i<columns;i++){
			int toRemove=Random.Range (0,LeftPool.Count-1);
			ListRow.Add (LeftPool[toRemove]);
			LeftPool.RemoveAt(toRemove);
		}
		for(int i=0;i<columns;i++){
			int toRemove=Random.Range (0,RightPool.Count-1);
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
		string colorselected = possibleColors [Random.Range (0, possibleColors.Length - 1)];
		if (colorPool.Contains(colorselected)) {
			PickColor ();
		}
		return colorselected;
	}

	string PickShape(){
		string shapeselected = possibleShapes [Random.Range (0, possibleShapes.Length - 1)];
		if (shapePool.Contains (shapeselected)) {
			PickShape ();
		}
		return shapeselected;
	}

	string PickColorFromPool(){
		string colorSelected = colorPool [Random.Range (0, colorPool.Count - 1)];
		if(colorSelected==requiredColor){
			PickColorFromPool();
		}
		return colorSelected;
	}

	string PickShapeFromPool(){
		string shapeSelected=shapePool[Random.Range(0,shapePool.Count-1)];
		if (shapeSelected==requiredShape){
			PickShapeFromPool();
		}
		return shapeSelected;
	}
}
