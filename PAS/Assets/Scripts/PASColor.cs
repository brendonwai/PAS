using UnityEngine;
using System.Collections;

public class PASColor : MonoBehaviour {

	public ShapeColor color;

	public SpriteRenderer renderer1;

	// Use this for initialization
	void Start () 
	{
		renderer1 = GetComponent<SpriteRenderer>();

		//setColor(color);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//setColor(ShapeColor.Red);	
	}

	public void setColor(ShapeColor color)
	{
		renderer1 = GetComponent<SpriteRenderer>();

		if (color == ShapeColor.Red || color == ShapeColor.BLANK)
		{
			renderer1.color = new Color(210f/255f,83f/255f,65f/255f,1f);
		}

		else if (color == ShapeColor.Green)
		{
			renderer1.color = new Color(140f/255f,235f/255f,148f/255f,1f);;
		}

		else if (color == ShapeColor.Blue)
		{
			renderer1.color = new Color(140f/255f,190f/255f,1f,1f);;
		}

		else if (color == ShapeColor.Yellow)
		{
			renderer1.color = new Color(231f/255f,219f/255f,41f/255f,1f);;
		}

		else if (color == ShapeColor.Purple)
		{
			renderer1.color = new Color(148f/255f,93f/255f,181f/255f,1f);
		}
	}
}

public enum ShapeColor {Red,Green,Blue,Yellow, Purple,BLANK};
