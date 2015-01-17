using UnityEngine;
using System;
using System.Collections;
public struct Question{
	public int shape;
	public int color;
	public int quantity;
	public double ratio;
}
public class QuestionGenerator : MonoBehaviour {
	private static int[] quantities = {0,1};
	private static int[] colors = {0,1,2,3,4};
	private static int[] shapes = {0,1,2};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	Question createQuestion(Question question, int shape, int color, int quantity, double ratio){
		question.shape = shape;
		question.color = color;
		question.quantity = quantity;
		question.ratio = ratio;
		return question;
	}
	// Returns the question and the win parameters, given some number of function parameters based on the difficulty.
	// The returned tuple is of the form <question, color, shape, side,ratio>.
	Question getQuestion(int level) {
		System.Random r = new System.Random();
		string randomColor = null; 
		string randomShape = null;
		string randomQuantity;
		double ratio = (50+level)/100;		
		if (level < 4) {
			randomQuantity = quantities [r.Next (2)];
			return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
		} else if (level < 7) {
			randomQuantity = "more";
			switch (r.Next (2)) {
			case 0:
				randomShape = shapes [r.Next (shapes.Length)]; 
				return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
			case 1:
				randomColor = colors [r.Next (colors.Length)]; 
				return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);

			}
		} else {
			randomQuantity = quantities [r.Next (2)];
			randomShape = shapes [r.Next (shapes.Length)];
			randomColor = colors [r.Next (colors.Length)]; 
			return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
		}
	} 
}
