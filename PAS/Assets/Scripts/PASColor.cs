using UnityEngine;
using System.Collections;

public class PASColor : MonoBehaviour {

	public ShapeColor color;

	SpriteRenderer renderer;

	// Use this for initialization
	void Start () 
	{
		renderer = GetComponent<SpriteRenderer>();

		setColor(color);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//setColor(ShapeColor.Red);	
	}

	public void setColor(ShapeColor color)
	{
		if (color == ShapeColor.Red)
		{
			renderer.color = Color.red;
		}

		else if (color == ShapeColor.Green)
		{
			renderer.color = Color.green;
		}

		else if (color == ShapeColor.Blue)
		{
			renderer.color = Color.blue;
		}
	}
}

public enum ShapeColor {Red,Green,Blue,BLANK};
