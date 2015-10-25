using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Question {
	public string shape;
	public string color;
	public string quantity;
    public double[] leftObjectRatios, rightObjectRatios;
	public int numColors, numShapes;
    public KeyValuePair<string, string>[] objects;
}

public class QuestionGenerator{
	private static string[] quantities = {"more","fewer"};
	private static string[] colors = {"blue","red","green","purple","yellow"};
	private static string[] shapes = {"circle","square","triangle"};
	public int[] thresholds = {5,12,22,35}; // Artificial thresholds to add in shapes/colors/adjust ratio
	public int shapeThreshold = 5; // The threshold at which questions will start asking different shape types 
    
	// Returns the question and the win parameters, given some number of function parameters based on the difficulty.
	// The returns a question's indexes for a predefined array in the form <question, color, shape, side,ratio>.
	public Question getQuestion(int level) {
		System.Random r = new System.Random();
        int[] parameters = levelParameters(level); //0 #colors, 1 #shapes
        int numColors = parameters[0], numShapes = parameters[1], numObjects = numColors * numShapes;
        KeyValuePair<string, string>[] shapeObjects = generateObjectPermutations(numColors, numShapes);

        string randomColor = shapeObjects[r.Next(shapeObjects.Length)].Key, 
            randomShape = shapeObjects[r.Next(shapeObjects.Length)].Value, randomQuantity = quantities[r.Next(quantities.Length)];

        double[][] sideRatios = fillSpawnPercentages(new double[numObjects], new double[numObjects],level,numObjects, randomQuantity);
        double[] leftRatios = sideRatios[0], rightRatios = sideRatios[1];

        // If we have passed the shape level threshold, then discriminate shapes for the question - else, only colors.
        if (level > shapeThreshold)
            return new Question { shape = randomShape, color = randomColor, quantity = randomQuantity, leftObjectRatios = leftRatios, rightObjectRatios = rightRatios, objects = shapeObjects };
        else
            return new Question { shape = null, color = randomColor, quantity = randomQuantity, leftObjectRatios = leftRatios, rightObjectRatios = rightRatios, objects = shapeObjects };
    } 

	//Returns an array of size 2 = [number of colors, number of shapes] given the level. Color range of [0,5], shape range of [2,3].
	private int[] levelParameters(int level) {
		int[] parameters;
		if(level < shapeThreshold) { //For when we're only asking for shapes, not colors
			parameters = new int[]{3,3};
		} else if (level < thresholds[1]) {
			parameters = new int[]{1,2};
		} else if(level < thresholds[2]) {
			parameters = new int[]{2,3};
		} else if(level < thresholds[3]) {
			parameters = new int[]{3,3};
		} else if(level < thresholds[4]) {
            parameters = new int[]{4,3};
        } else
			parameters = new int[]{5,3};

		return parameters;
	}

    // Given the level and number of objects, returns an array of minimum and maximum percentages.
    // The returned array is of the form {minimum percentage, maximum percentage}.
    // Current algorithm: If the current sum of ratios of any side + current upper bound exceeds 1, we lower the upper bound so the total ratio = 1 at all times.
    // Take the given difference made in the upper bound and subtract from lower bound - if below 0, lowerBound = 0 to make within legal bounds.
    // Invariant: 0 <= lowerBound < upperBound <= (upperBound + maxSum) <= 1
    private double[] findSpawnPercentages(int level, int objectCount, double maxSum) {
        double lowerBound = 0.15, upperBound = 0.35;

        if (maxSum + upperBound > 1) {
            double lastUpperBound = upperBound;
            upperBound = 1 - maxSum;
            lowerBound = lowerBound - (lastUpperBound - upperBound);
            if (lowerBound < 0)
                lowerBound = 0;
        }
        
        return new double[] {lowerBound,upperBound};
    }

    // Given the arrays of spawn percentages for each side, fills them according to the bounded percentages.
    private double[][] fillSpawnPercentages(double[] leftSideRatios, double[] rightSideRatios, int level, int objectCount, string quantity) {
        System.Random r = new System.Random();
        double leftSum = 0, rightSum = 0;
        for(int i = 0; i < objectCount; i++) {
            if(i != objectCount - 1) {
                double maxSum = leftSum > rightSum ? leftSum : rightSum;
                double[] spawnPercentageBounds = findSpawnPercentages(level, objectCount, maxSum);
                double leftPercentage = (double)r.Next((int)(spawnPercentageBounds[0] * 100), (int)(spawnPercentageBounds[1] * 100)) / 100,
                    rightPercentage = spawnPercentageBounds[1] - leftPercentage;

                leftSideRatios[i] = leftPercentage;
                rightSideRatios[i] = rightPercentage;

                leftSum += leftPercentage;
                rightSum += rightPercentage;

            } else {
                leftSideRatios[i] = 1 - leftSum;
                rightSideRatios[i] = 1 - rightSum;
            }
        }

        return new double[][] {leftSideRatios, rightSideRatios};    
    }

    //Generates (K,V) pairs of the shapes (keys) and colors (shapes); every pair represents an object (e.g. blue circle).
    private KeyValuePair<string,string>[] generateObjectPermutations(int numColors, int numShapes) {
        KeyValuePair<string, string>[] objects;
        if(numColors == 0) {
            objects = new KeyValuePair<string, string>[numShapes];
            for(int i = 0; i < objects.Length; i++) {
                objects[i] = new KeyValuePair<string, string>(null, shapes[i]);
            }
            return objects;
        }

        objects = new KeyValuePair<string, string>[numColors * numShapes];
        System.Random r = new System.Random();
        colors = colors.OrderBy(x => r.Next()).ToArray();
        shapes = shapes.OrderBy(x => r.Next()).ToArray();

        for(int i = 0; i < numColors; i++) {
            for(int j = 0; j < numShapes; j++) {
                objects[i * numShapes + j] = new KeyValuePair<string, string>(colors[i], shapes[j]);
            }
        }
        
        return objects;
    }
}
