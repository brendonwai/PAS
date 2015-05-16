using System;
using System.Collections;
using UnityEngine;

public struct Question{
	public string shape;
	public string color;
	public string quantity;
	public double ratio;
	public int numColors, numShapes;
}

public class QuestionGenerator{
	private static string[] quantities = {"more","fewer"};
	private static string[] colors = {"blue","red","green","purple","yellow"};
	private static string[] shapes = {"circle","square","triangle"};

	public Question createQuestion(Question question, string shape, string color, string quantity, double ratio, int level){
		question.shape = shape;
		question.color = color;
		question.quantity = quantity;
		question.ratio = ratio;
		int[] parameters = levelParameters (level);
		question.numColors = parameters [0];
		question.numShapes = parameters [1];
		return question;
	}
	// Returns the question and the win parameters, given some number of function parameters based on the difficulty.
	// The returns a question's indexs for a predefined array in the form <question, color, shape, side,ratio>.
	public Question getQuestion(int level) {
		System.Random r = new System.Random();
		string randomColor = null, randomShape = null, randomQuantity = null;
		double ratio = (.55-(1/(1+Math.Pow(Math.E,(level+50)/50))));
		randomQuantity = quantities [r.Next (quantities.Length)];
		randomShape = shapes [r.Next (shapes.Length)];
		randomColor = colors [r.Next (colors.Length)]; 
		return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio, level);
	} 

	//Returns an array of size 2 = [number of colors, number of shapes] given the level. Color range of [2,5], shape range of [2,3].
	private int[] levelParameters(int level) {
		int[] parameters;
		if(level < 3) {
			parameters = new int[]{2,2};
		} else if (level < 6) {
			parameters = new int[]{3,2};
		} else if(level < 12) {
			parameters = new int[]{3,3};
		} else if(level < 22) {
			parameters = new int[]{4,3};
		} else
			parameters = new int[]{5,3};

		return parameters;
	}
}
