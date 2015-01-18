using UnityEngine;
using System.Collections;

public class PASColor : MonoBehaviour {

	public ShapeColor color;

	public SpriteRenderer renderer;

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

		else if (color == ShapeColor.Yellow)
		{
			renderer.color = Color.yellow;
		}

		else if (color == ShapeColor.Purple)
		{
			renderer.color = new Color(255f/51f, 0, 255f/102f);
		}
	}
}

public enum ShapeColor {Red,Green,Blue,Yellow, Purple,BLANK};
