using System;
using System.Collections;
using UnityEngine;

public struct Question{
	public string shape;
	public string color;
	public string quantity;
    public double[] leftObjectRatios, rightObjectRatios;
	public int numColors, numShapes;
}

public class QuestionGenerator{
	private static string[] quantities = {"more","fewer"};
	private static string[] colors = {"blue","red","green","purple","yellow"};
	private static string[] shapes = {"circle","square","triangle"};
	public int[] thresholds = {5,12,22,40}; // Artificial thresholds to add in shapes/colors/adjust ratio
	public int shapeThreshold = 10; // The threshold at which questions will start asking different shape types 
    
	// Returns the question and the win parameters, given some number of function parameters based on the difficulty.
	// The returns a question's indexes for a predefined array in the form <question, color, shape, side,ratio>.
	public Question getQuestion(int level) {
		System.Random r = new System.Random();
		string randomColor = null, randomShape = null, randomQuantity = null;
		randomQuantity = quantities [r.Next (quantities.Length)];
		randomColor = colors [r.Next (colors.Length)];

        int[] parameters = levelParameters(level); //0 #colors, 1 #shapes
        int numColors = parameters[0], numShapes = parameters[1];
        double[] leftRatios = new double[numColors * numShapes], rightRatios = new double[numColors * numShapes];

        // If we have passed the shape level threshold, then discriminate shapes for the question - else, only colors.
        if (level > shapeThreshold) {
            randomShape = shapes[r.Next(shapes.Length)];
            return new Question { shape = randomShape, color = randomColor, quantity = randomQuantity, leftObjectRatios = leftRatios };
        } else {
            return new Question { shape = null, color = randomColor, quantity = randomQuantity, rightObjectRatios = rightRatios };
        }
    } 

	//Returns an array of size 2 = [number of colors, number of shapes] given the level. Color range of [2,5], shape range of [2,3].
	private int[] levelParameters(int level) {
		int[] parameters;
		if(level < thresholds[0]) {
			parameters = new int[]{2,2};
		} else if (level < thresholds[1]) {
			parameters = new int[]{3,2};
		} else if(level < thresholds[2]) {
			parameters = new int[]{3,3};
		} else if(level < thresholds[3]) {
			parameters = new int[]{4,3};
		} else
			parameters = new int[]{5,3};

		return parameters;
	}
}
